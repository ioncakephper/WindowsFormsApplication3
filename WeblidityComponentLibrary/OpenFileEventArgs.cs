//------------------------------------------------------------------------------
// <copyright file="OpenFileEventArgs.cs" company="Ion Gireada">
//      Copyright (c) Ion Gireada. All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace WeblidityComponentLibrary
{
    using System;

    /// <summary>
    /// Defines the <see cref="OpenFileEventArgs" />
    /// </summary>
    public class OpenFileEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenFileEventArgs"/> class.
        /// </summary>
        public OpenFileEventArgs()
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether Failed
        /// </summary>
        public bool Failed { get; set; }

        /// <summary>
        /// Gets or sets the FileName
        /// </summary>
        public string FileName { get; set; }
    }
}
