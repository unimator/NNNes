namespace NNNES.Emulator.Forms
{
    public partial class PaletteControl : UserControl
    {
        public PaletteControl()
        {
            InitializeComponent();
        }

        public event EventHandler<EventArgs> PaletteSelected;

        public void SetColors(Color[] colors)
        {
            if (colors.Length != 4)
            {
                return;
            }

            panelCol1.BackColor = colors[0];
            panelCol2.BackColor = colors[1];
            panelCol3.BackColor = colors[2];
            panelCol4.BackColor = colors[3];
        }

        private void panelCol_Click(object sender, EventArgs e)
        {
            PaletteSelected?.Invoke(sender, e);
        }
    }
}
