//------------------------------------------------------------------------------
// <copyright file="FileManager.cs" company="Ion Gireada">
//      Copyright (c) Ion Gireada. All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace WeblidityComponentLibrary
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="FileManager" />
    /// </summary>
    public partial class FileManager : Component
    {
        /// <summary>
        /// Defines the _fileName
        /// </summary>
        private string _fileName;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileManager"/> class.
        /// </summary>
        public FileManager()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileManager"/> class.
        /// </summary>
        /// <param name="container">The container<see cref="IContainer"/></param>
        public FileManager(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// Defines the CreatedFile
        /// </summary>
        public event EventHandler<CreatedFileEventArgs> CreatedFile;

        /// <summary>
        /// Defines the CreateFile
        /// </summary>
        public event EventHandler<CreateFileEventArgs> CreateFile;

        /// <summary>
        /// Defines the CreatingFile
        /// </summary>
        public event EventHandler<CreatingFileEventArgs> CreatingFile;

        /// <summary>
        /// Defines the FilenameChanged
        /// </summary>
        public event EventHandler FilenameChanged;

        /// <summary>
        /// Defines the OpenedFile
        /// </summary>
        public event EventHandler<OpenedFileEventArgs> OpenedFile;

        /// <summary>
        /// Defines the OpenFile
        /// </summary>
        public event EventHandler<OpenFileEventArgs> OpenFile;

        /// <summary>
        /// Defines the OpeningFile
        /// </summary>
        public event EventHandler<OpeningFileEventArgs> OpeningFile;

        /// <summary>
        /// Defines the SavedFile
        /// </summary>
        public event EventHandler<SavedFileEventArgs> SavedFile;

        /// <summary>
        /// Defines the SaveFile
        /// </summary>
        public event EventHandler<SaveFileEventArgs> SaveFile;

        /// <summary>
        /// Defines the SavingFile
        /// </summary>
        public event EventHandler<SavingFileEventArgs> SavingFile;

        /// <summary>
        /// Gets or sets the ChangeDetector
        /// </summary>
        public ChangeDetector ChangeDetector { get; set; } = new ChangeDetector();

        /// <summary>
        /// Gets or sets the FileName
        /// </summary>
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; OnFilenameChanged(new EventArgs()); }
        }

        /// <summary>
        /// Gets or sets the OpenFileDialog
        /// </summary>
        public OpenFileDialog OpenFileDialog { get; set; } = new OpenFileDialog();

        /// <summary>
        /// Gets or sets the SaveFileDialog
        /// </summary>
        public SaveFileDialog SaveFileDialog { get; set; } = new SaveFileDialog();

        /// <summary>
        /// The NewApplicationFile
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
        public bool NewApplicationFile()
        {
            if (ChangeDetector.Changed && !SaveApplicationFile())
            {
                return false;
            }

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
                ChangeDetector.Changed = false;

                FileName = createFileEventArgs.FileName;

                return !createdFileEventArgs.Failed;
            }

            return false;
        }

        /// <summary>
        /// The OpenApplicationFile
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
        public bool OpenApplicationFile()
        {
            OpenFileDialog.FileName = string.Empty;
            if (OpenFileDialog.ShowDialog().Equals(DialogResult.OK))
            {
                if (!SaveApplicationFile())
                {
                    return false;
                }

                var fileName = OpenFileDialog.FileName;

                var openingFileEventArgs = new OpeningFileEventArgs(fileName);
                OnOpeningFile(openingFileEventArgs);
                if (!openingFileEventArgs.Cancel)
                {
                    var openFileEventArgs = new OpenFileEventArgs() { Failed = false, FileName = openingFileEventArgs.FileName };
                    OnOpenFile(openFileEventArgs);

                    var failed = openFileEventArgs.Failed;
                    var openedFileEventArgs = new OpenedFileEventArgs(failed);
                    OnOpenedFile(openedFileEventArgs);

                    FileName = openFileEventArgs.FileName;
                    ChangeDetector.Changed = false;

                    return !openedFileEventArgs.Failed;
                }
            }

            return false;
        }

        /// <summary>
        /// The SaveApplicationFile
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
        public bool SaveApplicationFile()
        {
            return SaveAsApplicationFile(false);
        }

        /// <summary>
        /// The SaveAsApplicationFile
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
        public bool SaveAsApplicationFile()
        {
            return SaveAsApplicationFile(true);
        }

        /// <summary>
        /// The SaveAsApplicationFile
        /// </summary>
        /// <param name="askFile">The askFile<see cref="bool"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public bool SaveAsApplicationFile(bool askFile)
        {
            return SaveAsApplicationFile(FileName, askFile);
        }

        /// <summary>
        /// The OnCreatedFile
        /// </summary>
        /// <param name="e">The e<see cref="CreatedFileEventArgs"/></param>
        protected virtual void OnCreatedFile(CreatedFileEventArgs e)
        {
            CreatedFile?.Invoke(this, e);
        }

        /// <summary>
        /// The OnCreateFile
        /// </summary>
        /// <param name="e">The e<see cref="CreateFileEventArgs"/></param>
        protected virtual void OnCreateFile(CreateFileEventArgs e)
        {
            CreateFile?.Invoke(this, e);
        }

        /// <summary>
        /// The OnCreatingFile
        /// </summary>
        /// <param name="e">The e<see cref="CreatingFileEventArgs"/></param>
        protected virtual void OnCreatingFile(CreatingFileEventArgs e)
        {
            CreatingFile?.Invoke(this, e);
        }

        /// <summary>
        /// The OnFilenameChanged
        /// </summary>
        /// <param name="e">The e<see cref="EventArgs"/></param>
        protected virtual void OnFilenameChanged(EventArgs e)
        {
            FilenameChanged?.Invoke(this, e);
        }

        /// <summary>
        /// The OnOpenedFile
        /// </summary>
        /// <param name="openedFileEventArgs">The openedFileEventArgs<see cref="OpenedFileEventArgs"/></param>
        protected virtual void OnOpenedFile(OpenedFileEventArgs openedFileEventArgs)
        {
            OpenedFile?.Invoke(this, openedFileEventArgs);
        }

        /// <summary>
        /// The OnOpenFile
        /// </summary>
        /// <param name="e">The e<see cref="OpenFileEventArgs"/></param>
        protected virtual void OnOpenFile(OpenFileEventArgs e)
        {
            OpenFile?.Invoke(this, e);
        }

        /// <summary>
        /// The OnOpeningFile
        /// </summary>
        /// <param name="e">The e<see cref="OpeningFileEventArgs"/></param>
        protected virtual void OnOpeningFile(OpeningFileEventArgs e)
        {
            OpeningFile?.Invoke(this, e);
        }

        /// <summary>
        /// The OnSavedFile
        /// </summary>
        /// <param name="e">The e<see cref="SavedFileEventArgs"/></param>
        protected virtual void OnSavedFile(SavedFileEventArgs e)
        {
            SavedFile?.Invoke(this, e);
        }

        /// <summary>
        /// The OnSaveFile
        /// </summary>
        /// <param name="e">The e<see cref="SaveFileEventArgs"/></param>
        protected virtual void OnSaveFile(SaveFileEventArgs e)
        {
            SaveFile?.Invoke(this, e);
        }

        /// <summary>
        /// The OnSavingFile
        /// </summary>
        /// <param name="e">The e<see cref="SavingFileEventArgs"/></param>
        protected virtual void OnSavingFile(SavingFileEventArgs e)
        {
            SavingFile?.Invoke(this, e);
        }

        /// <summary>
        /// The GetSuggestedFilename
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        private string GetSuggestedFilename()
        {
            return "MyNewFile.phf";
        }

        /// <summary>
        /// The SaveAsApplicationFile
        /// </summary>
        /// <param name="filename">The filename<see cref="string"/></param>
        /// <param name="askFile">The askFile<see cref="bool"/></param>
        /// <returns>The <see cref="bool"/></returns>
        private bool SaveAsApplicationFile(string filename, bool askFile)
        {
            if (string.IsNullOrEmpty(filename) || askFile)
            {
                SaveFileDialog.FileName = filename;
                if (SaveFileDialog.ShowDialog().Equals(DialogResult.Cancel))
                {
                    return false;
                }
            }

            var fileName = SaveFileDialog.FileName;

            var savingApplicationFileEventArgs = new SavingFileEventArgs(fileName);
            OnSavingFile(savingApplicationFileEventArgs);
            if (!savingApplicationFileEventArgs.Cancel)
            {
                var saveApplicationFileEventArgs = new SaveFileEventArgs(fileName);
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

            return false;
        }
    }
}
