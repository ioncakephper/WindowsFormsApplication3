using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeblidityComponentLibrary
{
    public partial class ChangeDetector : Component
    {
        public ChangeDetector()
        {
            InitializeComponent();
        }

        public ChangeDetector(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// Asks user to confirm form closing.
        /// </summary>
        /// <returns>True to cancel form closing, False to allow form to close.</returns>
        public bool ConfirmFormClosing()
        {
            if (!Changed)
            {
                return false;
            }
            this.DialogResult = MessageBox.Show(MessageToUser, MessageCaption, ButtonSet, MessageIcon);
            if (this.DialogResult.Equals(CancelButton))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets or sets whether changes occurred.
        /// </summary> 
        [Description("Indicates whether changes were noticed.")]
        [DefaultValue(false)]
        public bool Changed
        {
            get; set;
        } = false;

        [Description("Determines the set of buttons to show on confirmation dialog.")]
        [DefaultValue(MessageBoxButtons.YesNoCancel)]
        public MessageBoxButtons ButtonSet { get; set; } = MessageBoxButtons.YesNoCancel;

        [Description("The button value associated with closing the form.")]
        [DefaultValue(DialogResult.Cancel)]
        public DialogResult CancelButton { get; set; } = DialogResult.Cancel;

        [Browsable(false)]
        public DialogResult DialogResult { get; set; }

        [Description("The message to appear on confirmation dialog.")]
        [DefaultValue("Changed occurred and closing the form might lose the changes. Do you want to save?")]
        public string MessageToUser { get; set; } = "Changed occurred and closing the form might lose the changes. Do you want to save?";


        public string MessageCaption { get; set; } = Application.ProductName;

        [Description("Determines which icon appears on confirmation dialog.")]
        [DefaultValue(MessageBoxIcon.Warning)]
        public MessageBoxIcon MessageIcon { get; set; } = MessageBoxIcon.Warning;
    }
}
