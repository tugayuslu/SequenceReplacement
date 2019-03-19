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
    public partial class Form3 : Form
    {
        Translator t = new Translator();
        List<string> proteins;
        public Form3()
        {
            InitializeComponent();
            comboBox1.Enabled = false;
            richTextBox2.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = t.textEdit(richTextBox1.Text);
            if (radioButton1.Checked) proteins = t.mRNA2PROTEIN(t.cDNA2mRNA(richTextBox1.Text), richTextBox1);
            else proteins = t.mRNA2PROTEIN(t.cDNA2mRNA(t.acDNA2cDNA(richTextBox1.Text)), richTextBox1);

            comboBox1.Items.Clear();
            for (int i = 1; i <= proteins.Count; i++)
            {
                comboBox1.Items.Add("Protein " + i.ToString());
            }
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.Enabled = true;
                comboBox1.SelectedItem = "Protein 1";
            }
            else
            {
                comboBox1.Enabled = false;
                comboBox1.Text = "";
                MessageBox.Show("Protein Bulunamadı...");
                richTextBox2.Text = "";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox2.Text = proteins[comboBox1.SelectedIndex];
        }
    }
}
