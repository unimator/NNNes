using OpenTK.GLControl;

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
            components = new System.ComponentModel.Container();
            tableLayoutPanel1 = new TableLayoutPanel();
            glNesWindow = new GLControl();
            panel1 = new Panel();
            tableLayoutPanel3 = new TableLayoutPanel();
            panel3 = new Panel();
            executionControl = new ExecutionControl();
            panel2 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            chrRomControl = new ChrRomControl();
            cpuControl = new CpuControl();
            bwEmulator = new System.ComponentModel.BackgroundWorker();
            timer1 = new System.Windows.Forms.Timer(components);
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 776F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(glNesWindow, 0, 0);
            tableLayoutPanel1.Controls.Add(panel1, 0, 1);
            tableLayoutPanel1.Controls.Add(panel2, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(16, 16);
            tableLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 728F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1099, 869);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // glNesWindow
            // 
            glNesWindow.API = OpenTK.Windowing.Common.ContextAPI.OpenGL;
            glNesWindow.APIVersion = new Version(3, 3, 0, 0);
            glNesWindow.BackColor = Color.Black;
            glNesWindow.Dock = DockStyle.Fill;
            glNesWindow.Flags = OpenTK.Windowing.Common.ContextFlags.Default;
            glNesWindow.IsEventDriven = true;
            glNesWindow.Location = new Point(4, 3);
            glNesWindow.Margin = new Padding(4, 3, 4, 3);
            glNesWindow.Name = "glNesWindow";
            glNesWindow.Profile = OpenTK.Windowing.Common.ContextProfile.Core;
            glNesWindow.SharedContext = null;
            glNesWindow.Size = new Size(768, 722);
            glNesWindow.TabIndex = 1;
            glNesWindow.Load += glNesWindow_Load;
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel3);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(4, 731);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(768, 135);
            panel1.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel3.Controls.Add(panel3, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(768, 135);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(executionControl);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(464, 3);
            panel3.Margin = new Padding(4, 3, 4, 3);
            panel3.Name = "panel3";
            panel3.RightToLeft = RightToLeft.No;
            panel3.Size = new Size(300, 129);
            panel3.TabIndex = 0;
            // 
            // executionControl
            // 
            executionControl.Dock = DockStyle.Fill;
            executionControl.Location = new Point(0, 0);
            executionControl.Name = "executionControl";
            executionControl.Size = new Size(300, 129);
            executionControl.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(tableLayoutPanel2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(780, 3);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(4, 3, 4, 3);
            tableLayoutPanel1.SetRowSpan(panel2, 2);
            panel2.Size = new Size(315, 863);
            panel2.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(chrRomControl, 0, 1);
            tableLayoutPanel2.Controls.Add(cpuControl, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(4, 3);
            tableLayoutPanel2.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 333F));
            tableLayoutPanel2.Size = new Size(307, 857);
            tableLayoutPanel2.TabIndex = 4;
            // 
            // chrRomControl
            // 
            chrRomControl.Dock = DockStyle.Fill;
            chrRomControl.Location = new Point(0, 524);
            chrRomControl.Margin = new Padding(0);
            chrRomControl.Name = "chrRomControl";
            chrRomControl.Size = new Size(307, 333);
            chrRomControl.TabIndex = 0;
            // 
            // cpuControl
            // 
            cpuControl.BackColor = Color.Transparent;
            cpuControl.Dock = DockStyle.Fill;
            cpuControl.ForeColor = Color.LawnGreen;
            cpuControl.Location = new Point(5, 3);
            cpuControl.Margin = new Padding(5, 3, 5, 3);
            cpuControl.Name = "cpuControl";
            cpuControl.Size = new Size(297, 518);
            cpuControl.TabIndex = 1;
            // 
            // bwEmulator
            // 
            bwEmulator.WorkerReportsProgress = true;
            bwEmulator.WorkerSupportsCancellation = true;
            bwEmulator.DoWork += bwEmulator_DoWork;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            // 
            // NesEmulator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(83, 83, 83);
            ClientSize = new Size(1131, 901);
            Controls.Add(tableLayoutPanel1);
            ForeColor = SystemColors.ActiveCaption;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "NesEmulator";
            Padding = new Padding(16);
            Text = "NES Emulator";
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private GLControl glNesWindow;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private ChrRomControl chrRomControl;
        private CpuControl cpuControl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel3;
        private System.ComponentModel.BackgroundWorker bwEmulator;
        private System.Windows.Forms.Timer timer1;
        private ExecutionControl executionControl;
    }
}

