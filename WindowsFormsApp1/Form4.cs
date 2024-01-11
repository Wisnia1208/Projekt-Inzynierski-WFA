using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        private SerialPort serialPort;
        public Form4(SerialPort serialPort)
        {
            InitializeComponent();
            this.serialPort = serialPort;
            this.FormClosing += Form4_FormClosing;
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        private string encode(string info)
        {
            char[] chars = info.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = (char)(chars[i] - 1);
            }
            return new string(chars);
        }

        private void SendDataToESP32(string data)
        {
            try
            {
                if (!serialPort.IsOpen)
                {
                    try
                    {
                        serialPort.Open();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Błąd podczas otwierania portu: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                serialPort.Write(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == textBox3.Text)
            {
                if (textBox2.Text.IndexOf(";") != -1)
                {
                    MessageBox.Show("hasło nie może zawiertać znaku ;");
                }
                else if (textBox1.Text.IndexOf(";") != -1)
                {
                    MessageBox.Show("nazwa użytkownika nie może zawiertać znaku ;");
                }
                else if (textBox1.Text.IndexOf("ą") != -1 || textBox1.Text.IndexOf("Ą") != -1 || textBox1.Text.IndexOf("ć") != -1 || textBox1.Text.IndexOf("Ć") != -1 || textBox1.Text.IndexOf("ę") != -1 || textBox1.Text.IndexOf("Ę") != -1 || textBox1.Text.IndexOf("ł") != -1 || textBox1.Text.IndexOf("Ł") != -1 || textBox1.Text.IndexOf("ń") != -1 || textBox1.Text.IndexOf("Ń") != -1 || textBox1.Text.IndexOf("ó") != -1 || textBox1.Text.IndexOf("Ó") != -1 || textBox1.Text.IndexOf("ś") != -1 || textBox1.Text.IndexOf("Ś") != -1 || textBox1.Text.IndexOf("ź") != -1 || textBox1.Text.IndexOf("Ź") != -1 || textBox1.Text.IndexOf("ż") != -1 || textBox1.Text.IndexOf("Ż") != -1)
                {
                    MessageBox.Show("zakaz polskich znaków");
                }
                else if (textBox2.Text.IndexOf("ą") != -1 || textBox2.Text.IndexOf("Ą") != -1 || textBox2.Text.IndexOf("ć") != -1 || textBox2.Text.IndexOf("Ć") != -1 || textBox2.Text.IndexOf("ę") != -1 || textBox2.Text.IndexOf("Ę") != -1 || textBox2.Text.IndexOf("ł") != -1 || textBox2.Text.IndexOf("Ł") != -1 || textBox2.Text.IndexOf("ń") != -1 || textBox2.Text.IndexOf("Ń") != -1 || textBox2.Text.IndexOf("ó") != -1 || textBox2.Text.IndexOf("Ó") != -1 || textBox2.Text.IndexOf("ś") != -1 || textBox2.Text.IndexOf("Ś") != -1 || textBox2.Text.IndexOf("ź") != -1 || textBox2.Text.IndexOf("Ź") != -1 || textBox2.Text.IndexOf("ż") != -1 || textBox2.Text.IndexOf("Ż") != -1)
                {
                    MessageBox.Show("zakaz polskich znaków");
                }
                else
                {
                    SendDataToESP32("change_login"+'\n');
                    SendDataToESP32(encode(textBox1.Text) + ':');
                    SendDataToESP32(encode(textBox2.Text) + ':');
                    string data = null;
                    while (data != "done\r")
                    {
                        await Task.Delay(100);
                        data = serialPort.ReadLine();
                    }
                    MessageBox.Show("zmieniono dane");

                    if (serialPort.IsOpen)
                    {
                        serialPort.Close();
                    }
                }

            }
            else
            {
                MessageBox.Show("hasła nie są takie same");
            }
        }

    }
}
