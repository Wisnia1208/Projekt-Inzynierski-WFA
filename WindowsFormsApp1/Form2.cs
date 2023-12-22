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

using System.Reflection;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        private Form1 form1Reference;
        private SerialPort serialPort = new SerialPort(Form1.COM, 115200);
        private string receivedData_global;

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

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            // Ta metoda zostanie wywołana, gdy dane zostaną odebrane przez port COM


            try
            {
                // Odczytanie dostępnych danych
                string receivedData = "";
                receivedData = serialPort.ReadLine();
                if (receivedData != "")
                {
                    receivedData_global = receivedData;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas odczytywania danych: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private async void button21_Click(object sender, EventArgs e)
        {
            SendDataToESP32("login_query");

            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            while (receivedData_global == null)
            {
                await Task.Delay(100); // Odczekaj krótki czas przed ponownym sprawdzeniem
            }
            int index_platform = receivedData_global.IndexOf("ptfr:") + 5;
            int index_username = receivedData_global.IndexOf("usrn:") + 5;
            int index_password = receivedData_global.IndexOf("pssw:") + 5;           
            int index_end = receivedData_global.IndexOf("\r") + 1;

            label2.Text = receivedData_global.Substring(index_platform, index_username-index_platform-5);
            label3.Text = receivedData_global.Substring(index_username, index_password-index_username-5);
            label4.Text = receivedData_global.Substring(index_password, index_end-index_password-1);

            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            while (receivedData_global == null)
            {
                await Task.Delay(100); // Odczekaj krótki czas przed ponownym sprawdzeniem
            }
            index_platform = receivedData_global.IndexOf("ptfr:") + 5;
            index_username = receivedData_global.IndexOf("usrn:") + 5;
            index_password = receivedData_global.IndexOf("pssw:") + 5;
            index_end = receivedData_global.IndexOf("\r") + 1;
            label7.Text = receivedData_global.Substring(index_platform, index_username - index_platform - 5);
            label6.Text = receivedData_global.Substring(index_username, index_password - index_username - 5);
            label5.Text = receivedData_global.Substring(index_password, index_end - index_password - 1);

            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            while (receivedData_global == null)
            {
                await Task.Delay(100); // Odczekaj krótki czas przed ponownym sprawdzeniem
            }
            index_platform = receivedData_global.IndexOf("ptfr:") + 5;
            index_username = receivedData_global.IndexOf("usrn:") + 5;
            index_password = receivedData_global.IndexOf("pssw:") + 5;
            index_end = receivedData_global.IndexOf("\r") + 1;
            label10.Text = receivedData_global.Substring(index_platform, index_username - index_platform - 5);
            label9.Text = receivedData_global.Substring(index_username, index_password - index_username - 5);
            label8.Text = receivedData_global.Substring(index_password, index_end - index_password - 1);

            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            while (receivedData_global == null)
            {
                await Task.Delay(100); // Odczekaj krótki czas przed ponownym sprawdzeniem
            }
            index_platform = receivedData_global.IndexOf("ptfr:") + 5;
            index_username = receivedData_global.IndexOf("usrn:") + 5;
            index_password = receivedData_global.IndexOf("pssw:") + 5;
            index_end = receivedData_global.IndexOf("\r") + 1;
            label13.Text = receivedData_global.Substring(index_platform, index_username - index_platform - 5);
            label12.Text = receivedData_global.Substring(index_username, index_password - index_username - 5);
            label11.Text = receivedData_global.Substring(index_password, index_end - index_password - 1);

            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            while (receivedData_global == null)
            {
                await Task.Delay(100); // Odczekaj krótki czas przed ponownym sprawdzeniem
            }
            index_platform = receivedData_global.IndexOf("ptfr:") + 5;
            index_username = receivedData_global.IndexOf("usrn:") + 5;
            index_password = receivedData_global.IndexOf("pssw:") + 5;
            index_end = receivedData_global.IndexOf("\r") + 1;
            label16.Text = receivedData_global.Substring(index_platform, index_username - index_platform - 5);
            label15.Text = receivedData_global.Substring(index_username, index_password - index_username - 5);
            label14.Text = receivedData_global.Substring(index_password, index_end - index_password - 1);

            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            while (receivedData_global == null)
            {
                await Task.Delay(100); // Odczekaj krótki czas przed ponownym sprawdzeniem
            }
            index_platform = receivedData_global.IndexOf("ptfr:") + 5;
            index_username = receivedData_global.IndexOf("usrn:") + 5;
            index_password = receivedData_global.IndexOf("pssw:") + 5;
            index_end = receivedData_global.IndexOf("\r") + 1;
            label19.Text = receivedData_global.Substring(index_platform, index_username - index_platform - 5);
            label18.Text = receivedData_global.Substring(index_username, index_password - index_username - 5);
            label17.Text = receivedData_global.Substring(index_password, index_end - index_password - 1);

            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            while (receivedData_global == null)
            {
                await Task.Delay(100); // Odczekaj krótki czas przed ponownym sprawdzeniem
            }
            index_platform = receivedData_global.IndexOf("ptfr:") + 5;
            index_username = receivedData_global.IndexOf("usrn:") + 5;
            index_password = receivedData_global.IndexOf("pssw:") + 5;
            index_end = receivedData_global.IndexOf("\r") + 1;
            label22.Text = receivedData_global.Substring(index_platform, index_username - index_platform - 5);
            label21.Text = receivedData_global.Substring(index_username, index_password - index_username - 5);
            label20.Text = receivedData_global.Substring(index_password, index_end - index_password - 1);

            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            while (receivedData_global == null)
            {
                await Task.Delay(100); // Odczekaj krótki czas przed ponownym sprawdzeniem
            }
            index_platform = receivedData_global.IndexOf("ptfr:") + 5;
            index_username = receivedData_global.IndexOf("usrn:") + 5;
            index_password = receivedData_global.IndexOf("pssw:") + 5;
            index_end = receivedData_global.IndexOf("\r") + 1;
            label25.Text = receivedData_global.Substring(index_platform, index_username - index_platform - 5);
            label24.Text = receivedData_global.Substring(index_username, index_password - index_username - 5);
            label23.Text = receivedData_global.Substring(index_password, index_end - index_password - 1);

            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            while (receivedData_global == null)
            {
                await Task.Delay(100); // Odczekaj krótki czas przed ponownym sprawdzeniem
            }
            index_platform = receivedData_global.IndexOf("ptfr:") + 5;
            index_username = receivedData_global.IndexOf("usrn:") + 5;
            index_password = receivedData_global.IndexOf("pssw:") + 5;
            index_end = receivedData_global.IndexOf("\r") + 1;
            label28.Text = receivedData_global.Substring(index_platform, index_username - index_platform - 5);
            label27.Text = receivedData_global.Substring(index_username, index_password - index_username - 5);
            label26.Text = receivedData_global.Substring(index_password, index_end - index_password - 1);

            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            while (receivedData_global == null)
            {
                await Task.Delay(100); // Odczekaj krótki czas przed ponownym sprawdzeniem
            }
            index_platform = receivedData_global.IndexOf("ptfr:") + 5;
            index_username = receivedData_global.IndexOf("usrn:") + 5;
            index_password = receivedData_global.IndexOf("pssw:") + 5;
            index_end = receivedData_global.IndexOf("\r") + 1;
            label31.Text = receivedData_global.Substring(index_platform, index_username - index_platform - 5);
            label30.Text = receivedData_global.Substring(index_username, index_password - index_username - 5);
            label29.Text = receivedData_global.Substring(index_password, index_end - index_password - 1);
        }
    }
}
