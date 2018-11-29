//------------------------------------------------------------------------------
// <copyright file="OpenedFileEventArgs.cs" company="Ion Gireada">
//      Copyright (c) Ion Gireada. All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace WeblidityComponentLibrary
{
    using System;

    /// <summary>
    /// Defines the <see cref="OpenedFileEventArgs" />
    /// </summary>
    public class OpenedFileEventArgs : EventArgs
    {
        /// <summary>
        /// Defines the failed
        /// </summary>
        private bool failed;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenedFileEventArgs"/> class.
        /// </summary>
        /// <param name="failed">The failed<see cref="bool"/></param>
        public OpenedFileEventArgs(bool failed)
        {
            this.failed = failed;
        }

        /// <summary>
        /// Gets or sets a value indicating whether Failed
        /// </summary>
        public bool Failed { get; internal set; }
    }
}
