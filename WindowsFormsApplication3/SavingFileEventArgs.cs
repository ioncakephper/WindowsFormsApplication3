using System;

namespace WeblidityComponentLibrary
{
    public class SavingFileEventArgs : EventArgs
    {

        public SavingFileEventArgs()
        {
            Cancel = false;
        }

        public SavingFileEventArgs(string fileName) : this()
        {
            FileName = fileName;
        }

        public bool Cancel { get; set; }
        public string FileName { get; set; }
    }
}