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
    public partial class Form1 : Form
    {
        //http://db.systemsbiology.net:8080/proteomicsToolkit/DNATranslator.html
        //https://www.youtube.com/watch?v=zuww7JtUhcE

        public Form1()
        {
            InitializeComponent();
        }
        
        Form3 form3 = new Form3();
        Form4 form4 = new Form4();

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }
    }
}
