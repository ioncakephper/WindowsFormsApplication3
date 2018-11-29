//-----------------------------------------------------------------------
// <copyright file="ChangeDetector.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace WeblidityComponentLibrary
{
    using System.ComponentModel;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="ChangeDetector" />
    /// </summary>
    public partial class ChangeDetector : Component
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeDetector"/> class.
        /// </summary>
        public ChangeDetector()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangeDetector"/> class.
        /// </summary>
        /// <param name="container">The container<see cref="IContainer"/></param>
        public ChangeDetector(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the ButtonSet
        /// </summary>
        [Description("Determines the set of buttons to show on confirmation dialog.")]
        [DefaultValue(MessageBoxButtons.YesNoCancel)]
        public MessageBoxButtons ButtonSet { get; set; } = MessageBoxButtons.YesNoCancel;

        /// <summary>
        /// Gets or sets the CancelButton
        /// </summary>
        [Description("The button value associated with closing the form.")]
        [DefaultValue(DialogResult.Cancel)]
        public DialogResult CancelButton { get; set; } = DialogResult.Cancel;

        /// <summary>
        /// Gets or sets a value indicating whether Changed
        /// </summary>
        [Description("Indicates whether changes were noticed.")]
        [DefaultValue(false)]
        public bool Changed { get; set; } = false;

        /// <summary>
        /// Gets or sets the DialogResult
        /// </summary>
        [Browsable(false)]
        public DialogResult DialogResult { get; set; }

        /// <summary>
        /// Gets or sets the MessageCaption
        /// </summary>
        public string MessageCaption { get; set; } = Application.ProductName;

        /// <summary>
        /// Gets or sets the MessageIcon
        /// </summary>
        [Description("Determines which icon appears on confirmation dialog.")]
        [DefaultValue(MessageBoxIcon.Warning)]
        public MessageBoxIcon MessageIcon { get; set; } = MessageBoxIcon.Warning;

        /// <summary>
        /// Gets or sets the MessageToUser
        /// </summary>
        [Description("The message to appear on confirmation dialog.")]
        [DefaultValue("Changed occurred and closing the form might lose the changes. Do you want to save?")]
        public string MessageToUser { get; set; } = "Changed occurred and closing the form might lose the changes. Do you want to save?";

        /// <summary>
        /// The ConfirmFormClosing
        /// </summary>
        /// <returns>The <see cref="bool"/></returns>
        public bool ConfirmFormClosing()
        {
            if (!this.Changed)
            {
                return false;
            }

            this.DialogResult = MessageBox.Show(this.MessageToUser, this.MessageCaption, this.ButtonSet, this.MessageIcon);
            if (this.DialogResult.Equals(this.CancelButton))
            {
                return true;
            }

            return false;
        }
    }
}
