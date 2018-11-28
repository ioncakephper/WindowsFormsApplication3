using System;

namespace WeblidityComponentLibrary
{
    public class SaveFileEventArgs : EventArgs
    {
        public string Filename { get; set; }
        public bool Failed { get; internal set; }

        public SaveFileEventArgs(string filename)
        {
            this.Filename = filename;
        }
    }
}