//-----------------------------------------------------------------------
// <copyright file="createdfileeventargs.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace WeblidityComponentLibrary
{
    using System;

    /// <summary>
    /// Defines the <see cref="CreatedFileEventArgs" />
    /// </summary>
    public class CreatedFileEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreatedFileEventArgs"/> class.
        /// </summary>
        public CreatedFileEventArgs()
        {
            Failed = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreatedFileEventArgs"/> class.
        /// </summary>
        /// <param name="failed">The failed<see cref="bool"/></param>
        public CreatedFileEventArgs(bool failed) : this()
        {
            Failed = failed;
        }

        /// <summary>
        /// Gets or sets a value indicating whether Failed
        /// </summary>
        public bool Failed { get; set; }
    }
}
