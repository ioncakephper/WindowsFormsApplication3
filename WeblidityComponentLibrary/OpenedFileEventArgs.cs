using System;

namespace WeblidityComponentLibrary
{
    public class OpenedFileEventArgs : EventArgs
    {
        private bool failed;

        public OpenedFileEventArgs(bool failed)
        {
            this.failed = failed;
        }

        public bool Failed { get; internal set; }
    }
}