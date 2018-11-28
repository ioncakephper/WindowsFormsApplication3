using System;

namespace WeblidityComponentLibrary
{
    public class CreatedFileEventArgs : EventArgs
    {
        public CreatedFileEventArgs()
        {
            Failed = false;
        }

        public CreatedFileEventArgs(bool failed) : this()
        {
            Failed = failed;
        }

        public bool Failed { get; set; }
    }
}