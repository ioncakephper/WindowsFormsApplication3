using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Dialog1 : Form
    {
        public Dialog1()
        {
            InitializeComponent();
        }

        private void Dialog1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.Equals(DialogResult.Cancel))
            {
                e.Cancel = changeDetector1.ConfirmFormClosing();
            }
        }

        private void Dialog1_Load(object sender, EventArgs e)
        {
            changeDetector1.Changed = true;
        }

        private void Dialog1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (changeDetector1.DialogResult.Equals(DialogResult.Yes))
            {
                MessageBox.Show("Saving information to output property");
            }
        }
    }
}
