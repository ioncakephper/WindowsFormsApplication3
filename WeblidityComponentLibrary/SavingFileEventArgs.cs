//-----------------------------------------------------------------------
// <copyright file="SavingFileEventArgs.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace WeblidityComponentLibrary
{
    using System;

    /// <summary>
    /// Defines the <see cref="SavingFileEventArgs" />
    /// </summary>
    public class SavingFileEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SavingFileEventArgs"/> class.
        /// </summary>
        public SavingFileEventArgs()
        {
            Cancel = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SavingFileEventArgs"/> class.
        /// </summary>
        /// <param name="fileName">The fileName<see cref="string"/></param>
        public SavingFileEventArgs(string fileName) : this()
        {
            FileName = fileName;
        }

        /// <summary>
        /// Gets or sets a value indicating whether Cancel
        /// </summary>
        public bool Cancel { get; set; }

        /// <summary>
        /// Gets or sets the FileName
        /// </summary>
        public string FileName { get; set; }
    }
}
