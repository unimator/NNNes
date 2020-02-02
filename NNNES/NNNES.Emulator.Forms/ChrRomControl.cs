using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NNNES.Emulator.Forms.Proxy;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace NNNES.Emulator.Forms
{
    public partial class ChrRomControl : UserControl
    {
        private NesCartridge _nesCartridge;

        internal enum ChrRom
        {
            None = 0,
            Left = 1,
            Right = 2
        };

        private ChrRom _currentSection = ChrRom.None;
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

        public NesCartridge NesCartridge
        {
            get => _nesCartridge;
            set
            {
                _nesCartridge = value;
                CurrentSection = ChrRom.Left;
                comboBank.Items.Clear();
                if (_nesCartridge != null)
                {
                    var chrRomSize = _nesCartridge.GetChrRom()?.Length;
                    for (var i = 0; i < chrRomSize / 0x2000; ++i)
                    {
                        comboBank.Items.Insert(i, $"Bank {i}");
                    }

                    if (comboBank.Items.Count > 0)
                    {
                        comboBank.SelectedIndex = 0;
                    }
                }
                
                glChrRom.Invalidate();
            }
        }

        public ChrRomControl()
        {
            InitializeComponent();
        }

        private void btnChrRom_Click(object sender, EventArgs e)
        {
            if (NesCartridge == null)
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

        private void glChrRom_Paint(object sender, PaintEventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            glChrRom.MakeCurrent();
            GL.ClearColor(Color.Black);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.LoadIdentity();
            GL.Ortho(0, 128, 128, 0, 0, 1);
            if (CurrentSection == ChrRom.None)
            {
                glChrRom.SwapBuffers();
                return;
            }

            var chrRom = NesCartridge?.GetChrRom();

            if (chrRom != null && chrRom.Length >= 0x2000)
            {
                var currentBank = comboBank.SelectedIndex;
                var bytes = chrRom.Skip(currentBank * 0x2000).Take(0x2000).ToArray();
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

            glChrRom.SwapBuffers();
        }

        private void comboBank_SelectedValueChanged(object sender, EventArgs e)
        {
            glChrRom.Invalidate();
        }

        private void glChrRom_Load(object sender, EventArgs e)
        {
            var glChrRomControl = (GLControl)sender;
            if (sender != null)
            {
                glChrRomControl.Invalidate();
            }
        }
    }
}
