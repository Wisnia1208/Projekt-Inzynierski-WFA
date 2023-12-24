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
    public partial class Form3 : Form
    {
        private int index;
        private SerialPort serialPort = new SerialPort(Form1.COM, 115200);
        public Form3(int index_i)
        {
            InitializeComponent();
            index = index_i;
        }
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
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
                //serialPort.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text==textBox4.Text)
            {
                if (textBox3.Text.IndexOf(":")!=-1)
                {
                    MessageBox.Show("hasło nie może zawiertać znaku :");
                }
                else if (textBox2.Text.IndexOf(":") != -1)
                {
                    MessageBox.Show("nazwa użytkownika nie może zawiertać znaku :");
                }
                else if (textBox1.Text.IndexOf(":") != -1)
                {
                    MessageBox.Show("platforma nie może zawiertać znaku :");
                }
                else if (textBox1.Text.IndexOf("ą") != -1 || textBox1.Text.IndexOf("Ą") != -1 || textBox1.Text.IndexOf("ć") != -1 || textBox1.Text.IndexOf("Ć") != -1 || textBox1.Text.IndexOf("ę") != -1 || textBox1.Text.IndexOf("Ę") != -1 || textBox1.Text.IndexOf("ł") != -1 || textBox1.Text.IndexOf("Ł") != -1 || textBox1.Text.IndexOf("ń") != -1 || textBox1.Text.IndexOf("Ń") != -1 || textBox1.Text.IndexOf("ó") != -1 || textBox1.Text.IndexOf("Ó") != -1 || textBox1.Text.IndexOf("ś") != -1 || textBox1.Text.IndexOf("Ś") != -1 || textBox1.Text.IndexOf("ź") != -1 || textBox1.Text.IndexOf("Ź") != -1 || textBox1.Text.IndexOf("ż") != -1 || textBox1.Text.IndexOf("Ż") != -1)
                {
                    MessageBox.Show("zakaz polskich znaków");
                }
                else if (textBox2.Text.IndexOf("ą") != -1 || textBox2.Text.IndexOf("Ą") != -1 || textBox2.Text.IndexOf("ć") != -1 || textBox2.Text.IndexOf("Ć") != -1 || textBox2.Text.IndexOf("ę") != -1 || textBox2.Text.IndexOf("Ę") != -1 || textBox2.Text.IndexOf("ł") != -1 || textBox2.Text.IndexOf("Ł") != -1 || textBox2.Text.IndexOf("ń") != -1 || textBox2.Text.IndexOf("Ń") != -1 || textBox2.Text.IndexOf("ó") != -1 || textBox2.Text.IndexOf("Ó") != -1 || textBox2.Text.IndexOf("ś") != -1 || textBox2.Text.IndexOf("Ś") != -1 || textBox2.Text.IndexOf("ź") != -1 || textBox2.Text.IndexOf("Ź") != -1 || textBox2.Text.IndexOf("ż") != -1 || textBox2.Text.IndexOf("Ż") != -1)
                {
                    MessageBox.Show("zakaz polskich znaków");
                }
                else if (textBox3.Text.IndexOf("ą") != -1 || textBox3.Text.IndexOf("Ą") != -1 || textBox3.Text.IndexOf("ć") != -1 || textBox3.Text.IndexOf("Ć") != -1 || textBox3.Text.IndexOf("ę") != -1 || textBox3.Text.IndexOf("Ę") != -1 || textBox3.Text.IndexOf("ł") != -1 || textBox3.Text.IndexOf("Ł") != -1 || textBox3.Text.IndexOf("ń") != -1 || textBox3.Text.IndexOf("Ń") != -1 || textBox3.Text.IndexOf("ó") != -1 || textBox3.Text.IndexOf("Ó") != -1 || textBox3.Text.IndexOf("ś") != -1 || textBox3.Text.IndexOf("Ś") != -1 || textBox3.Text.IndexOf("ź") != -1 || textBox3.Text.IndexOf("Ź") != -1 || textBox3.Text.IndexOf("ż") != -1 || textBox3.Text.IndexOf("Ż") != -1)
                {
                    MessageBox.Show("zakaz polskich znaków");
                }
                else
                {
                    string frame = "change_data_on_" + $"{index}" + '\n';
                    SendDataToESP32(frame);
                    SendDataToESP32(textBox1.Text + ':');
                    SendDataToESP32(textBox2.Text + ':');
                    SendDataToESP32(textBox3.Text + ':');
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
