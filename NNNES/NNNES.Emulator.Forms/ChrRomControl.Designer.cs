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
            this.tlpChrRom = new System.Windows.Forms.TableLayoutPanel();
            this.tlpControls = new System.Windows.Forms.TableLayoutPanel();
            this.btnChrRomRight = new System.Windows.Forms.Button();
            this.comboBank = new System.Windows.Forms.ComboBox();
            this.btnChrRomLeft = new System.Windows.Forms.Button();
            this.glChrRom = new OpenTK.GLControl();
            this.tlpChrRom.SuspendLayout();
            this.tlpControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpChrRom
            // 
            this.tlpChrRom.ColumnCount = 1;
            this.tlpChrRom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpChrRom.Controls.Add(this.tlpControls, 0, 0);
            this.tlpChrRom.Controls.Add(this.glChrRom, 0, 1);
            this.tlpChrRom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpChrRom.Location = new System.Drawing.Point(0, 0);
            this.tlpChrRom.Name = "tlpChrRom";
            this.tlpChrRom.RowCount = 2;
            this.tlpChrRom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpChrRom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 256F));
            this.tlpChrRom.Size = new System.Drawing.Size(256, 298);
            this.tlpChrRom.TabIndex = 0;
            // 
            // tlpControls
            // 
            this.tlpControls.BackColor = System.Drawing.Color.Transparent;
            this.tlpControls.ColumnCount = 3;
            this.tlpControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpControls.Controls.Add(this.btnChrRomRight, 0, 0);
            this.tlpControls.Controls.Add(this.comboBank, 0, 0);
            this.tlpControls.Controls.Add(this.btnChrRomLeft, 0, 0);
            this.tlpControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpControls.Location = new System.Drawing.Point(0, 0);
            this.tlpControls.Margin = new System.Windows.Forms.Padding(0);
            this.tlpControls.Name = "tlpControls";
            this.tlpControls.RowCount = 1;
            this.tlpControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpControls.Size = new System.Drawing.Size(256, 42);
            this.tlpControls.TabIndex = 5;
            // 
            // btnChrRomRight
            // 
            this.btnChrRomRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChrRomRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnChrRomRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChrRomRight.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChrRomRight.ForeColor = System.Drawing.Color.LawnGreen;
            this.btnChrRomRight.Location = new System.Drawing.Point(173, 3);
            this.btnChrRomRight.Name = "btnChrRomRight";
            this.btnChrRomRight.Size = new System.Drawing.Size(80, 36);
            this.btnChrRomRight.TabIndex = 3;
            this.btnChrRomRight.Text = "RIGHT";
            this.btnChrRomRight.UseVisualStyleBackColor = false;
            this.btnChrRomRight.Click += new System.EventHandler(this.btnChrRom_Click);
            // 
            // comboBank
            // 
            this.comboBank.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBank.FormattingEnabled = true;
            this.comboBank.Location = new System.Drawing.Point(88, 3);
            this.comboBank.Name = "comboBank";
            this.comboBank.Size = new System.Drawing.Size(79, 21);
            this.comboBank.TabIndex = 2;
            this.comboBank.SelectedValueChanged += new System.EventHandler(this.comboBank_SelectedValueChanged);
            // 
            // btnChrRomLeft
            // 
            this.btnChrRomLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChrRomLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnChrRomLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChrRomLeft.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChrRomLeft.ForeColor = System.Drawing.Color.LawnGreen;
            this.btnChrRomLeft.Location = new System.Drawing.Point(3, 3);
            this.btnChrRomLeft.Name = "btnChrRomLeft";
            this.btnChrRomLeft.Size = new System.Drawing.Size(79, 36);
            this.btnChrRomLeft.TabIndex = 1;
            this.btnChrRomLeft.Text = "LEFT";
            this.btnChrRomLeft.UseVisualStyleBackColor = false;
            this.btnChrRomLeft.Click += new System.EventHandler(this.btnChrRom_Click);
            // 
            // glChrRom
            // 
            this.glChrRom.BackColor = System.Drawing.Color.Black;
            this.glChrRom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glChrRom.Location = new System.Drawing.Point(0, 42);
            this.glChrRom.Margin = new System.Windows.Forms.Padding(0);
            this.glChrRom.Name = "glChrRom";
            this.glChrRom.Size = new System.Drawing.Size(256, 256);
            this.glChrRom.TabIndex = 6;
            this.glChrRom.VSync = false;
            this.glChrRom.Load += new System.EventHandler(this.glChrRom_Load);
            this.glChrRom.Paint += new System.Windows.Forms.PaintEventHandler(this.glChrRom_Paint);
            // 
            // ChrRomControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpChrRom);
            this.Name = "ChrRomControl";
            this.Size = new System.Drawing.Size(256, 298);
            this.tlpChrRom.ResumeLayout(false);
            this.tlpControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpChrRom;
        private System.Windows.Forms.TableLayoutPanel tlpControls;
        private System.Windows.Forms.Button btnChrRomLeft;
        private System.Windows.Forms.ComboBox comboBank;
        private System.Windows.Forms.Button btnChrRomRight;
        private OpenTK.GLControl glChrRom;
    }
}
