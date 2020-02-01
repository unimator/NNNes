namespace NNNES.Emulator.Forms
{
    partial class NesEmulator
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.glNesWindow = new OpenTK.GLControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLoadRom = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.glChrRom = new OpenTK.GLControl();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnChrRomLeft = new System.Windows.Forms.Button();
            this.btnChrRomRight = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.comboBank = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 518F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.glNesWindow, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(14, 14);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 486F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(786, 626);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // glNesWindow
            // 
            this.glNesWindow.BackColor = System.Drawing.Color.Black;
            this.glNesWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glNesWindow.Location = new System.Drawing.Point(3, 3);
            this.glNesWindow.Name = "glNesWindow";
            this.glNesWindow.Size = new System.Drawing.Size(512, 480);
            this.glNesWindow.TabIndex = 1;
            this.glNesWindow.VSync = false;
            this.glNesWindow.Load += new System.EventHandler(this.glNesWindow_Load);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLoadRom);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 489);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(512, 134);
            this.panel1.TabIndex = 2;
            // 
            // btnLoadRom
            // 
            this.btnLoadRom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadRom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLoadRom.FlatAppearance.BorderSize = 0;
            this.btnLoadRom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadRom.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadRom.ForeColor = System.Drawing.Color.LawnGreen;
            this.btnLoadRom.Location = new System.Drawing.Point(315, 96);
            this.btnLoadRom.Name = "btnLoadRom";
            this.btnLoadRom.Size = new System.Drawing.Size(94, 35);
            this.btnLoadRom.TabIndex = 0;
            this.btnLoadRom.Text = "LOAD ROM";
            this.btnLoadRom.UseVisualStyleBackColor = false;
            this.btnLoadRom.Click += new System.EventHandler(this.btnLoadRom_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.LawnGreen;
            this.btnExit.Location = new System.Drawing.Point(415, 96);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 35);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "QUIT";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(521, 3);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.tableLayoutPanel1.SetRowSpan(this.panel2, 2);
            this.panel2.Size = new System.Drawing.Size(262, 620);
            this.panel2.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.glChrRom, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.78212F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.217877F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 255F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(256, 614);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // glChrRom
            // 
            this.glChrRom.BackColor = System.Drawing.Color.Black;
            this.glChrRom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glChrRom.Location = new System.Drawing.Point(0, 358);
            this.glChrRom.Margin = new System.Windows.Forms.Padding(0);
            this.glChrRom.Name = "glChrRom";
            this.glChrRom.Size = new System.Drawing.Size(256, 256);
            this.glChrRom.TabIndex = 3;
            this.glChrRom.VSync = false;
            this.glChrRom.Load += new System.EventHandler(this.glChrRom_Load);
            this.glChrRom.Paint += new System.Windows.Forms.PaintEventHandler(this.glChrRom_Paint);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Controls.Add(this.btnChrRomLeft, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnChrRomRight, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.comboBank, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 328);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(250, 27);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // btnChrRomLeft
            // 
            this.btnChrRomLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnChrRomLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChrRomLeft.FlatAppearance.BorderSize = 0;
            this.btnChrRomLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChrRomLeft.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChrRomLeft.ForeColor = System.Drawing.Color.LawnGreen;
            this.btnChrRomLeft.Location = new System.Drawing.Point(3, 3);
            this.btnChrRomLeft.Name = "btnChrRomLeft";
            this.btnChrRomLeft.Size = new System.Drawing.Size(77, 21);
            this.btnChrRomLeft.TabIndex = 0;
            this.btnChrRomLeft.Text = "LEFT";
            this.btnChrRomLeft.UseVisualStyleBackColor = false;
            this.btnChrRomLeft.Click += new System.EventHandler(this.btnSwitchChrRom);
            // 
            // btnChrRomRight
            // 
            this.btnChrRomRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnChrRomRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChrRomRight.FlatAppearance.BorderSize = 0;
            this.btnChrRomRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChrRomRight.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChrRomRight.ForeColor = System.Drawing.Color.LawnGreen;
            this.btnChrRomRight.Location = new System.Drawing.Point(169, 3);
            this.btnChrRomRight.Name = "btnChrRomRight";
            this.btnChrRomRight.Size = new System.Drawing.Size(78, 21);
            this.btnChrRomRight.TabIndex = 0;
            this.btnChrRomRight.Text = "RIGHT";
            this.btnChrRomRight.UseVisualStyleBackColor = false;
            this.btnChrRomRight.Click += new System.EventHandler(this.btnSwitchChrRom);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "NES ROMs|*.nes";
            // 
            // comboBank
            // 
            this.comboBank.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBank.FormattingEnabled = true;
            this.comboBank.Location = new System.Drawing.Point(86, 3);
            this.comboBank.Name = "comboBank";
            this.comboBank.Size = new System.Drawing.Size(77, 21);
            this.comboBank.TabIndex = 1;
            this.comboBank.SelectedValueChanged += new System.EventHandler(this.comboBank_SelectedValueChanged);
            // 
            // NesEmulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ClientSize = new System.Drawing.Size(814, 654);
            this.Controls.Add(this.tableLayoutPanel1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NesEmulator";
            this.Padding = new System.Windows.Forms.Padding(14);
            this.Text = "NES Emulator";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NesEmulator_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NesEmulator_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.NesEmulator_MouseUp);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private OpenTK.GLControl glNesWindow;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLoadRom;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private OpenTK.GLControl glChrRom;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnChrRomLeft;
        private System.Windows.Forms.Button btnChrRomRight;
        private System.Windows.Forms.ComboBox comboBank;
    }
}

