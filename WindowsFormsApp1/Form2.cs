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

            receivedData_global = serialPort.ReadLine();
            while (receivedData_global == null)
            {
                await Task.Delay(100); // Odczekaj krótki czas przed ponownym sprawdzeniem
                receivedData_global = serialPort.ReadLine();
            }
            int index_platform = receivedData_global.IndexOf("ptfr:") + 5;
            int index_username = receivedData_global.IndexOf("usrn:") + 5;
            int index_password = receivedData_global.IndexOf("pssw:") + 5;           
            int index_end = receivedData_global.IndexOf("\r") + 1;

            label2.Text = receivedData_global.Substring(index_platform, index_username-index_platform-5);
            label3.Text = receivedData_global.Substring(index_username, index_password-index_username-5);
            label4.Text = receivedData_global.Substring(index_password, index_end-index_password-1);

            receivedData_global = null;
            receivedData_global = serialPort.ReadLine();
            while (receivedData_global == null)
            {
                await Task.Delay(100); // Odczekaj krótki czas przed ponownym sprawdzeniem
                receivedData_global = serialPort.ReadLine();
            }
            index_platform = receivedData_global.IndexOf("ptfr:") + 5;
            index_username = receivedData_global.IndexOf("usrn:") + 5;
            index_password = receivedData_global.IndexOf("pssw:") + 5;
            index_end = receivedData_global.IndexOf("\r") + 1;
            label7.Text = receivedData_global.Substring(index_platform, index_username - index_platform - 5);
            label6.Text = receivedData_global.Substring(index_username, index_password - index_username - 5);
            label5.Text = receivedData_global.Substring(index_password, index_end - index_password - 1);

            receivedData_global = null;
            receivedData_global = serialPort.ReadLine();
            while (receivedData_global == null)
            {
                await Task.Delay(100); // Odczekaj krótki czas przed ponownym sprawdzeniem
                receivedData_global = serialPort.ReadLine();
            }
            index_platform = receivedData_global.IndexOf("ptfr:") + 5;
            index_username = receivedData_global.IndexOf("usrn:") + 5;
            index_password = receivedData_global.IndexOf("pssw:") + 5;
            index_end = receivedData_global.IndexOf("\r") + 1;
            label10.Text = receivedData_global.Substring(index_platform, index_username - index_platform - 5);
            label9.Text = receivedData_global.Substring(index_username, index_password - index_username - 5);
            label8.Text = receivedData_global.Substring(index_password, index_end - index_password - 1);

            receivedData_global = null;
            receivedData_global = serialPort.ReadLine();
            while (receivedData_global == null)
            {
                await Task.Delay(100); // Odczekaj krótki czas przed ponownym sprawdzeniem
                receivedData_global = serialPort.ReadLine();
            }
            index_platform = receivedData_global.IndexOf("ptfr:") + 5;
            index_username = receivedData_global.IndexOf("usrn:") + 5;
            index_password = receivedData_global.IndexOf("pssw:") + 5;
            index_end = receivedData_global.IndexOf("\r") + 1;
            label13.Text = receivedData_global.Substring(index_platform, index_username - index_platform - 5);
            label12.Text = receivedData_global.Substring(index_username, index_password - index_username - 5);
            label11.Text = receivedData_global.Substring(index_password, index_end - index_password - 1);

            receivedData_global = null;
            receivedData_global = serialPort.ReadLine();
            while (receivedData_global == null)
            {
                await Task.Delay(100); // Odczekaj krótki czas przed ponownym sprawdzeniem
                receivedData_global = serialPort.ReadLine();
            }
            index_platform = receivedData_global.IndexOf("ptfr:") + 5;
            index_username = receivedData_global.IndexOf("usrn:") + 5;
            index_password = receivedData_global.IndexOf("pssw:") + 5;
            index_end = receivedData_global.IndexOf("\r") + 1;
            label16.Text = receivedData_global.Substring(index_platform, index_username - index_platform - 5);
            label15.Text = receivedData_global.Substring(index_username, index_password - index_username - 5);
            label14.Text = receivedData_global.Substring(index_password, index_end - index_password - 1);

            receivedData_global = null;
            receivedData_global = serialPort.ReadLine();
            while (receivedData_global == null)
            {
                await Task.Delay(100); // Odczekaj krótki czas przed ponownym sprawdzeniem
                receivedData_global = serialPort.ReadLine();
            }
            index_platform = receivedData_global.IndexOf("ptfr:") + 5;
            index_username = receivedData_global.IndexOf("usrn:") + 5;
            index_password = receivedData_global.IndexOf("pssw:") + 5;
            index_end = receivedData_global.IndexOf("\r") + 1;
            label19.Text = receivedData_global.Substring(index_platform, index_username - index_platform - 5);
            label18.Text = receivedData_global.Substring(index_username, index_password - index_username - 5);
            label17.Text = receivedData_global.Substring(index_password, index_end - index_password - 1);

            receivedData_global = null;
            receivedData_global = serialPort.ReadLine();
            while (receivedData_global == null)
            {
                await Task.Delay(100); // Odczekaj krótki czas przed ponownym sprawdzeniem
                receivedData_global = serialPort.ReadLine();
            }
            index_platform = receivedData_global.IndexOf("ptfr:") + 5;
            index_username = receivedData_global.IndexOf("usrn:") + 5;
            index_password = receivedData_global.IndexOf("pssw:") + 5;
            index_end = receivedData_global.IndexOf("\r") + 1;
            label22.Text = receivedData_global.Substring(index_platform, index_username - index_platform - 5);
            label21.Text = receivedData_global.Substring(index_username, index_password - index_username - 5);
            label20.Text = receivedData_global.Substring(index_password, index_end - index_password - 1);

            receivedData_global = null;
            receivedData_global = serialPort.ReadLine();
            while (receivedData_global == null)
            {
                await Task.Delay(100); // Odczekaj krótki czas przed ponownym sprawdzeniem
                receivedData_global = serialPort.ReadLine();
            }
            index_platform = receivedData_global.IndexOf("ptfr:") + 5;
            index_username = receivedData_global.IndexOf("usrn:") + 5;
            index_password = receivedData_global.IndexOf("pssw:") + 5;
            index_end = receivedData_global.IndexOf("\r") + 1;
            label25.Text = receivedData_global.Substring(index_platform, index_username - index_platform - 5);
            label24.Text = receivedData_global.Substring(index_username, index_password - index_username - 5);
            label23.Text = receivedData_global.Substring(index_password, index_end - index_password - 1);

            receivedData_global = null;
            receivedData_global = serialPort.ReadLine();
            while (receivedData_global == null)
            {
                await Task.Delay(100); // Odczekaj krótki czas przed ponownym sprawdzeniem
                receivedData_global = serialPort.ReadLine();
            }
            index_platform = receivedData_global.IndexOf("ptfr:") + 5;
            index_username = receivedData_global.IndexOf("usrn:") + 5;
            index_password = receivedData_global.IndexOf("pssw:") + 5;
            index_end = receivedData_global.IndexOf("\r") + 1;
            label28.Text = receivedData_global.Substring(index_platform, index_username - index_platform - 5);
            label27.Text = receivedData_global.Substring(index_username, index_password - index_username - 5);
            label26.Text = receivedData_global.Substring(index_password, index_end - index_password - 1);

            receivedData_global = null;
            receivedData_global = serialPort.ReadLine();
            while (receivedData_global == null)
            {
                await Task.Delay(100); // Odczekaj krótki czas przed ponownym sprawdzeniem
                receivedData_global = serialPort.ReadLine();
            }
            index_platform = receivedData_global.IndexOf("ptfr:") + 5;
            index_username = receivedData_global.IndexOf("usrn:") + 5;
            index_password = receivedData_global.IndexOf("pssw:") + 5;
            index_end = receivedData_global.IndexOf("\r") + 1;
            label31.Text = receivedData_global.Substring(index_platform, index_username - index_platform - 5);
            label30.Text = receivedData_global.Substring(index_username, index_password - index_username - 5);
            label29.Text = receivedData_global.Substring(index_password, index_end - index_password - 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
            var newform = new Form3(0);
            newform.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
                var newform = new Form3(1);
                newform.Show();
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
                var newform = new Form3(9);
                newform.Show();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
                var newform = new Form3(2);
                newform.Show();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
                var newform = new Form3(3);
                newform.Show();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
                var newform = new Form3(4);
                newform.Show();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
                var newform = new Form3(5);
                newform.Show();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
                var newform = new Form3(6);
                newform.Show();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
                var newform = new Form3(7);
                newform.Show();
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
                var newform = new Form3(8);
                newform.Show();
            }
        }

        private void SimulateKeyboardInput(string textToType)
        {
            // Odczekaj kilka sekund przed rozpoczęciem symulacji
            //Thread.Sleep(2000);

            // Symuluj naciśnięcie i zwolnienie każdego znaku w tekście
            foreach (char c in textToType)
            {
                // Symuluj naciśnięcie klawisza
                SendKeys.SendWait(c.ToString());

                // Odczekaj krótki czas przed przesłaniem kolejnego znaku
                //Thread.Sleep(100);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread.Sleep(3000);
            SimulateKeyboardInput(label3.Text);
            SendKeys.SendWait("{TAB}");
            SimulateKeyboardInput(label4.Text);
            SendKeys.SendWait("{ENTER}");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Thread.Sleep(3000);
            SimulateKeyboardInput(label6.Text);
            SendKeys.SendWait("{TAB}");
            SimulateKeyboardInput(label5.Text);
            SendKeys.SendWait("{ENTER}");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Thread.Sleep(3000);
            SimulateKeyboardInput(label9.Text);
            SendKeys.SendWait("{TAB}");
            SimulateKeyboardInput(label8.Text);
            SendKeys.SendWait("{ENTER}");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Thread.Sleep(3000);
            SimulateKeyboardInput(label12.Text);
            SendKeys.SendWait("{TAB}");
            SimulateKeyboardInput(label11.Text);
            SendKeys.SendWait("{ENTER}");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Thread.Sleep(3000);
            SimulateKeyboardInput(label15.Text);
            SendKeys.SendWait("{TAB}");
            SimulateKeyboardInput(label14.Text);
            SendKeys.SendWait("{ENTER}");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Thread.Sleep(3000);
            SimulateKeyboardInput(label18.Text);
            SendKeys.SendWait("{TAB}");
            SimulateKeyboardInput(label17.Text);
            SendKeys.SendWait("{ENTER}");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Thread.Sleep(3000);
            SimulateKeyboardInput(label21.Text);
            SendKeys.SendWait("{TAB}");
            SimulateKeyboardInput(label20.Text);
            SendKeys.SendWait("{ENTER}");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Thread.Sleep(3000);
            SimulateKeyboardInput(label24.Text);
            SendKeys.SendWait("{TAB}");
            SimulateKeyboardInput(label23.Text);
            SendKeys.SendWait("{ENTER}");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Thread.Sleep(3000);
            SimulateKeyboardInput(label27.Text);
            SendKeys.SendWait("{TAB}");
            SimulateKeyboardInput(label26.Text);
            SendKeys.SendWait("{ENTER}");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Thread.Sleep(3000);
            SimulateKeyboardInput(label30.Text);
            SendKeys.SendWait("{TAB}");
            SimulateKeyboardInput(label29.Text);
            SendKeys.SendWait("{ENTER}");
        }

        private void button22_Click(object sender, EventArgs e)
        {
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
                var newform = new Form4();
                newform.Show();
            }
        }
    }
}
