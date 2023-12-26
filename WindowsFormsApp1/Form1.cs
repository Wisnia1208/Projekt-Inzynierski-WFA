using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO.Ports;
using System.Reflection;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public const string COM = "COM4";
        private SerialPort serialPort = new SerialPort(COM, 115200);
        private string receivedData_global=null;
        private int login_count=0;
        //private object textBoxReceivedData;

        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = maskedTextBox1.Text;

            string data_tosend = $"Username: {username}, Password: {password}";

            SendDataToESP32(data_tosend);

            while (receivedData_global != "correct login data\r" && receivedData_global != "incorrect login data\r")
            {
                await Task.Delay(100); // Odczekaj krótki czas przed ponownym sprawdzeniem
                receivedData_global=serialPort.ReadLine();
            }

            if (receivedData_global == "correct login data\r")
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
                var newform = new Form2(this);
                newform.Show();
                this.Hide();
                //this.Close();
            }
            else if (receivedData_global == "incorrect login data\r")
            {
                login_count++;
                if (login_count >= 4)
                {
                    SendDataToESP32("emergency_reset");          
                    MessageBox.Show("zresetowano wszystkie dane :) nazwa użytkownika to \"uzytkownik1\", a hasło to  \"haslo1\"");
                    login_count = 0;
                    if (serialPort.IsOpen)
                    {
                        serialPort.Close();
                    }
                }
                else
                {
                    MessageBox.Show("podano złe dane logowania po raz " + $"{login_count}");
                }
                
            }
            receivedData_global = null;
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
                            MessageBox.Show($"Błąd podczas otwierania portu2: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        

    }
}
