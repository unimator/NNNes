namespace NNNES.Emulator.Forms
{
    partial class ZeroPageMemory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZeroPageMemory));
            rtbZeroPageRam = new RichTextBox();
            SuspendLayout();
            // 
            // rtbZeroPageRam
            // 
            rtbZeroPageRam.BackColor = Color.FromArgb(83, 83, 83);
            rtbZeroPageRam.Dock = DockStyle.Fill;
            rtbZeroPageRam.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rtbZeroPageRam.ForeColor = Color.LawnGreen;
            rtbZeroPageRam.Location = new Point(0, 0);
            rtbZeroPageRam.Name = "rtbZeroPageRam";
            rtbZeroPageRam.ReadOnly = true;
            rtbZeroPageRam.Size = new Size(682, 348);
            rtbZeroPageRam.TabIndex = 0;
            rtbZeroPageRam.Text = resources.GetString("rtbZeroPageRam.Text");
            // 
            // ZeroPageMemory
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(83, 83, 83);
            ClientSize = new Size(682, 348);
            Controls.Add(rtbZeroPageRam);
            Font = new Font("Cascadia Code", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ForeColor = SystemColors.ActiveCaption;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ZeroPageMemory";
            Text = "Zero Page Memory";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox rtbZeroPageRam;
    }
}