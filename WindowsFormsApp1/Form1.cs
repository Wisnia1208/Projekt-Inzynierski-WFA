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

//test commita
//test commita2

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private SerialPort serialPort = new SerialPort("COM4", 115200);
        private string receivedData_global;
        //private object textBoxReceivedData;

        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            // Ta metoda zostanie wywołana, gdy dane zostaną odebrane przez port COM

            try
            {
                // Odczytanie dostępnych danych
                string receivedData = "";
                //receivedData = serialPort.ReadExisting();
                receivedData = serialPort.ReadLine();
                if (receivedData != "")
                {
                    receivedData_global = receivedData;
                }

                
                /*if(receivedData == "correct login data\r")
                {
                    //SimulateKeyboardInput("tutaj zrobic drugi panel bo dane dobre");
                    
                }
                else
                {
                    SimulateKeyboardInput(receivedData);
                }*/

                //MessageBox.Show(receivedData);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas odczytywania danych: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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

            // Przesyłaj dane do ESP32 przez interfejs szeregowy (Serial)
            SendDataToESP32($"Username: {username}, Password: {password}");

            // Inicjalizacja portu szeregowego

            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            //Thread.Sleep(1000);

            if (!serialPort.IsOpen)
            {
                try
                {
                    // Otwarcie portu
                    serialPort.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd podczas otwierania portu1: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            while (receivedData_global == null)
            {
                await Task.Delay(100); // Odczekaj krótki czas przed ponownym sprawdzeniem
            }

            if (receivedData_global == "correct login data\r")
            {
                var newform = new Form2(this);
                newform.Show();
                this.Hide();
                //this.Close();
            }
            else if (receivedData_global == "incorrect login data\r")
            {
                MessageBox.Show("bad login");
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
        private void SimulateKeyboardInput(string textToType)
        {
            // Odczekaj kilka sekund przed rozpoczęciem symulacji
            Thread.Sleep(2000);

            // Symuluj naciśnięcie i zwolnienie każdego znaku w tekście
            foreach (char c in textToType)
            {
                // Symuluj naciśnięcie klawisza
                SendKeys.SendWait(c.ToString());

                // Odczekaj krótki czas przed przesłaniem kolejnego znaku
                //Thread.Sleep(100);
            }
        }

    }
}
