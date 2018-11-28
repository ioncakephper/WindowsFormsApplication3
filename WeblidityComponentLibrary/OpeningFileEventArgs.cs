using System;

namespace WeblidityComponentLibrary
{
    public class OpeningFileEventArgs : EventArgs
    {
        public string FileName { get; set; }
        public bool Cancel { get; internal set; }

        public OpeningFileEventArgs(string fileName)
        {
            this.FileName = fileName;
        }
    }
}