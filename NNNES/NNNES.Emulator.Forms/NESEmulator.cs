using NNNES.Emulator.Proxy;
using OpenTK.Graphics.OpenGL;
using System.ComponentModel;

namespace NNNES.Emulator.Forms
{
    public partial class NesEmulator : Form
    {
        private NesCartridge _nesCartridge;


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public NesCartridge Cartridge
        {
            get => _nesCartridge;
            set
            {
                _nesCartridge = value;
                _nes.SetCartridge(_nesCartridge);
                chrRomControl.Nes = _nes;
            }
        }

        private readonly Nes _nes;

        private int _frameTexture;
        private int _vao;
        private int _shaderProgram;

        private bool _frameUploaded;

        public NesEmulator()
        {
            InitializeComponent();
            _nes = new Nes();
            cpuControl.Nes = _nes;
            executionControl.Nes = _nes;
            executionControl.EmulatorForm = this;
            cpuControl.Enabled = false;
        }

        public void Run()
        {
            if (!bwEmulator.IsBusy)
            {
                bwEmulator.RunWorkerAsync();
            }
        }

        public void Pause()
        {
            UpdateState();
            bwEmulator.CancelAsync();
        }

        public void Reset()
        {
            _nes.Reset();
            cpuControl.Enabled = true;
            cpuControl.Disassemble();
            UpdateState();
        }

        public void UpdateState()
        {
            cpuControl.UpdateState();
            chrRomControl.UpdateState();
            if (_nes.IsFrameReady())
            {
                glNesWindow.Invalidate();
            }
        }

        private void glNesWindow_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            glNesWindow.MakeCurrent();
            InitializeFrameRenderer();

            glNesWindow.Paint += (o, args) =>
            {
                glNesWindow.MakeCurrent();

                var framePtr = _nes.GetFramePtr();
                if (framePtr == IntPtr.Zero)
                    return;

                GL.Viewport(0, 0, glNesWindow.ClientSize.Width, glNesWindow.ClientSize.Height);

                GL.PixelStore(PixelStoreParameter.UnpackAlignment, 4);
                GL.ActiveTexture(TextureUnit.Texture0);
                GL.BindTexture(TextureTarget.Texture2D, _frameTexture);

                if (!_frameUploaded)
                {
                    GL.TexImage2D(
                        TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba8,
                        256, 240, 0, PixelFormat.Bgra, PixelType.UnsignedInt8888Rev,
                        framePtr);
                    _frameUploaded = true;
                }
                else
                {
                    GL.TexSubImage2D(
                        TextureTarget.Texture2D, 0, 0, 0,
                        256, 240, PixelFormat.Bgra, PixelType.UnsignedInt8888Rev,
                        framePtr);
                }

                GL.Clear(ClearBufferMask.ColorBufferBit);
                GL.UseProgram(_shaderProgram);
                GL.BindVertexArray(_vao);
                GL.DrawArrays(PrimitiveType.Triangles, 0, 3);

                glNesWindow.SwapBuffers();
            };
        }

        private void bwEmulator_DoWork(object sender, DoWorkEventArgs e)
        {
            var bg = (BackgroundWorker)sender;
            while (true)
            {
                if (bg.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                lock (_nes)
                {
                    _nes.Clock();
                    if (_nes.IsFrameReady())
                    {
                        glNesWindow.Invalidate();
                    }
                }
            }
        }

        private static int CompileShader(ShaderType type, string source)
        {
            var shader = GL.CreateShader(type);
            GL.ShaderSource(shader, source);
            GL.CompileShader(shader);

            if (GL.GetShaderInfoLog(shader) is { Length: > 0 } log)
                throw new InvalidOperationException($"Shader compilation failed: {log}");

            return shader;
        }

        private void InitializeFrameRenderer()
        {
            const string vertexSource = """
        #version 330 core
        out vec2 uv;

        void main()
        {
            vec2 position = vec2(
                (gl_VertexID == 1) ? 3.0 : -1.0,
                (gl_VertexID == 2) ? 3.0 : -1.0);

            gl_Position = vec4(position, 0.0, 1.0);
            uv = (position + 1.0) * 0.5;
        }
        """;

            const string fragmentSource = """
        #version 330 core
        uniform sampler2D frameTexture;
        in vec2 uv;
        out vec4 color;

        void main()
        {
            color = texture(frameTexture, vec2(uv.x, 1.0 - uv.y));
        }
        """;

            var vertexShader = CompileShader(ShaderType.VertexShader, vertexSource);
            var fragmentShader = CompileShader(ShaderType.FragmentShader, fragmentSource);

            _shaderProgram = GL.CreateProgram();
            GL.AttachShader(_shaderProgram, vertexShader);
            GL.AttachShader(_shaderProgram, fragmentShader);
            GL.LinkProgram(_shaderProgram);

            var linkLog = GL.GetProgramInfoLog(_shaderProgram);
            if (!string.IsNullOrWhiteSpace(linkLog))
                throw new InvalidOperationException($"Shader link failed: {linkLog}");

            GL.DeleteShader(vertexShader);
            GL.DeleteShader(fragmentShader);

            // Core profile requires a VAO, even though this renderer has no vertex attributes.
            _vao = GL.GenVertexArray();
            GL.BindVertexArray(_vao);

            _frameTexture = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, _frameTexture);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.ClampToEdge);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.ClampToEdge);

            GL.UseProgram(_shaderProgram);
            GL.Uniform1(GL.GetUniformLocation(_shaderProgram, "frameTexture"), 0);
        }

        private void glNesWindow_Paint(object sender, PaintEventArgs e)
        {
            if (DesignMode)
            {
            }
        }
    }
}