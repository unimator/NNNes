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
            tlpChrRom.SuspendLayout();
            tlpControls.SuspendLayout();
            SuspendLayout();
            // 
            // tlpChrRom
            // 
            tlpChrRom.ColumnCount = 1;
            tlpChrRom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpChrRom.Controls.Add(tlpControls, 0, 0);
            tlpChrRom.Controls.Add(glChrRom, 0, 1);
            tlpChrRom.Dock = DockStyle.Fill;
            tlpChrRom.Location = new Point(0, 0);
            tlpChrRom.Margin = new Padding(4, 3, 4, 3);
            tlpChrRom.Name = "tlpChrRom";
            tlpChrRom.RowCount = 2;
            tlpChrRom.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpChrRom.RowStyles.Add(new RowStyle(SizeType.Absolute, 295F));
            tlpChrRom.Size = new Size(299, 344);
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
            tlpControls.Size = new Size(299, 49);
            tlpControls.TabIndex = 5;
            // 
            // btnChrRomRight
            // 
            btnChrRomRight.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnChrRomRight.BackColor = Color.FromArgb(64, 64, 64);
            btnChrRomRight.FlatStyle = FlatStyle.Flat;
            btnChrRomRight.Font = new Font("Malgun Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnChrRomRight.ForeColor = Color.LawnGreen;
            btnChrRomRight.Location = new Point(202, 3);
            btnChrRomRight.Margin = new Padding(4, 3, 4, 3);
            btnChrRomRight.Name = "btnChrRomRight";
            btnChrRomRight.Size = new Size(93, 43);
            btnChrRomRight.TabIndex = 3;
            btnChrRomRight.Text = "RIGHT";
            btnChrRomRight.UseVisualStyleBackColor = false;
            btnChrRomRight.Click += btnChrRom_Click;
            // 
            // comboBank
            // 
            comboBank.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            comboBank.FormattingEnabled = true;
            comboBank.Location = new Point(103, 3);
            comboBank.Margin = new Padding(4, 3, 4, 3);
            comboBank.Name = "comboBank";
            comboBank.Size = new Size(91, 23);
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
            btnChrRomLeft.Location = new Point(4, 3);
            btnChrRomLeft.Margin = new Padding(4, 3, 4, 3);
            btnChrRomLeft.Name = "btnChrRomLeft";
            btnChrRomLeft.Size = new Size(91, 43);
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
            glChrRom.Location = new Point(0, 49);
            glChrRom.Margin = new Padding(0);
            glChrRom.Name = "glChrRom";
            glChrRom.Profile = OpenTK.Windowing.Common.ContextProfile.Core;
            glChrRom.SharedContext = null;
            glChrRom.Size = new Size(299, 295);
            glChrRom.TabIndex = 6;
            glChrRom.Load += glChrRom_Load;
            glChrRom.Paint += glChrRom_Paint;
            // 
            // ChrRomControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlpChrRom);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ChrRomControl";
            Size = new Size(299, 344);
            tlpChrRom.ResumeLayout(false);
            tlpControls.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpChrRom;
        private System.Windows.Forms.TableLayoutPanel tlpControls;
        private System.Windows.Forms.Button btnChrRomLeft;
        private System.Windows.Forms.ComboBox comboBank;
        private System.Windows.Forms.Button btnChrRomRight;
        private GLControl glChrRom;
    }
}
