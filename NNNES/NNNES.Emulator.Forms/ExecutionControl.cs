using NNNES.Emulator.Proxy;
using System.ComponentModel;

namespace NNNES.Emulator.Forms
{
    public partial class ExecutionControl : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public NesEmulator EmulatorForm { get; set; }


        private Nes _nes;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Nes Nes
        {
            get => _nes;
            set
            {
                _nes = value;
            }
        }

        private ZeroPageMemory _zeroPageMemory;

        public ExecutionControl()
        {
            InitializeComponent();
        }

        private void btnLoadRom_Click(object sender, EventArgs e)
        {
            if (openRomFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            using (var stream = openRomFileDialog.OpenFile())
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                var bytes = memoryStream.ToArray();
                EmulatorForm.Cartridge = new NesCartridge(bytes);
                txtRomTitle.Text = openRomFileDialog.SafeFileName;
            }
            EmulatorForm.Reset();
            UpdateControls();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            EmulatorForm.Close();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            EmulatorForm.Run();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            EmulatorForm.Pause();
            UpdateControls();
        }

        private void btnSingleStep_Click(object sender, EventArgs e)
        {
            _nes.NextInstruction();
            UpdateControls();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _nes.Reset();
            UpdateControls();
        }

        private void btnZPMemory_Click(object sender, EventArgs e)
        {
            if(_zeroPageMemory != null && _zeroPageMemory.Visible)
            {
                _zeroPageMemory.Focus();
            }
            else
            {
                _zeroPageMemory = new ZeroPageMemory();
                _zeroPageMemory.Show();
            }

            UpdateControls();
        }

        private void UpdateControls()
        {
            EmulatorForm.UpdateState();

            if (_zeroPageMemory != null && _zeroPageMemory.Visible)
            {
                var memory = _nes.GetRam(0x0000, 256);
                _zeroPageMemory.UpdateMemory(memory);
            }
        }
    }
}
