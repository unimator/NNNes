
using System.Windows.Forms;
using NNNES.Emulator.Forms.Proxy;

namespace NNNES.Emulator.Forms
{
    public partial class CpuControl : UserControl
    {


        private Nes _nes;
        public Nes Nes
        {
            get => _nes;
            set
            {
                _nes = value;
                if (value == null)
                {
                    return;
                }

                var x = _nes.Registers;
            }
        }

        public CpuControl()
        {
            InitializeComponent();
        }
    }
}
