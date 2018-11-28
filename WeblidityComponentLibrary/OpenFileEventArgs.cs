using System;

namespace WeblidityComponentLibrary
{
    public class OpenFileEventArgs : EventArgs
    {
        public OpenFileEventArgs()
        {
        }

        public bool Failed { get; set; }
        public string FileName { get; set; }
    }
}