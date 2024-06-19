using System.ComponentModel;
using System.Threading;
using System.Threading.Channels;
using System.Timers;
using Coremaxtech_Business;

namespace Coremaxtech_FileWatcher
{
    public partial class FrmFileWatcher : Form
    {
        private System.Threading.Timer? checkTimer;
        private string lastFileContent;
        private FileWatcher fileWatcher;
        public FrmFileWatcher()
        {
            fileWatcher = new FileWatcher();
            lastFileContent = string.Empty;
            fileWatcher.PropertyChanged += FileWatcher_PropertyChanged;
            InitializeComponent();
        }

        private void FileWatcher_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            try
            {
                var observableString = (sender as FileWatcher)?.Snapshot;
                if (observableString != null)
                {
                    if (txtFileChanges.InvokeRequired)
                    {
                        txtFileChanges.Invoke(new Action(() =>
                        {
                            txtFileChanges.AppendText("Changes detected at " + DateTime.Now.ToString() + Environment.NewLine);
                            txtFileChanges.AppendText(observableString + Environment.NewLine);
                        }));
                    }
                    else
                    {
                        txtFileChanges.AppendText("Changes detected at " + DateTime.Now.ToString() + Environment.NewLine);
                        txtFileChanges.AppendText(observableString + Environment.NewLine);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            try
            {
                switch (ofdWatcher.ShowDialog())
                {
                    case DialogResult.Cancel:
                        txtTargetFile.Text = string.Empty;
                        fileWatcher.TargetFile = txtTargetFile.Text;
                        checkTimer?.Dispose();
                        txtFileChanges.Text = "No target file selected. File watcher stopped.!";
                        break;
                    case DialogResult.OK:
                        var autoResetEvent = new AutoResetEvent(false);
                        txtTargetFile.Text = ofdWatcher.FileName;
                        fileWatcher.TargetFile = txtTargetFile.Text;
                        txtFileChanges.Text = string.Empty;
                        checkTimer = new System.Threading.Timer(fileWatcher.SniffChanges, autoResetEvent, 15000, 15000);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
