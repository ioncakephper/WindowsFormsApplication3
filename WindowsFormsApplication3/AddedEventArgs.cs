//------------------------------------------------------------------------------
// <copyright file="AddedEventArgs.cs" company="Ion Gireada">
//      Copyright (c) Ion Gireada. All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace WindowsFormsApplication3
{
    using System;

    /// <summary>
    /// Defines the <see cref="AddedEventArgs" />
    /// </summary>
    public class AddedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddedEventArgs"/> class.
        /// </summary>
        public AddedEventArgs()
        {
            PeopleAdded = new Person[] { };
        }

        /// <summary>
        /// Gets or sets the PeopleAdded
        /// </summary>
        public Person[] PeopleAdded { get; set; }
    }
}
