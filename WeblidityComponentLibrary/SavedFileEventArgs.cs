using System;

namespace WeblidityComponentLibrary
{
    public class SavedFileEventArgs : EventArgs
    {
        public bool Failed { get; set; }
        public string Filename { get; set; }

        public SavedFileEventArgs(string filename) : this()
        {
            Filename = filename;
        }

        public SavedFileEventArgs(string filename, bool failed) : this(filename)
        {
            Failed = failed;
        }

        public SavedFileEventArgs()
        {
            Filename = string.Empty;
            Failed = false;
        }
    }
}