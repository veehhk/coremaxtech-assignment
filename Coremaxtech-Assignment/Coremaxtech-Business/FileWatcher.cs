using System.ComponentModel;
using System.Text;

namespace Coremaxtech_Business
{
    /// <summary>
    /// FileWatcher class with change listener that can notify
    /// </summary>
    public class FileWatcher : INotifyPropertyChanged
    {
        private string _value;
        private string _fileName;
        private bool isInitialLoad = true;
        public string TargetFile
        {
            get { return _fileName; } 
            set
            {
                _fileName = value;
                if(File.Exists(_fileName))
                {
                    try
                    {
                        this.Snapshot = File.ReadAllText(_fileName);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// The snapshot holds the last known value of the file
        /// </summary>
        public String Snapshot
        {
            get { return _value; }
            set
            {
                if (_value != value)
                {
                    _value = value;
                    if (this.isInitialLoad)
                    {
                        this.isInitialLoad = false;
                    }
                    else
                    {
                        OnPropertyChanged(nameof(Snapshot));
                    }
                }
            }
        }

        public FileWatcher()
        {
            this._value = string.Empty;
            this.TargetFile = string.Empty;
            this.Snapshot = string.Empty;
            this._fileName = string.Empty;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Finds the actual content change
        /// </summary>
        /// <param name="stateInfo"></param>
        public void SniffChanges(object? stateInfo)
        {
            string currentContent;

            if (string.IsNullOrEmpty(this.TargetFile) || !File.Exists(this.TargetFile))
                return;

            try
            {
                currentContent = File.ReadAllText(this.TargetFile);
            }
            catch (Exception)
            {
                throw;
            }

            StringBuilder changes = new StringBuilder();

            using (StringReader oldReader = new StringReader(this.Snapshot))
            using (StringReader newReader = new StringReader(currentContent))
            {
                string? oldLine;
                string? newLine;

                while ((oldLine = oldReader.ReadLine()) != null && (newLine = newReader.ReadLine()) != null)
                {
                    if (oldLine != newLine)
                    {
                        changes.AppendLine("Changed: " + newLine);
                    }
                }

                while ((newLine = newReader.ReadLine()) != null)
                {
                    changes.AppendLine("Added: " + newLine);
                }
            }
            this.Snapshot = changes.ToString();
        }
    }
}
