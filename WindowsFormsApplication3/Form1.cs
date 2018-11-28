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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            People = new PeopleList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var d = new Dialog1();
            if (d.ShowDialog().Equals(DialogResult.OK))
            {
                MessageBox.Show("OK");
            }
        }

        public PeopleList People { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            // changeDetector1.Changed = true;
            fileManager1.FileName = "Phrases1.phf";
            People.AddRange(new Person[] { new Person("Ion", "Gireada"), new Person("Dale", "Cooper") });
            PopulatePeopleListBox();
        }

        private void PopulatePeopleListBox()
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(People.FullNames().ToArray());
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = changeDetector1.ConfirmFormClosing();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (changeDetector1.DialogResult.Equals(DialogResult.Yes))
            {
                MessageBox.Show("Information is being saved...");
            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            NewApplicationFile();
        }

        private void NewApplicationFile()
        {
            fileManager1.NewApplicationFile();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveApplicationFile();
        }

        private void SaveApplicationFile()
        {
            fileManager1.SaveApplicationFile();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAsApplicationFile();
        }

        private void SaveAsApplicationFile()
        {
            fileManager1.SaveAsApplicationFile();
        }

        private void fileManager1_FilenameChanged(object sender, EventArgs e)
        {
            Text = System.IO.Path.GetFileNameWithoutExtension(fileManager1.FileName);
        }
    }
}
