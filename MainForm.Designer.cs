namespace NUnitUpdate
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            FolderPanel = new CodeArtEng.Controls.FolderBrowsePanel();
            BtProcess = new Button();
            diagnosticsTextBox1 = new CodeArtEng.Diagnostics.Controls.DiagnosticsTextBox();
            panel1 = new Panel();
            BtHelp = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // FolderPanel
            // 
            FolderPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            FolderPanel.LabelWidth = 76;
            FolderPanel.Location = new Point(5, 14);
            FolderPanel.Margin = new Padding(5);
            FolderPanel.Name = "FolderPanel";
            FolderPanel.SelectedPath = "";
            FolderPanel.Size = new Size(652, 23);
            FolderPanel.TabIndex = 0;
            FolderPanel.Text = "Select Folder";
            // 
            // BtProcess
            // 
            BtProcess.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtProcess.Location = new Point(658, 12);
            BtProcess.Name = "BtProcess";
            BtProcess.Size = new Size(75, 26);
            BtProcess.TabIndex = 1;
            BtProcess.Text = "Process";
            BtProcess.UseVisualStyleBackColor = true;
            BtProcess.Click += BtProcess_Click;
            // 
            // diagnosticsTextBox1
            // 
            diagnosticsTextBox1.BackColor = Color.FromArgb(30, 30, 30);
            diagnosticsTextBox1.Dock = DockStyle.Fill;
            diagnosticsTextBox1.FlushEnabled = false;
            diagnosticsTextBox1.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            diagnosticsTextBox1.ForeColor = Color.FromArgb(134, 198, 145);
            diagnosticsTextBox1.ListenerEnabled = false;
            diagnosticsTextBox1.Location = new Point(5, 53);
            diagnosticsTextBox1.Multiline = true;
            diagnosticsTextBox1.Name = "diagnosticsTextBox1";
            diagnosticsTextBox1.OutputFile = null;
            diagnosticsTextBox1.OutputFileBackup = null;
            diagnosticsTextBox1.ReadOnly = true;
            diagnosticsTextBox1.RefreshInterval = 50;
            diagnosticsTextBox1.ScrollBars = ScrollBars.Both;
            diagnosticsTextBox1.Size = new Size(817, 533);
            diagnosticsTextBox1.TabIndex = 2;
            diagnosticsTextBox1.Theme = CodeArtEng.Diagnostics.TextBoxTheme.VisualStudio_Green;
            diagnosticsTextBox1.TimeStampFormat = "d/M/yyyy h:mm:ss.fff tt";
            diagnosticsTextBox1.WordWrap = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(BtHelp);
            panel1.Controls.Add(FolderPanel);
            panel1.Controls.Add(BtProcess);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(5, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(817, 48);
            panel1.TabIndex = 3;
            // 
            // BtHelp
            // 
            BtHelp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtHelp.Location = new Point(734, 12);
            BtHelp.Name = "BtHelp";
            BtHelp.Size = new Size(75, 26);
            BtHelp.TabIndex = 2;
            BtHelp.Text = "Help";
            BtHelp.UseVisualStyleBackColor = true;
            BtHelp.Click += BtHelp_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(827, 591);
            Controls.Add(diagnosticsTextBox1);
            Controls.Add(panel1);
            Name = "MainForm";
            Padding = new Padding(5);
            Text = "NUnit Update";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CodeArtEng.Controls.FolderBrowsePanel FolderPanel;
        private Button BtProcess;
        private CodeArtEng.Diagnostics.Controls.DiagnosticsTextBox diagnosticsTextBox1;
        private Panel panel1;
        private Button BtHelp;
    }
}