using OpenTK.GLControl;

namespace NNNES.Emulator.Forms
{
    partial class ChrRomControl
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
            tlpChrRom = new TableLayoutPanel();
            tlpControls = new TableLayoutPanel();
            btnChrRomRight = new Button();
            comboBank = new ComboBox();
            btnChrRomLeft = new Button();
            glChrRom = new GLControl();
            tlpPalettes = new TableLayoutPanel();
            paletteControl1 = new PaletteControl();
            paletteControl2 = new PaletteControl();
            paletteControl3 = new PaletteControl();
            paletteControl4 = new PaletteControl();
            paletteControl5 = new PaletteControl();
            paletteControl6 = new PaletteControl();
            paletteControl7 = new PaletteControl();
            paletteControl8 = new PaletteControl();
            tlpChrRom.SuspendLayout();
            tlpControls.SuspendLayout();
            tlpPalettes.SuspendLayout();
            SuspendLayout();
            // 
            // tlpChrRom
            // 
            tlpChrRom.ColumnCount = 1;
            tlpChrRom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpChrRom.Controls.Add(tlpControls, 0, 0);
            tlpChrRom.Controls.Add(glChrRom, 0, 2);
            tlpChrRom.Controls.Add(tlpPalettes, 0, 1);
            tlpChrRom.Dock = DockStyle.Fill;
            tlpChrRom.Location = new Point(0, 0);
            tlpChrRom.Margin = new Padding(4, 3, 4, 3);
            tlpChrRom.Name = "tlpChrRom";
            tlpChrRom.RowCount = 3;
            tlpChrRom.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpChrRom.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            tlpChrRom.RowStyles.Add(new RowStyle(SizeType.Absolute, 295F));
            tlpChrRom.Size = new Size(299, 386);
            tlpChrRom.TabIndex = 0;
            // 
            // tlpControls
            // 
            tlpControls.BackColor = Color.Transparent;
            tlpControls.ColumnCount = 3;
            tlpControls.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tlpControls.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tlpControls.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tlpControls.Controls.Add(btnChrRomRight, 0, 0);
            tlpControls.Controls.Add(comboBank, 0, 0);
            tlpControls.Controls.Add(btnChrRomLeft, 0, 0);
            tlpControls.Dock = DockStyle.Fill;
            tlpControls.Location = new Point(0, 0);
            tlpControls.Margin = new Padding(0);
            tlpControls.Name = "tlpControls";
            tlpControls.RowCount = 1;
            tlpControls.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpControls.Size = new Size(299, 35);
            tlpControls.TabIndex = 5;
            // 
            // btnChrRomRight
            // 
            btnChrRomRight.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnChrRomRight.BackColor = Color.FromArgb(64, 64, 64);
            btnChrRomRight.FlatStyle = FlatStyle.Flat;
            btnChrRomRight.Font = new Font("Malgun Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnChrRomRight.ForeColor = Color.LawnGreen;
            btnChrRomRight.Location = new Point(198, 0);
            btnChrRomRight.Margin = new Padding(0);
            btnChrRomRight.Name = "btnChrRomRight";
            btnChrRomRight.Size = new Size(101, 35);
            btnChrRomRight.TabIndex = 3;
            btnChrRomRight.Text = "RIGHT";
            btnChrRomRight.UseVisualStyleBackColor = false;
            btnChrRomRight.Click += btnChrRom_Click;
            // 
            // comboBank
            // 
            comboBank.Dock = DockStyle.Fill;
            comboBank.FormattingEnabled = true;
            comboBank.Location = new Point(99, 0);
            comboBank.Margin = new Padding(0);
            comboBank.Name = "comboBank";
            comboBank.Size = new Size(99, 23);
            comboBank.TabIndex = 2;
            comboBank.SelectedValueChanged += comboBank_SelectedValueChanged;
            // 
            // btnChrRomLeft
            // 
            btnChrRomLeft.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnChrRomLeft.BackColor = Color.FromArgb(64, 64, 64);
            btnChrRomLeft.FlatStyle = FlatStyle.Flat;
            btnChrRomLeft.Font = new Font("Malgun Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnChrRomLeft.ForeColor = Color.LawnGreen;
            btnChrRomLeft.Location = new Point(0, 0);
            btnChrRomLeft.Margin = new Padding(0);
            btnChrRomLeft.Name = "btnChrRomLeft";
            btnChrRomLeft.Size = new Size(99, 35);
            btnChrRomLeft.TabIndex = 1;
            btnChrRomLeft.Text = "LEFT";
            btnChrRomLeft.UseVisualStyleBackColor = false;
            btnChrRomLeft.Click += btnChrRom_Click;
            // 
            // glChrRom
            // 
            glChrRom.API = OpenTK.Windowing.Common.ContextAPI.OpenGL;
            glChrRom.APIVersion = new Version(3, 3, 0, 0);
            glChrRom.BackColor = Color.Black;
            glChrRom.Dock = DockStyle.Fill;
            glChrRom.Flags = OpenTK.Windowing.Common.ContextFlags.Default;
            glChrRom.IsEventDriven = true;
            glChrRom.Location = new Point(0, 91);
            glChrRom.Margin = new Padding(0);
            glChrRom.Name = "glChrRom";
            glChrRom.Profile = OpenTK.Windowing.Common.ContextProfile.Core;
            glChrRom.SharedContext = null;
            glChrRom.Size = new Size(299, 295);
            glChrRom.TabIndex = 6;
            glChrRom.Load += glChrRom_Load;
            glChrRom.Paint += glChrRom_Paint;
            // 
            // tlpPalettes
            // 
            tlpPalettes.ColumnCount = 4;
            tlpPalettes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpPalettes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpPalettes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpPalettes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpPalettes.Controls.Add(paletteControl1, 0, 0);
            tlpPalettes.Controls.Add(paletteControl2, 1, 0);
            tlpPalettes.Controls.Add(paletteControl3, 2, 0);
            tlpPalettes.Controls.Add(paletteControl4, 3, 0);
            tlpPalettes.Controls.Add(paletteControl5, 0, 1);
            tlpPalettes.Controls.Add(paletteControl6, 1, 1);
            tlpPalettes.Controls.Add(paletteControl7, 2, 1);
            tlpPalettes.Controls.Add(paletteControl8, 3, 1);
            tlpPalettes.Dock = DockStyle.Fill;
            tlpPalettes.Location = new Point(0, 35);
            tlpPalettes.Margin = new Padding(0);
            tlpPalettes.Name = "tlpPalettes";
            tlpPalettes.RowCount = 2;
            tlpPalettes.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpPalettes.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpPalettes.Size = new Size(299, 56);
            tlpPalettes.TabIndex = 7;
            // 
            // paletteControl1
            // 
            paletteControl1.Dock = DockStyle.Fill;
            paletteControl1.Location = new Point(3, 3);
            paletteControl1.Name = "paletteControl1";
            paletteControl1.Size = new Size(68, 22);
            paletteControl1.TabIndex = 0;
            // 
            // paletteControl2
            // 
            paletteControl2.Dock = DockStyle.Fill;
            paletteControl2.Location = new Point(77, 3);
            paletteControl2.Name = "paletteControl2";
            paletteControl2.Size = new Size(68, 22);
            paletteControl2.TabIndex = 1;
            // 
            // paletteControl3
            // 
            paletteControl3.Dock = DockStyle.Fill;
            paletteControl3.Location = new Point(151, 3);
            paletteControl3.Name = "paletteControl3";
            paletteControl3.Size = new Size(68, 22);
            paletteControl3.TabIndex = 2;
            // 
            // paletteControl4
            // 
            paletteControl4.Dock = DockStyle.Fill;
            paletteControl4.Location = new Point(225, 3);
            paletteControl4.Name = "paletteControl4";
            paletteControl4.Size = new Size(71, 22);
            paletteControl4.TabIndex = 3;
            // 
            // paletteControl5
            // 
            paletteControl5.Dock = DockStyle.Fill;
            paletteControl5.Location = new Point(3, 31);
            paletteControl5.Name = "paletteControl5";
            paletteControl5.Size = new Size(68, 22);
            paletteControl5.TabIndex = 4;
            // 
            // paletteControl6
            // 
            paletteControl6.Dock = DockStyle.Fill;
            paletteControl6.Location = new Point(77, 31);
            paletteControl6.Name = "paletteControl6";
            paletteControl6.Size = new Size(68, 22);
            paletteControl6.TabIndex = 5;
            // 
            // paletteControl7
            // 
            paletteControl7.Dock = DockStyle.Fill;
            paletteControl7.Location = new Point(151, 31);
            paletteControl7.Name = "paletteControl7";
            paletteControl7.Size = new Size(68, 22);
            paletteControl7.TabIndex = 6;
            // 
            // paletteControl8
            // 
            paletteControl8.Dock = DockStyle.Fill;
            paletteControl8.Location = new Point(225, 31);
            paletteControl8.Name = "paletteControl8";
            paletteControl8.Size = new Size(71, 22);
            paletteControl8.TabIndex = 7;
            // 
            // ChrRomControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlpChrRom);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ChrRomControl";
            Size = new Size(299, 386);
            tlpChrRom.ResumeLayout(false);
            tlpControls.ResumeLayout(false);
            tlpPalettes.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpChrRom;
        private System.Windows.Forms.TableLayoutPanel tlpControls;
        private System.Windows.Forms.Button btnChrRomLeft;
        private System.Windows.Forms.ComboBox comboBank;
        private System.Windows.Forms.Button btnChrRomRight;
        private GLControl glChrRom;
        private TableLayoutPanel tlpPalettes;
        private PaletteControl paletteControl1;
        private PaletteControl paletteControl2;
        private PaletteControl paletteControl3;
        private PaletteControl paletteControl4;
        private PaletteControl paletteControl5;
        private PaletteControl paletteControl6;
        private PaletteControl paletteControl7;
        private PaletteControl paletteControl8;
    }
}
