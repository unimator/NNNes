using NNNES.Emulator.Proxy;
using NNNES.Emulator.Proxy.Proxy;
using OpenTK.Graphics.OpenGL;
using System.ComponentModel;

namespace NNNES.Emulator.Forms
{
    public partial class ChrRomControl : UserControl
    {
        private Nes _nes;

        internal enum ChrRom
        {
            None = 0,
            Left = 1,
            Right = 2
        };

        private int _selectedPalleteIndex = 0;

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

        private int _program;
        private int _vao;
        private int _vbo;
        private bool _glReady;
        private int _texture;
        private int _uPixels;

        private const string VertexShaderSource = """
    #version 330 core

    layout (location = 0) in vec2 aPosition;
    out vec2 vPosition;

    void main()
    {
        vPosition = aPosition;
        gl_Position = vec4(aPosition, 0.0, 1.0);
    }
    """;

        private const string FragmentShaderSource = """
    #version 330 core

    in vec2 vPosition;

    uniform sampler2D uPixels;
    uniform vec2 uResolution;

    out vec4 outputColor;

    void main()
    {
        vec2 uv = vPosition * 0.5 + 0.5;
        outputColor = texture(uPixels, uv);
    }
    """;

        private static readonly float[] QuadVertices =
{
    // x, y
    -1f, -1f,
     1f, -1f,
     1f,  1f,
    -1f, -1f,
     1f,  1f,
    -1f,  1f
};
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Nes Nes
        {
            get => _nes;
            set
            {
                _nes = value;
                CurrentSection = ChrRom.Left;
                comboBank.Items.Clear();
                if (_nes != null)
                {
                    var chrRomSize = _nes.GetChrRom()?.Length;
                    for (var i = 0; i < chrRomSize / 0x2000; ++i)
                    {
                        comboBank.Items.Insert(i, $"Bank {i}");
                    }

                    if (comboBank.Items.Count > 0)
                    {
                        comboBank.SelectedIndex = 0;
                    }
                }

                UpdateState();
            }
        }

        public void UpdateState()
        {
            UpdatePalettes();
            glChrRom.Invalidate();
        }

        public ChrRomControl()
        {
            InitializeComponent();

            paletteControl1.PaletteSelected += (sender, e) => {
                _selectedPalleteIndex = 0;
                UpdateState();
            };

            paletteControl2.PaletteSelected += (sender, e) => {
                _selectedPalleteIndex = 1;
                UpdateState();
            };

            paletteControl3.PaletteSelected += (sender, e) => {
                _selectedPalleteIndex = 2;
                UpdateState();
            };

            paletteControl4.PaletteSelected += (sender, e) => {
                _selectedPalleteIndex = 3;
                UpdateState();
            };

            paletteControl5.PaletteSelected += (sender, e) => {
                _selectedPalleteIndex = 4;
                UpdateState();
            };

            paletteControl6.PaletteSelected += (sender, e) => {
                _selectedPalleteIndex = 5;
                UpdateState();
            };

            paletteControl7.PaletteSelected += (sender, e) => {
                _selectedPalleteIndex = 6;
                UpdateState();
            };

            paletteControl8.PaletteSelected += (sender, e) => {
                _selectedPalleteIndex = 7;
                UpdateState();
            };
        }

        private void btnChrRom_Click(object sender, EventArgs e)
        {
            if (Nes == null)
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

        private static int CompileShader(ShaderType type, string source)
        {
            var shader = GL.CreateShader(type);
            GL.ShaderSource(shader, source);
            GL.CompileShader(shader);

            GL.GetShader(shader, ShaderParameter.CompileStatus, out var compiled);
            if (compiled == 0)
            {
                var log = GL.GetShaderInfoLog(shader);
                GL.DeleteShader(shader);
                throw new InvalidOperationException($"{type} compilation failed:\n{log}");
            }

            return shader;
        }

        private static int CreateProgram(string vertexSource, string fragmentSource)
        {
            var vertexShader = CompileShader(ShaderType.VertexShader, vertexSource);
            var fragmentShader = CompileShader(ShaderType.FragmentShader, fragmentSource);

            var program = GL.CreateProgram();
            GL.AttachShader(program, vertexShader);
            GL.AttachShader(program, fragmentShader);
            GL.LinkProgram(program);

            GL.GetProgram(program, GetProgramParameterName.LinkStatus, out var linked);
            if (linked == 0)
            {
                var log = GL.GetProgramInfoLog(program);
                GL.DeleteProgram(program);
                throw new InvalidOperationException($"Shader program link failed:\n{log}");
            }

            GL.DetachShader(program, vertexShader);
            GL.DetachShader(program, fragmentShader);
            GL.DeleteShader(vertexShader);
            GL.DeleteShader(fragmentShader);

            return program;
        }

        private void glChrRom_Load(object? sender, EventArgs e)
        {
            glChrRom.MakeCurrent();

            _program = CreateProgram(VertexShaderSource, FragmentShaderSource);

            _texture = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, _texture);

            GL.TexParameter(
                TextureTarget.Texture2D,
                TextureParameterName.TextureMinFilter,
                (int)TextureMinFilter.Nearest);
            GL.TexParameter(
                TextureTarget.Texture2D,
                TextureParameterName.TextureMagFilter,
                (int)TextureMagFilter.Nearest);
            GL.TexParameter(
                TextureTarget.Texture2D,
                TextureParameterName.TextureWrapS,
                (int)TextureWrapMode.ClampToEdge);
            GL.TexParameter(
                TextureTarget.Texture2D,
                TextureParameterName.TextureWrapT,
                (int)TextureWrapMode.ClampToEdge);

            GL.TexImage2D(
                TextureTarget.Texture2D,
                0,
                PixelInternalFormat.Rgba,
                128,
                128,
                0,
                PixelFormat.Bgra,
                PixelType.UnsignedByte,
                IntPtr.Zero);

            _uPixels = GL.GetUniformLocation(_program, "uPixels");

            _vao = GL.GenVertexArray();
            GL.BindVertexArray(_vao);
            _vbo = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vbo);
            GL.BufferData(
                BufferTarget.ArrayBuffer,
                QuadVertices.Length * sizeof(float),
                QuadVertices,
                BufferUsageHint.StaticDraw);
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 2, VertexAttribPointerType.Float, false, 2 * sizeof(float), 0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);

            _glReady = true;
            glChrRom.Invalidate();
        }

        private void glChrRom_Paint(object? sender, PaintEventArgs e)
        {
            if (DesignMode || !_glReady)
            {
                return;
            }

            glChrRom.MakeCurrent();

            GL.Viewport(0, 0, glChrRom.ClientSize.Width, glChrRom.ClientSize.Height);
            GL.ClearColor(Color.Black);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            var chrRom = Nes?.GetChrRom();
            var bank = comboBank.SelectedIndex;

            if (CurrentSection != ChrRom.None &&
                chrRom is { Length: >= 0x2000 } &&
                bank >= 0)
            {
                var bankStart = bank * 0x2000;
                if (bankStart + 0x2000 <= chrRom.Length)
                {
                    var pixels = BuildPixelBuffer(chrRom, bankStart, CurrentSection);

                    GL.UseProgram(_program);
                    GL.ActiveTexture(TextureUnit.Texture0);
                    GL.BindTexture(TextureTarget.Texture2D, _texture);
                    GL.TexSubImage2D(
                        TextureTarget.Texture2D,
                        0,
                        0,
                        0,
                        128,
                        128,
                        PixelFormat.Bgra,
                        PixelType.UnsignedInt8888Rev,
                        pixels);

                    GL.UseProgram(_program);
                    GL.Uniform1(_uPixels, 0);

                    GL.BindVertexArray(_vao);
                    GL.DrawArrays(PrimitiveType.Triangles, 0, 6);
                }
            }

            glChrRom.SwapBuffers();
        }

        private int[] BuildPixelBuffer(byte[] chrRom, int bankStart, ChrRom section)
        {
            var palettes = Nes?.GetPalletes();
            var screenColors = ScreenApi.GetScreenPalette();

            var pixels = new int[16 * 16 * 8 * 8];
            var offset = section == ChrRom.Left ? 0 : 256;

            for (var tileY = 0; tileY < 16; tileY++)
                for (var tileX = 0; tileX < 16; tileX++)
                {
                    var spriteId = offset + tileY * 16 + tileX;
                    var spriteStartAddress = bankStart + spriteId * 16;

                    for (var row = 0; row < 8; row++)
                    {
                        var plane0 = chrRom[spriteStartAddress + row];
                        var plane1 = chrRom[spriteStartAddress + 8 + row];

                        for (var col = 0; col < 8; col++)
                        {
                            var bit = 7 - col;
                            var colorCode = ((plane0 >> bit) & 1)
                                          | (((plane1 >> bit) & 1) << 1);

                            var color = colorCode switch
                            {
                                0 => screenColors[palettes[_selectedPalleteIndex * 4 + 0]],
                                1 => screenColors[palettes[_selectedPalleteIndex * 4 + 1]],
                                2 => screenColors[palettes[_selectedPalleteIndex * 4 + 2]],
                                _ => screenColors[palettes[_selectedPalleteIndex * 4 + 3]]
                            };

                            var pixelX = tileX * 8 + col;
                            var pixelY = 127 - (tileY * 8 + row);

                            var index = (pixelY * 128 + pixelX);

                            pixels[index] = color;

                        }
                    }
                }

            return pixels;
        }

        private void UpdatePalettes()
        {
            var palettes = Nes?.GetPalletes();
            var screenColors = ScreenApi.GetScreenPalette();

            var controls = new[]
            {
                paletteControl1,
                paletteControl2,
                paletteControl3,
                paletteControl4,
                paletteControl5,
                paletteControl6,
                paletteControl7,
                paletteControl8
            };

            var index = 0;
            foreach(var control in controls)
            {
                control.SetColors(new Color[]
                {
                    Color.FromArgb(screenColors[palettes[index + 0]]),
                    Color.FromArgb(screenColors[palettes[index + 1]]),
                    Color.FromArgb(screenColors[palettes[index + 2]]),
                    Color.FromArgb(screenColors[palettes[index + 3]])
                });

                index += 4;
            }
        }

        private void comboBank_SelectedValueChanged(object sender, EventArgs e)
        {
            glChrRom.Invalidate();
        }
    }
}
