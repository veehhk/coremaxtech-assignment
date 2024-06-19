namespace Coremaxtech_FileWatcher
{
    partial class FrmFileWatcher
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
            txtTargetFile = new TextBox();
            btnChooseFile = new Button();
            lblTitle = new Label();
            txtFileChanges = new TextBox();
            ofdWatcher = new OpenFileDialog();
            SuspendLayout();
            // 
            // txtTargetFile
            // 
            txtTargetFile.BackColor = SystemColors.Window;
            txtTargetFile.Location = new Point(157, 93);
            txtTargetFile.Name = "txtTargetFile";
            txtTargetFile.ReadOnly = true;
            txtTargetFile.Size = new Size(411, 23);
            txtTargetFile.TabIndex = 0;
            // 
            // btnChooseFile
            // 
            btnChooseFile.Location = new Point(568, 93);
            btnChooseFile.Name = "btnChooseFile";
            btnChooseFile.Size = new Size(75, 23);
            btnChooseFile.TabIndex = 1;
            btnChooseFile.Text = "Watch File";
            btnChooseFile.UseVisualStyleBackColor = true;
            btnChooseFile.Click += btnChooseFile_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTitle.Location = new Point(319, 33);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(162, 15);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Core Max Tech File Watcher";
            // 
            // txtFileChanges
            // 
            txtFileChanges.Location = new Point(157, 161);
            txtFileChanges.Multiline = true;
            txtFileChanges.Name = "txtFileChanges";
            txtFileChanges.ScrollBars = ScrollBars.Vertical;
            txtFileChanges.Size = new Size(486, 211);
            txtFileChanges.TabIndex = 3;
            // 
            // ofdWatcher
            // 
            ofdWatcher.FileName = "openFileDialog1";
            ofdWatcher.Filter = "Text Files|*.txt";
            // 
            // FrmFileWatcher
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 411);
            Controls.Add(txtFileChanges);
            Controls.Add(lblTitle);
            Controls.Add(btnChooseFile);
            Controls.Add(txtTargetFile);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmFileWatcher";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Coremaxtech File Watcher";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtTargetFile;
        private Button btnChooseFile;
        private Label lblTitle;
        private TextBox txtFileChanges;
        private OpenFileDialog ofdWatcher;
    }
}
