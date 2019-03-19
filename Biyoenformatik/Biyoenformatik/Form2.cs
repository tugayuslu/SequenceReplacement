using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biyoenformatik
{
    public partial class Form2 : Form
    {
        Translator t = new Translator();
        public Form2()
        {
            InitializeComponent();
            richTextBox2.ReadOnly=true;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = t.textEdit(richTextBox1.Text);
            if(radioButton1.Checked)            
                richTextBox2.Text = t.mRNA2AA(t.cDNA2mRNA(richTextBox1.Text));
            else
                richTextBox2.Text = t.mRNA2AA(t.cDNA2mRNA(t.acDNA2cDNA(richTextBox1.Text)));

        }
    }
}
