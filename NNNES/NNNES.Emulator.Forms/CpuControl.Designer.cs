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
            this.tblFlagRegisters = new System.Windows.Forms.TableLayoutPanel();
            this.lblC = new System.Windows.Forms.Label();
            this.lblZ = new System.Windows.Forms.Label();
            this.lblI = new System.Windows.Forms.Label();
            this.lblD = new System.Windows.Forms.Label();
            this.lblB = new System.Windows.Forms.Label();
            this.lblUnused = new System.Windows.Forms.Label();
            this.lblV = new System.Windows.Forms.Label();
            this.lblN = new System.Windows.Forms.Label();
            this.tblRegisters = new System.Windows.Forms.TableLayoutPanel();
            this.panelRegisters1 = new System.Windows.Forms.Panel();
            this.lblProgramCounter = new System.Windows.Forms.Label();
            this.lblStackPointer = new System.Windows.Forms.Label();
            this.lblAccumulator = new System.Windows.Forms.Label();
            this.panelRegisters2 = new System.Windows.Forms.Panel();
            this.panelRegisters3 = new System.Windows.Forms.Panel();
            this.lblY = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.panelRegisters4 = new System.Windows.Forms.Panel();
            this.lblAccumulatorValue = new System.Windows.Forms.Label();
            this.lblStackPointerValue = new System.Windows.Forms.Label();
            this.lblProgramCounterValue = new System.Windows.Forms.Label();
            this.lblXValue = new System.Windows.Forms.Label();
            this.lblYValue = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tblFlagRegisters.SuspendLayout();
            this.tblRegisters.SuspendLayout();
            this.panelRegisters1.SuspendLayout();
            this.panelRegisters2.SuspendLayout();
            this.panelRegisters3.SuspendLayout();
            this.panelRegisters4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tblRegisters, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(296, 388);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tblFlagRegisters);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(296, 30);
            this.panel1.TabIndex = 0;
            // 
            // tblFlagRegisters
            // 
            this.tblFlagRegisters.BackColor = System.Drawing.Color.Transparent;
            this.tblFlagRegisters.ColumnCount = 8;
            this.tblFlagRegisters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tblFlagRegisters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tblFlagRegisters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tblFlagRegisters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tblFlagRegisters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tblFlagRegisters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tblFlagRegisters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tblFlagRegisters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tblFlagRegisters.Controls.Add(this.lblC, 7, 0);
            this.tblFlagRegisters.Controls.Add(this.lblZ, 6, 0);
            this.tblFlagRegisters.Controls.Add(this.lblI, 5, 0);
            this.tblFlagRegisters.Controls.Add(this.lblD, 4, 0);
            this.tblFlagRegisters.Controls.Add(this.lblB, 3, 0);
            this.tblFlagRegisters.Controls.Add(this.lblUnused, 2, 0);
            this.tblFlagRegisters.Controls.Add(this.lblV, 1, 0);
            this.tblFlagRegisters.Controls.Add(this.lblN, 0, 0);
            this.tblFlagRegisters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblFlagRegisters.Location = new System.Drawing.Point(0, 0);
            this.tblFlagRegisters.Name = "tblFlagRegisters";
            this.tblFlagRegisters.RowCount = 1;
            this.tblFlagRegisters.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblFlagRegisters.Size = new System.Drawing.Size(296, 30);
            this.tblFlagRegisters.TabIndex = 1;
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
            // tblRegisters
            // 
            this.tblRegisters.ColumnCount = 4;
            this.tblRegisters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblRegisters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblRegisters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblRegisters.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblRegisters.Controls.Add(this.panelRegisters1, 0, 0);
            this.tblRegisters.Controls.Add(this.panelRegisters2, 1, 0);
            this.tblRegisters.Controls.Add(this.panelRegisters3, 2, 0);
            this.tblRegisters.Controls.Add(this.panelRegisters4, 3, 0);
            this.tblRegisters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblRegisters.Location = new System.Drawing.Point(3, 33);
            this.tblRegisters.Name = "tblRegisters";
            this.tblRegisters.RowCount = 1;
            this.tblRegisters.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblRegisters.Size = new System.Drawing.Size(290, 50);
            this.tblRegisters.TabIndex = 2;
            // 
            // panelRegisters1
            // 
            this.panelRegisters1.Controls.Add(this.lblProgramCounter);
            this.panelRegisters1.Controls.Add(this.lblStackPointer);
            this.panelRegisters1.Controls.Add(this.lblAccumulator);
            this.panelRegisters1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRegisters1.Location = new System.Drawing.Point(3, 3);
            this.panelRegisters1.Name = "panelRegisters1";
            this.panelRegisters1.Size = new System.Drawing.Size(139, 44);
            this.panelRegisters1.TabIndex = 1;
            // 
            // lblProgramCounter
            // 
            this.lblProgramCounter.AutoSize = true;
            this.lblProgramCounter.Location = new System.Drawing.Point(3, 26);
            this.lblProgramCounter.Name = "lblProgramCounter";
            this.lblProgramCounter.Size = new System.Drawing.Size(88, 13);
            this.lblProgramCounter.TabIndex = 0;
            this.lblProgramCounter.Text = "Program counter:";
            // 
            // lblStackPointer
            // 
            this.lblStackPointer.AutoSize = true;
            this.lblStackPointer.Location = new System.Drawing.Point(3, 13);
            this.lblStackPointer.Name = "lblStackPointer";
            this.lblStackPointer.Size = new System.Drawing.Size(73, 13);
            this.lblStackPointer.TabIndex = 0;
            this.lblStackPointer.Text = "Stack pointer:";
            // 
            // lblAccumulator
            // 
            this.lblAccumulator.AutoSize = true;
            this.lblAccumulator.Location = new System.Drawing.Point(3, 0);
            this.lblAccumulator.Name = "lblAccumulator";
            this.lblAccumulator.Size = new System.Drawing.Size(69, 13);
            this.lblAccumulator.TabIndex = 0;
            this.lblAccumulator.Text = "Accumulator:";
            // 
            // panelRegisters2
            // 
            this.panelRegisters2.Controls.Add(this.lblProgramCounterValue);
            this.panelRegisters2.Controls.Add(this.lblStackPointerValue);
            this.panelRegisters2.Controls.Add(this.lblAccumulatorValue);
            this.panelRegisters2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRegisters2.Location = new System.Drawing.Point(148, 3);
            this.panelRegisters2.Name = "panelRegisters2";
            this.panelRegisters2.Size = new System.Drawing.Size(52, 44);
            this.panelRegisters2.TabIndex = 2;
            // 
            // panelRegisters3
            // 
            this.panelRegisters3.Controls.Add(this.lblY);
            this.panelRegisters3.Controls.Add(this.lblX);
            this.panelRegisters3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRegisters3.Location = new System.Drawing.Point(206, 3);
            this.panelRegisters3.Name = "panelRegisters3";
            this.panelRegisters3.Size = new System.Drawing.Size(23, 44);
            this.panelRegisters3.TabIndex = 2;
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(3, 13);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(17, 13);
            this.lblY.TabIndex = 0;
            this.lblY.Text = "Y:";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(3, 0);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(17, 13);
            this.lblX.TabIndex = 0;
            this.lblX.Text = "X:";
            // 
            // panelRegisters4
            // 
            this.panelRegisters4.Controls.Add(this.lblYValue);
            this.panelRegisters4.Controls.Add(this.lblXValue);
            this.panelRegisters4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRegisters4.Location = new System.Drawing.Point(235, 3);
            this.panelRegisters4.Name = "panelRegisters4";
            this.panelRegisters4.Size = new System.Drawing.Size(52, 44);
            this.panelRegisters4.TabIndex = 2;
            // 
            // lblAccumulatorValue
            // 
            this.lblAccumulatorValue.AutoSize = true;
            this.lblAccumulatorValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccumulatorValue.ForeColor = System.Drawing.Color.White;
            this.lblAccumulatorValue.Location = new System.Drawing.Point(3, 0);
            this.lblAccumulatorValue.Name = "lblAccumulatorValue";
            this.lblAccumulatorValue.Size = new System.Drawing.Size(0, 13);
            this.lblAccumulatorValue.TabIndex = 0;
            // 
            // lblStackPointerValue
            // 
            this.lblStackPointerValue.AutoSize = true;
            this.lblStackPointerValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStackPointerValue.ForeColor = System.Drawing.Color.White;
            this.lblStackPointerValue.Location = new System.Drawing.Point(3, 13);
            this.lblStackPointerValue.Name = "lblStackPointerValue";
            this.lblStackPointerValue.Size = new System.Drawing.Size(0, 13);
            this.lblStackPointerValue.TabIndex = 0;
            // 
            // lblProgramCounterValue
            // 
            this.lblProgramCounterValue.AutoSize = true;
            this.lblProgramCounterValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgramCounterValue.ForeColor = System.Drawing.Color.White;
            this.lblProgramCounterValue.Location = new System.Drawing.Point(3, 26);
            this.lblProgramCounterValue.Name = "lblProgramCounterValue";
            this.lblProgramCounterValue.Size = new System.Drawing.Size(0, 13);
            this.lblProgramCounterValue.TabIndex = 0;
            // 
            // lblXValue
            // 
            this.lblXValue.AutoSize = true;
            this.lblXValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXValue.ForeColor = System.Drawing.Color.White;
            this.lblXValue.Location = new System.Drawing.Point(3, 0);
            this.lblXValue.Name = "lblXValue";
            this.lblXValue.Size = new System.Drawing.Size(0, 13);
            this.lblXValue.TabIndex = 0;
            // 
            // lblYValue
            // 
            this.lblYValue.AutoSize = true;
            this.lblYValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYValue.ForeColor = System.Drawing.Color.White;
            this.lblYValue.Location = new System.Drawing.Point(3, 13);
            this.lblYValue.Name = "lblYValue";
            this.lblYValue.Size = new System.Drawing.Size(0, 13);
            this.lblYValue.TabIndex = 0;
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
            this.tblFlagRegisters.ResumeLayout(false);
            this.tblFlagRegisters.PerformLayout();
            this.tblRegisters.ResumeLayout(false);
            this.panelRegisters1.ResumeLayout(false);
            this.panelRegisters1.PerformLayout();
            this.panelRegisters2.ResumeLayout(false);
            this.panelRegisters2.PerformLayout();
            this.panelRegisters3.ResumeLayout(false);
            this.panelRegisters3.PerformLayout();
            this.panelRegisters4.ResumeLayout(false);
            this.panelRegisters4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tblFlagRegisters;
        private System.Windows.Forms.Label lblC;
        private System.Windows.Forms.Label lblZ;
        private System.Windows.Forms.Label lblI;
        private System.Windows.Forms.Label lblD;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.Label lblUnused;
        private System.Windows.Forms.Label lblV;
        private System.Windows.Forms.Label lblN;
        private System.Windows.Forms.Panel panelRegisters1;
        private System.Windows.Forms.Label lblAccumulator;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblProgramCounter;
        private System.Windows.Forms.Label lblStackPointer;
        private System.Windows.Forms.TableLayoutPanel tblRegisters;
        private System.Windows.Forms.Panel panelRegisters2;
        private System.Windows.Forms.Panel panelRegisters3;
        private System.Windows.Forms.Panel panelRegisters4;
        private System.Windows.Forms.Label lblProgramCounterValue;
        private System.Windows.Forms.Label lblStackPointerValue;
        private System.Windows.Forms.Label lblAccumulatorValue;
        private System.Windows.Forms.Label lblYValue;
        private System.Windows.Forms.Label lblXValue;
    }
}
