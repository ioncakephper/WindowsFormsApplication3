//-----------------------------------------------------------------------
// <copyright file="SaveFileEventArgs.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace WeblidityComponentLibrary
{
    using System;

    /// <summary>
    /// Defines the <see cref="SaveFileEventArgs" />
    /// </summary>
    public class SaveFileEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SaveFileEventArgs"/> class.
        /// </summary>
        /// <param name="filename">The filename<see cref="string"/></param>
        public SaveFileEventArgs(string filename)
        {
            this.Filename = filename;
        }

        /// <summary>
        /// Gets or sets a value indicating whether Failed
        /// </summary>
        public bool Failed { get; internal set; }

        /// <summary>
        /// Gets or sets the Filename
        /// </summary>
        public string Filename { get; set; }
    }
}
