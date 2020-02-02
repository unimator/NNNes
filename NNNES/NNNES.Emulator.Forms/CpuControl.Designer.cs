namespace NNNES.Emulator.Forms
{
    partial class CpuControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblN = new System.Windows.Forms.Label();
            this.lblV = new System.Windows.Forms.Label();
            this.lblUnused = new System.Windows.Forms.Label();
            this.lblB = new System.Windows.Forms.Label();
            this.lblD = new System.Windows.Forms.Label();
            this.lblI = new System.Windows.Forms.Label();
            this.lblZ = new System.Windows.Forms.Label();
            this.lblC = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(296, 388);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(296, 30);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.Controls.Add(this.lblC, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblZ, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblI, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblD, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblB, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblUnused, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblV, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblN, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(296, 30);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // lblN
            // 
            this.lblN.AutoSize = true;
            this.lblN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblN.ForeColor = System.Drawing.Color.LawnGreen;
            this.lblN.Location = new System.Drawing.Point(3, 0);
            this.lblN.Name = "lblN";
            this.lblN.Size = new System.Drawing.Size(31, 30);
            this.lblN.TabIndex = 2;
            this.lblN.Text = "N";
            this.lblN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblV
            // 
            this.lblV.AutoSize = true;
            this.lblV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblV.ForeColor = System.Drawing.Color.LawnGreen;
            this.lblV.Location = new System.Drawing.Point(40, 0);
            this.lblV.Name = "lblV";
            this.lblV.Size = new System.Drawing.Size(31, 30);
            this.lblV.TabIndex = 3;
            this.lblV.Text = "V";
            this.lblV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUnused
            // 
            this.lblUnused.AutoSize = true;
            this.lblUnused.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUnused.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblUnused.ForeColor = System.Drawing.Color.LawnGreen;
            this.lblUnused.Location = new System.Drawing.Point(77, 0);
            this.lblUnused.Name = "lblUnused";
            this.lblUnused.Size = new System.Drawing.Size(31, 30);
            this.lblUnused.TabIndex = 4;
            this.lblUnused.Text = "-";
            this.lblUnused.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblB
            // 
            this.lblB.AutoSize = true;
            this.lblB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblB.ForeColor = System.Drawing.Color.LawnGreen;
            this.lblB.Location = new System.Drawing.Point(114, 0);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(31, 30);
            this.lblB.TabIndex = 5;
            this.lblB.Text = "B";
            this.lblB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblD
            // 
            this.lblD.AutoSize = true;
            this.lblD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblD.ForeColor = System.Drawing.Color.LawnGreen;
            this.lblD.Location = new System.Drawing.Point(151, 0);
            this.lblD.Name = "lblD";
            this.lblD.Size = new System.Drawing.Size(31, 30);
            this.lblD.TabIndex = 6;
            this.lblD.Text = "D";
            this.lblD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblI
            // 
            this.lblI.AutoSize = true;
            this.lblI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblI.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblI.ForeColor = System.Drawing.Color.LawnGreen;
            this.lblI.Location = new System.Drawing.Point(188, 0);
            this.lblI.Name = "lblI";
            this.lblI.Size = new System.Drawing.Size(31, 30);
            this.lblI.TabIndex = 7;
            this.lblI.Text = "I";
            this.lblI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblZ
            // 
            this.lblZ.AutoSize = true;
            this.lblZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblZ.ForeColor = System.Drawing.Color.LawnGreen;
            this.lblZ.Location = new System.Drawing.Point(225, 0);
            this.lblZ.Name = "lblZ";
            this.lblZ.Size = new System.Drawing.Size(31, 30);
            this.lblZ.TabIndex = 8;
            this.lblZ.Text = "Z";
            this.lblZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblC
            // 
            this.lblC.AutoSize = true;
            this.lblC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblC.ForeColor = System.Drawing.Color.LawnGreen;
            this.lblC.Location = new System.Drawing.Point(262, 0);
            this.lblC.Name = "lblC";
            this.lblC.Size = new System.Drawing.Size(31, 30);
            this.lblC.TabIndex = 9;
            this.lblC.Text = "C";
            this.lblC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CpuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CpuControl";
            this.Size = new System.Drawing.Size(296, 388);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblC;
        private System.Windows.Forms.Label lblZ;
        private System.Windows.Forms.Label lblI;
        private System.Windows.Forms.Label lblD;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.Label lblUnused;
        private System.Windows.Forms.Label lblV;
        private System.Windows.Forms.Label lblN;
    }
}
