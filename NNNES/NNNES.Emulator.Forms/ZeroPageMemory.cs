using System.Text;

namespace NNNES.Emulator.Forms
{
    public partial class ZeroPageMemory : Form
    {
        public ZeroPageMemory()
        {
            InitializeComponent();
        }

        public void UpdateMemory(byte[] memory)
        {
            if (memory.Length != 256)
            {
                throw new ArgumentException("Memory array must be of length 256.");
            }

            var sb = new StringBuilder();

            for (int i = 0; i < 256 / 16; i++)
            {
                sb.Append($"0x00{i * 16:X2}:  " + string.Join("  ", memory.Skip(i * 16).Take(16).Select(b => b.ToString("X2"))));
                sb.AppendLine();
            }

            rtbZeroPageRam.Text = sb.ToString();
        }
    }
}
