using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using NNNES.Emulator.Forms.Proxy;
using OpenTK.Graphics.OpenGL;

namespace NNNES.Emulator.Forms
{
    public partial class NesEmulator : Form
    {
        private NesCartridge _nesCartridge;
        private Nes _nes;

        public NesEmulator()
        {
            InitializeComponent();
            _nes = new Nes();
            cpuControl.Nes = _nes;
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
        
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLoadRom_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var stream = openFileDialog.OpenFile())
                using (var memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    var bytes = memoryStream.ToArray();
                    _nesCartridge = new NesCartridge(bytes);
                    chrRomControl.NesCartridge = _nesCartridge;
                    txtRomTitle.Text = openFileDialog.SafeFileName;
                    _nes.SetCartridge(_nesCartridge);
                }
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (!bwEmulator.IsBusy)
            {
                bwEmulator.RunWorkerAsync();
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            cpuControl.UpdateRegisters();
            bwEmulator.CancelAsync();
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
                }
            }
        }

        private void bwEmulator_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }
    }
}