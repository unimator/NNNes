
using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NNNES.Emulator.Forms.Proxy;

namespace NNNES.Emulator.Forms
{
    public partial class CpuControl : UserControl
    {
        private readonly ushort _numberOfInstructions = 0x21;
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

        private ushort _disassembledAddress;
        
        public CpuControl()
        {
            InitializeComponent();
            vsbDisassembledScroll.Maximum = ushort.MaxValue;
        }

        public void UpdateState()
        {
            var registers = _nes.GetRegisters();

            foreach(var flag in (CpuFlags[])Enum.GetValues(typeof(CpuFlags)))
            {
                var label = GetLabelControl(flag);
                var flagValue = GetFlagRegisterValue(registers.Status, flag);
                var color = flagValue ? Color.Firebrick : Color.LawnGreen;
                label.ForeColor = color;
            };

            lblAccumulatorValue.Text = registers.Accumulator.ToString("X2");
            lblProgramCounterValue.Text = registers.ProgramCounter.ToString("X4");
            lblStackPointerValue.Text = registers.Stack.ToString("X2");
            lblXValue.Text = registers.X.ToString("X2");
            lblYValue.Text = registers.Y.ToString("X2");

            if (cbFollowPC.Checked)
            {
                SetDisassemblerToProgramCounter();
            }

            RedrawDisassembledCode();
        }

        public void Disassemble()
        {
            _disassembledAddress = _nes.GetRegisters().ProgramCounter;
            cbFollowPC.Checked = true;
            SetDisassemblerToProgramCounter();
            vsbDisassembledScroll.Value = _disassembledAddress;
            RedrawDisassembledCode();
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

        private void lblDisassembled_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                if (_disassembledAddress + 3 > ushort.MaxValue)
                {
                    _disassembledAddress = ushort.MaxValue;
                }
                else
                {
                    _disassembledAddress += 3;
                }
            }
            else if (e.Delta > 0)
            {
                if (_disassembledAddress - 3 < 0)
                {
                    _disassembledAddress = 0;
                }
                else
                {
                    _disassembledAddress -= 3;
                }
            }

            cbFollowPC.Checked = false;
            vsbDisassembledScroll.Value = _disassembledAddress;
            RedrawDisassembledCode();
        }

        private void RedrawDisassembledCode()
        {
            var registers = _nes.GetRegisters();
            var disassembledInstructions = _nes.DisassembleByCount(_disassembledAddress, _numberOfInstructions).OrderBy(instr => instr.Address).ToList();

            var disassembled = new StringBuilder();
            foreach (var instruction in disassembledInstructions)
            {
                var indicator = registers.ProgramCounter == instruction.Address ? "PC >" : "    ";
                var arguments = string.Empty;
                if (instruction.ArgumentsNumber == 1)
                {
                    arguments = $"{{ {instruction.Argument1:X2} }}";
                }
                else if (instruction.ArgumentsNumber == 2)
                {
                    arguments = $"{{ {instruction.Argument1:X2} {instruction.Argument2:X2} }}";
                }
                disassembled.AppendLine($"{indicator} [{instruction.Address:X4}] {instruction.Mnemonic} ({instruction.AddressingMode}) {arguments}");
            }

            lblDisassembled.Text = disassembled.ToString();
        }

        private void vsbDisassembledScroll_Scroll(object sender, ScrollEventArgs e)
        {
            cbFollowPC.Checked = false;
            _disassembledAddress = (ushort)e.NewValue;
            RedrawDisassembledCode();
        }

        private void cbFollowPC_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFollowPC.Checked)
            {
                SetDisassemblerToProgramCounter();
                RedrawDisassembledCode();
            }
        }

        private void SetDisassemblerToProgramCounter()
        {
            _disassembledAddress = _nes.GetRegisters().ProgramCounter;
        }
    }
}
