using System;

namespace WeblidityComponentLibrary
{
    public class CreatingFileEventArgs : EventArgs
    {
        public CreatingFileEventArgs(string filename)
        {
            FileName = filename;
            Cancel = false;
        }

        public CreatingFileEventArgs(string filename, bool cancel) : this(filename)
        {
            Cancel = cancel;
        }

        public bool Cancel { get; set; }
        public string FileName { get; set; }
    }
}