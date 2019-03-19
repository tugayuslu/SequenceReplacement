using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biyoenformatik
{
    public partial class Form4 : Form
    {
        Translator t = new Translator();
        public Form4()
        {
            InitializeComponent();
            richTextBox2.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = t.textEdit(richTextBox1.Text);
            if (radioButton1.Checked)
                richTextBox2.Text = t.AA2cDNA(richTextBox1.Text);
            else
                richTextBox2.Text = t.acDNA2cDNA(t.AA2cDNA(richTextBox1.Text));         
        }
    }
}
