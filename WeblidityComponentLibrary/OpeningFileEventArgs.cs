//------------------------------------------------------------------------------
// <copyright file="OpeningFileEventArgs.cs" company="Ion Gireada">
//      Copyright (c) Ion Gireada. All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace WeblidityComponentLibrary
{
    using System;

    /// <summary>
    /// Defines the <see cref="OpeningFileEventArgs" />
    /// </summary>
    public class OpeningFileEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningFileEventArgs"/> class.
        /// </summary>
        /// <param name="fileName">The fileName<see cref="string"/></param>
        public OpeningFileEventArgs(string fileName)
        {
            this.FileName = fileName;
        }

        /// <summary>
        /// Gets or sets a value indicating whether Cancel
        /// </summary>
        public bool Cancel { get; internal set; }

        /// <summary>
        /// Gets or sets the FileName
        /// </summary>
        public string FileName { get; set; }
    }
}
