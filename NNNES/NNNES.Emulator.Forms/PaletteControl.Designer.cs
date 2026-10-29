namespace NNNES.Emulator.Forms
{
    partial class PaletteControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tlpPalette = new TableLayoutPanel();
            panelCol1 = new Panel();
            panelCol2 = new Panel();
            panelCol3 = new Panel();
            panelCol4 = new Panel();
            tlpPalette.SuspendLayout();
            SuspendLayout();
            // 
            // tlpPalette
            // 
            tlpPalette.ColumnCount = 4;
            tlpPalette.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpPalette.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpPalette.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpPalette.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpPalette.Controls.Add(panelCol1, 0, 0);
            tlpPalette.Controls.Add(panelCol2, 1, 0);
            tlpPalette.Controls.Add(panelCol3, 2, 0);
            tlpPalette.Controls.Add(panelCol4, 3, 0);
            tlpPalette.Cursor = Cursors.Hand;
            tlpPalette.Dock = DockStyle.Fill;
            tlpPalette.Location = new Point(0, 0);
            tlpPalette.Name = "tlpPalette";
            tlpPalette.RowCount = 1;
            tlpPalette.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpPalette.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpPalette.Size = new Size(106, 24);
            tlpPalette.TabIndex = 0;
            // 
            // panelCol1
            // 
            panelCol1.Location = new Point(0, 0);
            panelCol1.Margin = new Padding(0);
            panelCol1.Name = "panelCol1";
            panelCol1.Size = new Size(26, 24);
            panelCol1.TabIndex = 0;
            panelCol1.Click += panelCol_Click;
            // 
            // panelCol2
            // 
            panelCol2.Location = new Point(26, 0);
            panelCol2.Margin = new Padding(0);
            panelCol2.Name = "panelCol2";
            panelCol2.Size = new Size(26, 24);
            panelCol2.TabIndex = 1;
            panelCol2.Click += panelCol_Click;
            // 
            // panelCol3
            // 
            panelCol3.Location = new Point(52, 0);
            panelCol3.Margin = new Padding(0);
            panelCol3.Name = "panelCol3";
            panelCol3.Size = new Size(26, 24);
            panelCol3.TabIndex = 2;
            panelCol3.Click += panelCol_Click;
            // 
            // panelCol4
            // 
            panelCol4.Location = new Point(78, 0);
            panelCol4.Margin = new Padding(0);
            panelCol4.Name = "panelCol4";
            panelCol4.Size = new Size(28, 24);
            panelCol4.TabIndex = 3;
            panelCol4.Click += panelCol_Click;
            // 
            // PaletteControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlpPalette);
            Name = "PaletteControl";
            Size = new Size(106, 24);
            tlpPalette.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpPalette;
        private Panel panelCol1;
        private Panel panelCol2;
        private Panel panelCol3;
        private Panel panelCol4;
    }
}
