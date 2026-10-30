namespace NNNES.Emulator.Forms
{
    partial class ExecutionControl
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
            txtRomTitle = new TextBox();
            btnReset = new Button();
            btnSingleStep = new Button();
            btnPause = new Button();
            btnRun = new Button();
            btnLoadRom = new Button();
            btnExit = new Button();
            openRomFileDialog = new OpenFileDialog();
            btnZPMemory = new Button();
            btnNextFrame = new Button();
            SuspendLayout();
            // 
            // txtRomTitle
            // 
            txtRomTitle.BackColor = Color.FromArgb(64, 64, 64);
            txtRomTitle.BorderStyle = BorderStyle.None;
            txtRomTitle.Font = new Font("Malgun Gothic", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtRomTitle.ForeColor = Color.LawnGreen;
            txtRomTitle.Location = new Point(4, 54);
            txtRomTitle.Margin = new Padding(4, 3, 4, 3);
            txtRomTitle.MaxLength = 32768;
            txtRomTitle.Name = "txtRomTitle";
            txtRomTitle.ReadOnly = true;
            txtRomTitle.Size = new Size(184, 15);
            txtRomTitle.TabIndex = 8;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.FromArgb(64, 64, 64);
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.Font = new Font("Malgun Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReset.ForeColor = Color.LawnGreen;
            btnReset.Location = new Point(147, 3);
            btnReset.Margin = new Padding(4, 3, 4, 3);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(41, 40);
            btnReset.TabIndex = 2;
            btnReset.Text = "R";
            btnReset.TextAlign = ContentAlignment.MiddleRight;
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnSingleStep
            // 
            btnSingleStep.BackColor = Color.FromArgb(64, 64, 64);
            btnSingleStep.FlatStyle = FlatStyle.Flat;
            btnSingleStep.Font = new Font("Malgun Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSingleStep.ForeColor = Color.LawnGreen;
            btnSingleStep.Location = new Point(99, 3);
            btnSingleStep.Margin = new Padding(4, 3, 4, 3);
            btnSingleStep.Name = "btnSingleStep";
            btnSingleStep.Size = new Size(41, 40);
            btnSingleStep.TabIndex = 3;
            btnSingleStep.Text = "⤓";
            btnSingleStep.TextAlign = ContentAlignment.MiddleRight;
            btnSingleStep.UseVisualStyleBackColor = true;
            btnSingleStep.Click += btnSingleStep_Click;
            // 
            // btnPause
            // 
            btnPause.BackColor = Color.FromArgb(64, 64, 64);
            btnPause.FlatStyle = FlatStyle.Flat;
            btnPause.Font = new Font("Malgun Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPause.ForeColor = Color.LawnGreen;
            btnPause.Location = new Point(51, 3);
            btnPause.Margin = new Padding(4, 3, 4, 3);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(41, 40);
            btnPause.TabIndex = 4;
            btnPause.Text = "║║";
            btnPause.UseVisualStyleBackColor = false;
            btnPause.Click += btnPause_Click;
            // 
            // btnRun
            // 
            btnRun.BackColor = Color.FromArgb(64, 64, 64);
            btnRun.FlatStyle = FlatStyle.Flat;
            btnRun.Font = new Font("Malgun Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRun.ForeColor = Color.LawnGreen;
            btnRun.Location = new Point(4, 3);
            btnRun.Margin = new Padding(4, 3, 4, 3);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(41, 40);
            btnRun.TabIndex = 5;
            btnRun.Text = "▶";
            btnRun.UseVisualStyleBackColor = false;
            btnRun.Click += btnRun_Click;
            // 
            // btnLoadRom
            // 
            btnLoadRom.BackColor = Color.FromArgb(64, 64, 64);
            btnLoadRom.FlatStyle = FlatStyle.Flat;
            btnLoadRom.Font = new Font("Malgun Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLoadRom.ForeColor = Color.LawnGreen;
            btnLoadRom.Location = new Point(4, 75);
            btnLoadRom.Margin = new Padding(4, 3, 4, 3);
            btnLoadRom.Name = "btnLoadRom";
            btnLoadRom.Size = new Size(107, 40);
            btnLoadRom.TabIndex = 6;
            btnLoadRom.Text = "LOAD ROM";
            btnLoadRom.UseVisualStyleBackColor = false;
            btnLoadRom.Click += btnLoadRom_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(64, 64, 64);
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Malgun Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.ForeColor = Color.LawnGreen;
            btnExit.Location = new Point(119, 75);
            btnExit.Margin = new Padding(4, 3, 4, 3);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(69, 40);
            btnExit.TabIndex = 7;
            btnExit.Text = "QUIT";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // btnZPMemory
            // 
            btnZPMemory.BackColor = Color.FromArgb(64, 64, 64);
            btnZPMemory.FlatStyle = FlatStyle.Flat;
            btnZPMemory.Font = new Font("Malgun Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnZPMemory.ForeColor = Color.LawnGreen;
            btnZPMemory.Location = new Point(196, 74);
            btnZPMemory.Margin = new Padding(4, 3, 4, 3);
            btnZPMemory.Name = "btnZPMemory";
            btnZPMemory.Size = new Size(96, 40);
            btnZPMemory.TabIndex = 9;
            btnZPMemory.Text = "Zero Page";
            btnZPMemory.UseVisualStyleBackColor = true;
            btnZPMemory.Click += btnZPMemory_Click;
            // 
            // btnNextFrame
            // 
            btnNextFrame.BackColor = Color.FromArgb(64, 64, 64);
            btnNextFrame.FlatStyle = FlatStyle.Flat;
            btnNextFrame.Font = new Font("Malgun Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNextFrame.ForeColor = Color.LawnGreen;
            btnNextFrame.Location = new Point(196, 3);
            btnNextFrame.Margin = new Padding(4, 3, 4, 3);
            btnNextFrame.Name = "btnNextFrame";
            btnNextFrame.Size = new Size(41, 40);
            btnNextFrame.TabIndex = 10;
            btnNextFrame.Text = "F";
            btnNextFrame.TextAlign = ContentAlignment.MiddleRight;
            btnNextFrame.UseVisualStyleBackColor = true;
            btnNextFrame.Click += btnNextFrame_Click;
            // 
            // ExecutionControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnNextFrame);
            Controls.Add(btnZPMemory);
            Controls.Add(txtRomTitle);
            Controls.Add(btnReset);
            Controls.Add(btnSingleStep);
            Controls.Add(btnPause);
            Controls.Add(btnRun);
            Controls.Add(btnLoadRom);
            Controls.Add(btnExit);
            Name = "ExecutionControl";
            Size = new Size(296, 119);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtRomTitle;
        private Button btnReset;
        private Button btnSingleStep;
        private Button btnPause;
        private Button btnRun;
        private Button btnLoadRom;
        private Button btnExit;
        private OpenFileDialog openRomFileDialog;
        private Button btnZPMemory;
        private Button btnNextFrame;
    }
}
