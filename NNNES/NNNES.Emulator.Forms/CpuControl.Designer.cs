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
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            tblFlagRegisters = new TableLayoutPanel();
            lblC = new Label();
            lblZ = new Label();
            lblI = new Label();
            lblD = new Label();
            lblB = new Label();
            lblUnused = new Label();
            lblV = new Label();
            lblN = new Label();
            tblRegisters = new TableLayoutPanel();
            panelRegisters1 = new Panel();
            cbFollowPC = new CheckBox();
            lblProgramCounter = new Label();
            lblStackPointer = new Label();
            lblAccumulator = new Label();
            panelRegisters2 = new Panel();
            lblProgramCounterValue = new Label();
            lblStackPointerValue = new Label();
            lblAccumulatorValue = new Label();
            panelRegisters3 = new Panel();
            lblY = new Label();
            lblX = new Label();
            panelRegisters4 = new Panel();
            lblYValue = new Label();
            lblXValue = new Label();
            panelDisassembled = new Panel();
            vsbDisassembledScroll = new VScrollBar();
            lblDisassembled = new Label();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            tblFlagRegisters.SuspendLayout();
            tblRegisters.SuspendLayout();
            panelRegisters1.SuspendLayout();
            panelRegisters2.SuspendLayout();
            panelRegisters3.SuspendLayout();
            panelRegisters4.SuspendLayout();
            panelDisassembled.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(tblRegisters, 0, 1);
            tableLayoutPanel1.Controls.Add(panelDisassembled, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 87F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));
            tableLayoutPanel1.Size = new Size(345, 448);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(tblFlagRegisters);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(345, 35);
            panel1.TabIndex = 0;
            // 
            // tblFlagRegisters
            // 
            tblFlagRegisters.BackColor = Color.Transparent;
            tblFlagRegisters.ColumnCount = 8;
            tblFlagRegisters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tblFlagRegisters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tblFlagRegisters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tblFlagRegisters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tblFlagRegisters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tblFlagRegisters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tblFlagRegisters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tblFlagRegisters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tblFlagRegisters.Controls.Add(lblC, 7, 0);
            tblFlagRegisters.Controls.Add(lblZ, 6, 0);
            tblFlagRegisters.Controls.Add(lblI, 5, 0);
            tblFlagRegisters.Controls.Add(lblD, 4, 0);
            tblFlagRegisters.Controls.Add(lblB, 3, 0);
            tblFlagRegisters.Controls.Add(lblUnused, 2, 0);
            tblFlagRegisters.Controls.Add(lblV, 1, 0);
            tblFlagRegisters.Controls.Add(lblN, 0, 0);
            tblFlagRegisters.Dock = DockStyle.Fill;
            tblFlagRegisters.Location = new Point(0, 0);
            tblFlagRegisters.Margin = new Padding(4, 3, 4, 3);
            tblFlagRegisters.Name = "tblFlagRegisters";
            tblFlagRegisters.RowCount = 1;
            tblFlagRegisters.RowStyles.Add(new RowStyle());
            tblFlagRegisters.Size = new Size(345, 35);
            tblFlagRegisters.TabIndex = 1;
            // 
            // lblC
            // 
            lblC.AutoSize = true;
            lblC.Dock = DockStyle.Fill;
            lblC.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lblC.ForeColor = Color.LawnGreen;
            lblC.Location = new Point(305, 0);
            lblC.Margin = new Padding(4, 0, 4, 0);
            lblC.Name = "lblC";
            lblC.Size = new Size(36, 35);
            lblC.TabIndex = 9;
            lblC.Text = "C";
            lblC.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblZ
            // 
            lblZ.AutoSize = true;
            lblZ.Dock = DockStyle.Fill;
            lblZ.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lblZ.ForeColor = Color.LawnGreen;
            lblZ.Location = new Point(262, 0);
            lblZ.Margin = new Padding(4, 0, 4, 0);
            lblZ.Name = "lblZ";
            lblZ.Size = new Size(35, 35);
            lblZ.TabIndex = 8;
            lblZ.Text = "Z";
            lblZ.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblI
            // 
            lblI.AutoSize = true;
            lblI.Dock = DockStyle.Fill;
            lblI.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lblI.ForeColor = Color.LawnGreen;
            lblI.Location = new Point(219, 0);
            lblI.Margin = new Padding(4, 0, 4, 0);
            lblI.Name = "lblI";
            lblI.Size = new Size(35, 35);
            lblI.TabIndex = 7;
            lblI.Text = "I";
            lblI.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblD
            // 
            lblD.AutoSize = true;
            lblD.Dock = DockStyle.Fill;
            lblD.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lblD.ForeColor = Color.LawnGreen;
            lblD.Location = new Point(176, 0);
            lblD.Margin = new Padding(4, 0, 4, 0);
            lblD.Name = "lblD";
            lblD.Size = new Size(35, 35);
            lblD.TabIndex = 6;
            lblD.Text = "D";
            lblD.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblB
            // 
            lblB.AutoSize = true;
            lblB.Dock = DockStyle.Fill;
            lblB.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lblB.ForeColor = Color.LawnGreen;
            lblB.Location = new Point(133, 0);
            lblB.Margin = new Padding(4, 0, 4, 0);
            lblB.Name = "lblB";
            lblB.Size = new Size(35, 35);
            lblB.TabIndex = 5;
            lblB.Text = "B";
            lblB.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUnused
            // 
            lblUnused.AutoSize = true;
            lblUnused.Dock = DockStyle.Fill;
            lblUnused.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lblUnused.ForeColor = Color.LawnGreen;
            lblUnused.Location = new Point(90, 0);
            lblUnused.Margin = new Padding(4, 0, 4, 0);
            lblUnused.Name = "lblUnused";
            lblUnused.Size = new Size(35, 35);
            lblUnused.TabIndex = 4;
            lblUnused.Text = "-";
            lblUnused.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblV
            // 
            lblV.AutoSize = true;
            lblV.Dock = DockStyle.Fill;
            lblV.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lblV.ForeColor = Color.LawnGreen;
            lblV.Location = new Point(47, 0);
            lblV.Margin = new Padding(4, 0, 4, 0);
            lblV.Name = "lblV";
            lblV.Size = new Size(35, 35);
            lblV.TabIndex = 3;
            lblV.Text = "V";
            lblV.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblN
            // 
            lblN.AutoSize = true;
            lblN.Dock = DockStyle.Fill;
            lblN.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lblN.ForeColor = Color.LawnGreen;
            lblN.Location = new Point(4, 0);
            lblN.Margin = new Padding(4, 0, 4, 0);
            lblN.Name = "lblN";
            lblN.Size = new Size(35, 35);
            lblN.TabIndex = 2;
            lblN.Text = "N";
            lblN.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tblRegisters
            // 
            tblRegisters.ColumnCount = 4;
            tblRegisters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblRegisters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblRegisters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tblRegisters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblRegisters.Controls.Add(panelRegisters1, 0, 0);
            tblRegisters.Controls.Add(panelRegisters2, 1, 0);
            tblRegisters.Controls.Add(panelRegisters3, 2, 0);
            tblRegisters.Controls.Add(panelRegisters4, 3, 0);
            tblRegisters.Dock = DockStyle.Fill;
            tblRegisters.Location = new Point(4, 38);
            tblRegisters.Margin = new Padding(4, 3, 4, 3);
            tblRegisters.Name = "tblRegisters";
            tblRegisters.RowCount = 1;
            tblRegisters.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblRegisters.Size = new Size(337, 81);
            tblRegisters.TabIndex = 2;
            // 
            // panelRegisters1
            // 
            panelRegisters1.Controls.Add(cbFollowPC);
            panelRegisters1.Controls.Add(lblProgramCounter);
            panelRegisters1.Controls.Add(lblStackPointer);
            panelRegisters1.Controls.Add(lblAccumulator);
            panelRegisters1.Dock = DockStyle.Fill;
            panelRegisters1.Location = new Point(4, 3);
            panelRegisters1.Margin = new Padding(4, 3, 4, 3);
            panelRegisters1.Name = "panelRegisters1";
            panelRegisters1.Size = new Size(160, 75);
            panelRegisters1.TabIndex = 1;
            // 
            // cbFollowPC
            // 
            cbFollowPC.AutoSize = true;
            cbFollowPC.Location = new Point(7, 50);
            cbFollowPC.Margin = new Padding(4, 3, 4, 3);
            cbFollowPC.Name = "cbFollowPC";
            cbFollowPC.Size = new Size(79, 19);
            cbFollowPC.TabIndex = 1;
            cbFollowPC.Text = "Follow PC";
            cbFollowPC.UseVisualStyleBackColor = true;
            cbFollowPC.CheckedChanged += cbFollowPC_CheckedChanged;
            // 
            // lblProgramCounter
            // 
            lblProgramCounter.AutoSize = true;
            lblProgramCounter.Location = new Point(4, 30);
            lblProgramCounter.Margin = new Padding(4, 0, 4, 0);
            lblProgramCounter.Name = "lblProgramCounter";
            lblProgramCounter.Size = new Size(100, 15);
            lblProgramCounter.TabIndex = 0;
            lblProgramCounter.Text = "Program counter:";
            // 
            // lblStackPointer
            // 
            lblStackPointer.AutoSize = true;
            lblStackPointer.Location = new Point(4, 15);
            lblStackPointer.Margin = new Padding(4, 0, 4, 0);
            lblStackPointer.Name = "lblStackPointer";
            lblStackPointer.Size = new Size(79, 15);
            lblStackPointer.TabIndex = 0;
            lblStackPointer.Text = "Stack pointer:";
            // 
            // lblAccumulator
            // 
            lblAccumulator.AutoSize = true;
            lblAccumulator.Location = new Point(4, 0);
            lblAccumulator.Margin = new Padding(4, 0, 4, 0);
            lblAccumulator.Name = "lblAccumulator";
            lblAccumulator.Size = new Size(79, 15);
            lblAccumulator.TabIndex = 0;
            lblAccumulator.Text = "Accumulator:";
            // 
            // panelRegisters2
            // 
            panelRegisters2.Controls.Add(lblProgramCounterValue);
            panelRegisters2.Controls.Add(lblStackPointerValue);
            panelRegisters2.Controls.Add(lblAccumulatorValue);
            panelRegisters2.Dock = DockStyle.Fill;
            panelRegisters2.Location = new Point(172, 3);
            panelRegisters2.Margin = new Padding(4, 3, 4, 3);
            panelRegisters2.Name = "panelRegisters2";
            panelRegisters2.Size = new Size(59, 75);
            panelRegisters2.TabIndex = 2;
            // 
            // lblProgramCounterValue
            // 
            lblProgramCounterValue.AutoSize = true;
            lblProgramCounterValue.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProgramCounterValue.ForeColor = Color.White;
            lblProgramCounterValue.Location = new Point(4, 30);
            lblProgramCounterValue.Margin = new Padding(4, 0, 4, 0);
            lblProgramCounterValue.Name = "lblProgramCounterValue";
            lblProgramCounterValue.Size = new Size(0, 13);
            lblProgramCounterValue.TabIndex = 0;
            // 
            // lblStackPointerValue
            // 
            lblStackPointerValue.AutoSize = true;
            lblStackPointerValue.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStackPointerValue.ForeColor = Color.White;
            lblStackPointerValue.Location = new Point(4, 15);
            lblStackPointerValue.Margin = new Padding(4, 0, 4, 0);
            lblStackPointerValue.Name = "lblStackPointerValue";
            lblStackPointerValue.Size = new Size(0, 13);
            lblStackPointerValue.TabIndex = 0;
            // 
            // lblAccumulatorValue
            // 
            lblAccumulatorValue.AutoSize = true;
            lblAccumulatorValue.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAccumulatorValue.ForeColor = Color.White;
            lblAccumulatorValue.Location = new Point(4, 0);
            lblAccumulatorValue.Margin = new Padding(4, 0, 4, 0);
            lblAccumulatorValue.Name = "lblAccumulatorValue";
            lblAccumulatorValue.Size = new Size(0, 13);
            lblAccumulatorValue.TabIndex = 0;
            // 
            // panelRegisters3
            // 
            panelRegisters3.Controls.Add(lblY);
            panelRegisters3.Controls.Add(lblX);
            panelRegisters3.Dock = DockStyle.Fill;
            panelRegisters3.Location = new Point(239, 3);
            panelRegisters3.Margin = new Padding(4, 3, 4, 3);
            panelRegisters3.Name = "panelRegisters3";
            panelRegisters3.Size = new Size(25, 75);
            panelRegisters3.TabIndex = 2;
            // 
            // lblY
            // 
            lblY.AutoSize = true;
            lblY.Location = new Point(4, 15);
            lblY.Margin = new Padding(4, 0, 4, 0);
            lblY.Name = "lblY";
            lblY.Size = new Size(17, 15);
            lblY.TabIndex = 0;
            lblY.Text = "Y:";
            // 
            // lblX
            // 
            lblX.AutoSize = true;
            lblX.Location = new Point(4, 0);
            lblX.Margin = new Padding(4, 0, 4, 0);
            lblX.Name = "lblX";
            lblX.Size = new Size(17, 15);
            lblX.TabIndex = 0;
            lblX.Text = "X:";
            // 
            // panelRegisters4
            // 
            panelRegisters4.Controls.Add(lblYValue);
            panelRegisters4.Controls.Add(lblXValue);
            panelRegisters4.Dock = DockStyle.Fill;
            panelRegisters4.Location = new Point(272, 3);
            panelRegisters4.Margin = new Padding(4, 3, 4, 3);
            panelRegisters4.Name = "panelRegisters4";
            panelRegisters4.Size = new Size(61, 75);
            panelRegisters4.TabIndex = 2;
            // 
            // lblYValue
            // 
            lblYValue.AutoSize = true;
            lblYValue.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblYValue.ForeColor = Color.White;
            lblYValue.Location = new Point(4, 15);
            lblYValue.Margin = new Padding(4, 0, 4, 0);
            lblYValue.Name = "lblYValue";
            lblYValue.Size = new Size(0, 13);
            lblYValue.TabIndex = 0;
            // 
            // lblXValue
            // 
            lblXValue.AutoSize = true;
            lblXValue.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblXValue.ForeColor = Color.White;
            lblXValue.Location = new Point(4, 0);
            lblXValue.Margin = new Padding(4, 0, 4, 0);
            lblXValue.Name = "lblXValue";
            lblXValue.Size = new Size(0, 13);
            lblXValue.TabIndex = 0;
            // 
            // panelDisassembled
            // 
            panelDisassembled.AutoScroll = true;
            panelDisassembled.BorderStyle = BorderStyle.FixedSingle;
            panelDisassembled.Controls.Add(vsbDisassembledScroll);
            panelDisassembled.Controls.Add(lblDisassembled);
            panelDisassembled.Dock = DockStyle.Fill;
            panelDisassembled.Location = new Point(4, 125);
            panelDisassembled.Margin = new Padding(4, 3, 4, 3);
            panelDisassembled.Name = "panelDisassembled";
            panelDisassembled.Size = new Size(337, 320);
            panelDisassembled.TabIndex = 3;
            // 
            // vsbDisassembledScroll
            // 
            vsbDisassembledScroll.Dock = DockStyle.Right;
            vsbDisassembledScroll.LargeChange = 3;
            vsbDisassembledScroll.Location = new Point(318, 0);
            vsbDisassembledScroll.Maximum = 65535;
            vsbDisassembledScroll.Name = "vsbDisassembledScroll";
            vsbDisassembledScroll.Size = new Size(17, 318);
            vsbDisassembledScroll.SmallChange = 3;
            vsbDisassembledScroll.TabIndex = 4;
            vsbDisassembledScroll.Scroll += vsbDisassembledScroll_Scroll;
            // 
            // lblDisassembled
            // 
            lblDisassembled.AutoSize = true;
            lblDisassembled.Dock = DockStyle.Fill;
            lblDisassembled.Font = new Font("Lucida Console", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDisassembled.Location = new Point(0, 0);
            lblDisassembled.Margin = new Padding(4, 0, 4, 0);
            lblDisassembled.Name = "lblDisassembled";
            lblDisassembled.Size = new Size(0, 11);
            lblDisassembled.TabIndex = 3;
            lblDisassembled.MouseWheel += lblDisassembled_MouseWheel;
            // 
            // CpuControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "CpuControl";
            Size = new Size(345, 448);
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            tblFlagRegisters.ResumeLayout(false);
            tblFlagRegisters.PerformLayout();
            tblRegisters.ResumeLayout(false);
            panelRegisters1.ResumeLayout(false);
            panelRegisters1.PerformLayout();
            panelRegisters2.ResumeLayout(false);
            panelRegisters2.PerformLayout();
            panelRegisters3.ResumeLayout(false);
            panelRegisters3.PerformLayout();
            panelRegisters4.ResumeLayout(false);
            panelRegisters4.PerformLayout();
            panelDisassembled.ResumeLayout(false);
            panelDisassembled.PerformLayout();
            ResumeLayout(false);

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
        private System.Windows.Forms.Label lblDisassembled;
        private System.Windows.Forms.Panel panelDisassembled;
        private System.Windows.Forms.VScrollBar vsbDisassembledScroll;
        private System.Windows.Forms.CheckBox cbFollowPC;
    }
}
