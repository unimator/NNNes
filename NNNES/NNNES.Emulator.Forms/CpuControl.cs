
using System;
using System.Drawing;
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
            }
        }

        public CpuControl()
        {
            InitializeComponent();
        }

        public void UpdateRegisters()
        {
            var registers = _nes.GetRegisters();

            foreach(var flag in (CpuFlags[])Enum.GetValues(typeof(CpuFlags)))
            {
                var label = GetLabelControl(flag);
                var flagValue = GetFlagRegisterValue(registers.Status, flag);
                var color = flagValue ? Color.Firebrick : Color.LawnGreen;
                label.ForeColor = color;
            };

            lblAccumulatorValue.Text = registers.Accumulator.ToString();
            lblProgramCounterValue.Text = registers.ProgramCounter.ToString();
            lblStackPointerValue.Text = registers.Stack.ToString();
            lblXValue.Text = registers.X.ToString();
            lblYValue.Text = registers.Y.ToString();
        }

        private bool GetFlagRegisterValue(byte status, CpuFlags flag) => (status & (byte) flag) != 0;

        private Label GetLabelControl(CpuFlags flag)
        {
            switch (flag)
            {
                case CpuFlags.C:
                    return lblC;
                case CpuFlags.Z:
                    return lblZ;
                case CpuFlags.I:
                    return lblI;
                case CpuFlags.D:
                    return lblD;
                case CpuFlags.B:
                    return lblB;
                case CpuFlags.U:
                    return lblUnused;
                case CpuFlags.V:
                    return lblV;
                case CpuFlags.N:
                    return lblN;
                default:
                    throw new ArgumentOutOfRangeException(nameof(flag), flag, null);
            }
        }
    }
}
