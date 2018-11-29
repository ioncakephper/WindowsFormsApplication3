//------------------------------------------------------------------------------
// <copyright file="createfileeventargs.cs" company="Ion Gireada">
//      Copyright (c) Ion Gireada. All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace WeblidityComponentLibrary
{
    using System;

    /// <summary>
    /// Defines the <see cref="CreateFileEventArgs" />
    /// </summary>
    public class CreateFileEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateFileEventArgs"/> class.
        /// </summary>
        public CreateFileEventArgs()
        {
        }

        /// <summary>
        /// Gets a value indicating whether Failed
        /// </summary>
        public bool Failed { get; internal set; }

        /// <summary>
        /// Gets the FileName
        /// </summary>
        public string FileName { get; internal set; }
    }
}
