//------------------------------------------------------------------------------
// <copyright file="SavedFileEventArgs.cs" company="Ion Gireada">
//      Copyright (c) Ion Gireada. All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace WeblidityComponentLibrary
{
    using System;

    /// <summary>
    /// Defines the <see cref="SavedFileEventArgs" />
    /// </summary>
    public class SavedFileEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SavedFileEventArgs"/> class.
        /// </summary>
        public SavedFileEventArgs()
        {
            Filename = string.Empty;
            Failed = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SavedFileEventArgs"/> class.
        /// </summary>
        /// <param name="filename">The filename<see cref="string"/></param>
        public SavedFileEventArgs(string filename) : this()
        {
            Filename = filename;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SavedFileEventArgs"/> class.
        /// </summary>
        /// <param name="filename">The filename<see cref="string"/></param>
        /// <param name="failed">The failed<see cref="bool"/></param>
        public SavedFileEventArgs(string filename, bool failed) : this(filename)
        {
            Failed = failed;
        }

        /// <summary>
        /// Gets or sets a value indicating whether Failed
        /// </summary>
        public bool Failed { get; set; }

        /// <summary>
        /// Gets or sets the Filename
        /// </summary>
        public string Filename { get; set; }
    }
}
