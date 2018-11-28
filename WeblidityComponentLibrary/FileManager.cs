using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeblidityComponentLibrary
{
    public partial class FileManager : Component
    {
        private string _fileName;

        public string FileName { get { return _fileName; } set { _fileName = value; OnFilenameChanged(new EventArgs()); } }

        protected virtual void OnFilenameChanged(EventArgs e)
        {
            FilenameChanged?.Invoke(this, e);
        }

        public SaveFileDialog SaveFileDialog { get; set; } = new SaveFileDialog();

        public ChangeDetector ChangeDetector { get; set; } = new ChangeDetector();

        public event EventHandler<CreatingFileEventArgs> CreatingFile;
        public event EventHandler<CreateFileEventArgs> CreateFile;
        public event EventHandler<CreatedFileEventArgs> CreatedFile;

        public event EventHandler FilenameChanged;

        public event EventHandler<SavingFileEventArgs> SavingFile;
        public event EventHandler<SaveFileEventArgs> SaveFile;
        public event EventHandler<SavedFileEventArgs> SavedFile;

        public FileManager()
        {
            InitializeComponent();
        }

        public FileManager(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public bool SaveApplicationFile()
        {
            return SaveAsApplicationFile(ChangeDetector.Changed);
        }

        public bool SaveAsApplicationFile(bool askFile)
        {
            return SaveAsApplicationFile(FileName, askFile);
        }

        private bool SaveAsApplicationFile(string filename, bool askFile)
        {
            if (string.IsNullOrEmpty(filename) || askFile)
            {
                SaveFileDialog.FileName = filename;
                if (SaveFileDialog.ShowDialog().Equals(DialogResult.OK))
                {
                    FileName = SaveFileDialog.FileName;

                    var savingApplicationFileEventArgs = new SavingFileEventArgs(FileName);
                    OnSavingFile(savingApplicationFileEventArgs);
                    if (!savingApplicationFileEventArgs.Cancel)
                    {
                        var saveApplicationFileEventArgs = new SaveFileEventArgs(FileName);
                        OnSaveFile(saveApplicationFileEventArgs);

                        bool failed = saveApplicationFileEventArgs.Failed;
                        var savedApplicationEventArgs = new SavedFileEventArgs(saveApplicationFileEventArgs.Filename, failed);
                        OnSavedFile(savedApplicationEventArgs);

                        FileName = saveApplicationFileEventArgs.Filename;
                        if (!savedApplicationEventArgs.Failed)
                        {
                            ChangeDetector.Changed = false;
                        }

                        return !savedApplicationEventArgs.Failed;
                    }
                }
            }

            return false;
        }

        public bool NewApplicationFile()
        {
            if (SaveApplicationFile() || true)
            {
                string suggestedFilename = GetSuggestedFilename();
                var creatingFileEventArgs = new CreatingFileEventArgs(suggestedFilename);
                OnCreatingFile(creatingFileEventArgs);
                if (!creatingFileEventArgs.Cancel)
                {
                    var createFileEventArgs = new CreateFileEventArgs() { Failed = false, FileName = creatingFileEventArgs.FileName };
                    OnCreateFile(createFileEventArgs);

                    var failed = createFileEventArgs.Failed;
                    var createdFileEventArgs = new CreatedFileEventArgs(failed);
                    OnCreatedFile(createdFileEventArgs);

                    FileName = createFileEventArgs.FileName;

                    return !createdFileEventArgs.Failed;
                }
            }

            return false;
        }

        private string GetSuggestedFilename()
        {
            return "MyNewFile.phf";
        }

        protected virtual void OnCreatedFile(CreatedFileEventArgs e)
        {
            CreatedFile?.Invoke(this, e);
        }

        protected virtual void OnCreateFile(CreateFileEventArgs e)
        {
            CreateFile?.Invoke(this, e);
        }

        protected virtual void OnCreatingFile(CreatingFileEventArgs e)
        {
            CreatingFile?.Invoke(this, e);
        }

        public bool SaveAsApplicationFile()
        {
            return SaveAsApplicationFile(true);
        }

        protected virtual void OnSaveFile(SaveFileEventArgs e)
        {
            SaveFile?.Invoke(this, e);
        }

        protected virtual void OnSavedFile(SavedFileEventArgs e)
        {
            SavedFile?.Invoke(this, e);
        }

        protected virtual void OnSavingFile(SavingFileEventArgs e)
        {
            SavingFile?.Invoke(this, e);
        }
    }
}
