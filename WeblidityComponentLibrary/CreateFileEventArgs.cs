using System;

namespace WeblidityComponentLibrary
{
    public class CreateFileEventArgs : EventArgs
    {
        public CreateFileEventArgs()
        {
        }

        public bool Failed { get; internal set; }
        public string FileName { get; internal set; }
    }
}