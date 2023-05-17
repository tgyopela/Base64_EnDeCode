using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EnDeCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = Encoding.UTF8.GetString(Convert.FromBase64String(textBox1.Text));
            
            
            listBox1.Items.Add(textBox1.Text);
            listBox2.Items.Add(textBox2.Text);
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = Convert.ToBase64String(Encoding.UTF8.GetBytes(textBox1.Text));
            listBox1.Items.Add(textBox1.Text);
            listBox2.Items.Add(textBox2.Text);
            textBox1.Text = "";
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = listBox2.SelectedIndex;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.SelectedIndex = listBox1.SelectedIndex;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Sor = null;
            //int i = 0;
            for (int i = 0; listBox1.Items.Count > i; i++)
            {
                Sor += listBox1.Items[i].ToString()+ " | " + listBox2.Items[i].ToString() + "\n";
                
            }
            saveFileDialog1.Filter = "Txt | *.txt";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                File.WriteAllText(saveFileDialog1.FileName,Sor);
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                try
                {
                    button2_Click(sender, e);
                    
                }
                catch
                {
                    button1_Click(sender, e);
                }
            }

        }
    }
}
