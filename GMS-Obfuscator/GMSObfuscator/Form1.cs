using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMSObfuscator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Init();
        }

        void Init()
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] obfuscatedcode = ObfuscateStrings.ObStrings(textBox1.Text);
            textBox1.ResetText();
            int i = 0;
            foreach(string str in obfuscatedcode)
            {
                i++;
                if (i < obfuscatedcode.Length)
                    textBox1.Text += str + Environment.NewLine;
                else
                    textBox1.Text += str;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_Resize(object sender, System.EventArgs e)
        {

            Control control = (Control)sender;

            textBox1.Width = control.Size.Width - 40;
            textBox1.Height = control.Size.Height - 190;

            button1.Location = new Point(button1.Location.X, control.Size.Height - 157);

        }
    }
}
