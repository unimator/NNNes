using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NNNES.Emulator.Forms.Proxy;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace NNNES.Emulator.Forms
{
    public partial class NesEmulator : Form
    {
        private enum ChrRom
        {
            None = 0,
            Left = 1,
            Right = 2
        };

        private bool _isDragging = false;
        private Point _lastLocation;

        private ChrRom _currentSection;
        private ChrRom CurrentSection
        {
            get => _currentSection;
            set
            {
                if (value == _currentSection)
                {
                    return;
                }

                _currentSection = value;
                switch (_currentSection)
                {
                    case ChrRom.None:
                        btnChrRomRight.ForeColor = Color.LawnGreen;
                        btnChrRomLeft.ForeColor = Color.LawnGreen;
                        return;
                    case ChrRom.Left:
                        btnChrRomRight.ForeColor = Color.LawnGreen;
                        btnChrRomLeft.ForeColor = Color.Firebrick;
                        break;
                    case ChrRom.Right:
                        btnChrRomRight.ForeColor = Color.Firebrick;
                        btnChrRomLeft.ForeColor = Color.LawnGreen;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                glChrRom.Invalidate();
            }
        }

        private NesCartridge _nesCartridge;

        public NesEmulator()
        {
            InitializeComponent();
        }

        private void glNesWindow_Load(object sender, EventArgs e)
        {
            glNesWindow.Paint += (o, args) =>
            {
                glNesWindow.MakeCurrent();
                GL.ClearColor(Color.Black);
                GL.Clear(ClearBufferMask.ColorBufferBit);
                glNesWindow.SwapBuffers();
            };
        }

        private void NesEmulator_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                Location = new Point((Location.X - _lastLocation.X) + e.X, (Location.Y - _lastLocation.Y) + e.Y);

                Update();
            }
        }

        private void NesEmulator_MouseUp(object sender, MouseEventArgs e)
        {
            _isDragging = false;
        }

        private void NesEmulator_MouseDown(object sender, MouseEventArgs e)
        {
            _isDragging = true;
            _lastLocation = e.Location;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSwitchChrRom(object sender, EventArgs e)
        {
            if (_nesCartridge == null)
            {
                return;
            }

            if (sender == btnChrRomLeft)
            {
                CurrentSection = ChrRom.Left;
            } 
            else if (sender == btnChrRomRight)
            {
                CurrentSection = ChrRom.Right;
            }
        }

        private void btnLoadRom_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _currentSection = ChrRom.None;
                var filePath = openFileDialog.FileName;
                using (var stream = openFileDialog.OpenFile())
                using (var memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    var bytes = memoryStream.ToArray();
                    _nesCartridge = new NesCartridge(bytes);

                    CurrentSection = ChrRom.Left;
                    RepaintChrRom();
                }
            }
        }

        private void RepaintChrRom()
        {
            var chrRomSize = _nesCartridge.GetChrRom().Length;
            if (chrRomSize >= 0x2000)
            {
                glChrRom.Invalidate();
            }
        }

        private void GlChrRomPaint(GLControl glControl)
        {
            glControl.MakeCurrent();
            GL.ClearColor(Color.Black);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.LoadIdentity();
            GL.Ortho(0, 128, 128, 0, 0, 1);
            if (CurrentSection == ChrRom.None)
            {
                glControl.SwapBuffers();
                return;
            } 

            var chrRom = _nesCartridge?.GetChrRom();

            

            if (chrRom != null && chrRom.Length >= 0x2000)
            {
                var bytes = chrRom.Take(0x2000).ToArray();
                var offset = CurrentSection == ChrRom.Left ? 0 : 256;

                for (var i = 0; i < 16; ++i)
                {
                    for (var j = 0; j < 16; ++j)
                    {
                        var spriteId = i * 16 + j + offset;
                        var plane0 = bytes.Skip(spriteId * 16).Take(8).ToArray();
                        var plane1 = bytes.Skip(spriteId * 16 + 8).Take(8).ToArray();

                        for (var k = 0; k < 8; ++k)
                        {
                            var channelA = plane0[k];
                            var channelB = plane1[k];

                            for (var l = 0; l < 8; ++l)
                            {
                                var colorCode = ((channelA >> l) & 1) | ((channelB >> l) & (1 << 1));

                                Color color;
                                switch (colorCode)
                                {
                                    case 0:
                                        color = Color.Black;
                                        break;
                                    case 1:
                                        color = Color.DimGray;
                                        break;
                                    case 2:
                                        color = Color.DarkGray;
                                        break;
                                    case 3:
                                        color = Color.White;
                                        break;
                                    default:
                                        throw new Exception("Unknown color");
                                }

                                GL.PointSize(2);
                                GL.Begin(PrimitiveType.Points);
                                GL.Color3(color);
                                var x = j * 8 + 8 - l;
                                var y = i * 8 + k;
                                GL.Vertex2(x, y);

                                if (x > 128 || y > 128)
                                {

                                }

                                GL.End();
                            }
                        }
                    }
                }

            }

            glControl.SwapBuffers();
        }

        private void glChrRom_Load(object sender, EventArgs e)
        {
            var glChrRomControl = (GLControl) sender;
            if (sender != null)
            {
                glChrRomControl.Invalidate();
            }
        }

        private void glChrRom_Paint(object sender, PaintEventArgs e)
        {
            var glChrRomControl = (GLControl)sender;

            if (sender == null)
            {
                return;
            }

            if (_nesCartridge == null)
            {
                glChrRomControl.MakeCurrent();
                GL.ClearColor(Color.Black);
                GL.Clear(ClearBufferMask.ColorBufferBit);
                glChrRomControl.SwapBuffers();
            }
            else
            {
                GlChrRomPaint(glChrRomControl);
            }
        }
    }
}