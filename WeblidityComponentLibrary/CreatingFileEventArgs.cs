//------------------------------------------------------------------------------
// <copyright file="creatingfileeventargs.cs" company="Ion Gireada">
//      Copyright (c) Ion Gireada. All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace WeblidityComponentLibrary
{
    using System;

    /// <summary>
    /// Defines the <see cref="CreatingFileEventArgs" />
    /// </summary>
    public class CreatingFileEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreatingFileEventArgs"/> class.
        /// </summary>
        /// <param name="filename">The filename<see cref="string"/></param>
        public CreatingFileEventArgs(string filename)
        {
            this.FileName = filename;
            this.Cancel = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreatingFileEventArgs"/> class.
        /// </summary>
        /// <param name="filename">The filename<see cref="string"/></param>
        /// <param name="cancel">The cancel<see cref="bool"/></param>
        public CreatingFileEventArgs(string filename, bool cancel) : this(filename)
        {
            this.Cancel = cancel;
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
