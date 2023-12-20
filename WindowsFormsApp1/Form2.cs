using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        private Form1 form1Reference;

        public Form2(Form1 form1)
        {
            InitializeComponent();
            form1Reference = form1;
            this.FormClosing += Form2_FormClosing;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Zamknij Form1 po zamknięciu Form2
            form1Reference.Close();
            Application.Exit();
        }

    }
}
