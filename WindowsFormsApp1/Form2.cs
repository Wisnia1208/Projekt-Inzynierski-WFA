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
        private SerialPort serialPort;
        private string receivedData_global;

        public Form2(Form1 form1,SerialPort serialPort)
        {
            InitializeComponent();
            form1Reference = form1;
            this.serialPort=serialPort;
            this.FormClosing += Form2_FormClosing;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1Reference.Close();
            Application.Exit();
        }

        private string decode(string info)
        {
            char[] chars = info.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = (char)(chars[i] + 1);
            }
            return new string(chars);
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
   

            try
            {
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
                await Task.Delay(100);
                receivedData_global = serialPort.ReadLine();
            }
            int index_platform = receivedData_global.IndexOf("ptfr:") + 5;
            int index_username = receivedData_global.IndexOf("usrn:") + 5;
            int index_password = receivedData_global.IndexOf("pssw:") + 5;           
            int index_end = receivedData_global.IndexOf("\r") + 1;

            label2.Text = decode(receivedData_global.Substring(index_platform, index_username-index_platform-6));
            label3.Text = decode(receivedData_global.Substring(index_username, index_password-index_username-6));
            label4.Text = decode(receivedData_global.Substring(index_password, index_end-index_password-1));

            receivedData_global = null;
            receivedData_global = serialPort.ReadLine();
            while (receivedData_global == null)
            {
                await Task.Delay(100);
                receivedData_global = serialPort.ReadLine();
            }
            index_platform = receivedData_global.IndexOf("ptfr:") + 5;
            index_username = receivedData_global.IndexOf("usrn:") + 5;
            index_password = receivedData_global.IndexOf("pssw:") + 5;
            index_end = receivedData_global.IndexOf("\r") + 1;
            label7.Text = decode(receivedData_global.Substring(index_platform, index_username - index_platform - 6));
            label6.Text = decode(receivedData_global.Substring(index_username, index_password - index_username - 6));
            label5.Text = decode(receivedData_global.Substring(index_password, index_end - index_password - 1));

            receivedData_global = null;
            receivedData_global = serialPort.ReadLine();
            while (receivedData_global == null)
            {
                await Task.Delay(100);
                receivedData_global = serialPort.ReadLine();
            }
            index_platform = receivedData_global.IndexOf("ptfr:") + 5;
            index_username = receivedData_global.IndexOf("usrn:") + 5;
            index_password = receivedData_global.IndexOf("pssw:") + 5;
            index_end = receivedData_global.IndexOf("\r") + 1;
            label10.Text = decode(receivedData_global.Substring(index_platform, index_username - index_platform - 6));
            label9.Text = decode(receivedData_global.Substring(index_username, index_password - index_username - 6));
            label8.Text = decode(receivedData_global.Substring(index_password, index_end - index_password - 1));

            receivedData_global = null;
            receivedData_global = serialPort.ReadLine();
            while (receivedData_global == null)
            {
                await Task.Delay(100);
                receivedData_global = serialPort.ReadLine();
            }
            index_platform = receivedData_global.IndexOf("ptfr:") + 5;
            index_username = receivedData_global.IndexOf("usrn:") + 5;
            index_password = receivedData_global.IndexOf("pssw:") + 5;
            index_end = receivedData_global.IndexOf("\r") + 1;
            label13.Text = decode(receivedData_global.Substring(index_platform, index_username - index_platform - 6));
            label12.Text = decode(receivedData_global.Substring(index_username, index_password - index_username - 6));
            label11.Text = decode(receivedData_global.Substring(index_password, index_end - index_password - 1));

            receivedData_global = null;
            receivedData_global = serialPort.ReadLine();
            while (receivedData_global == null)
            {
                await Task.Delay(100);
                receivedData_global = serialPort.ReadLine();
            }
            index_platform = receivedData_global.IndexOf("ptfr:") + 5;
            index_username = receivedData_global.IndexOf("usrn:") + 5;
            index_password = receivedData_global.IndexOf("pssw:") + 5;
            index_end = receivedData_global.IndexOf("\r") + 1;
            label16.Text = decode(receivedData_global.Substring(index_platform, index_username - index_platform - 6));
            label15.Text = decode(receivedData_global.Substring(index_username, index_password - index_username - 6));
            label14.Text = decode(receivedData_global.Substring(index_password, index_end - index_password - 1));

            receivedData_global = null;
            receivedData_global = serialPort.ReadLine();
            while (receivedData_global == null)
            {
                await Task.Delay(100);
                receivedData_global = serialPort.ReadLine();
            }
            index_platform = receivedData_global.IndexOf("ptfr:") + 5;
            index_username = receivedData_global.IndexOf("usrn:") + 5;
            index_password = receivedData_global.IndexOf("pssw:") + 5;
            index_end = receivedData_global.IndexOf("\r") + 1;
            label19.Text = decode(receivedData_global.Substring(index_platform, index_username - index_platform - 6));
            label18.Text = decode(receivedData_global.Substring(index_username, index_password - index_username - 6));
            label17.Text = decode(receivedData_global.Substring(index_password, index_end - index_password - 1));

            receivedData_global = null;
            receivedData_global = serialPort.ReadLine();
            while (receivedData_global == null)
            {
                await Task.Delay(100);
                receivedData_global = serialPort.ReadLine();
            }
            index_platform = receivedData_global.IndexOf("ptfr:") + 5;
            index_username = receivedData_global.IndexOf("usrn:") + 5;
            index_password = receivedData_global.IndexOf("pssw:") + 5;
            index_end = receivedData_global.IndexOf("\r") + 1;
            label22.Text = decode(receivedData_global.Substring(index_platform, index_username - index_platform - 6));
            label21.Text = decode(receivedData_global.Substring(index_username, index_password - index_username - 6));
            label20.Text = decode(receivedData_global.Substring(index_password, index_end - index_password - 1));

            receivedData_global = null;
            receivedData_global = serialPort.ReadLine();
            while (receivedData_global == null)
            {
                await Task.Delay(100);
                receivedData_global = serialPort.ReadLine();
            }
            index_platform = receivedData_global.IndexOf("ptfr:") + 5;
            index_username = receivedData_global.IndexOf("usrn:") + 5;
            index_password = receivedData_global.IndexOf("pssw:") + 5;
            index_end = receivedData_global.IndexOf("\r") + 1;
            label25.Text = decode(receivedData_global.Substring(index_platform, index_username - index_platform - 6));
            label24.Text = decode(receivedData_global.Substring(index_username, index_password - index_username - 6));
            label23.Text = decode(receivedData_global.Substring(index_password, index_end - index_password - 1));

            receivedData_global = null;
            receivedData_global = serialPort.ReadLine();
            while (receivedData_global == null)
            {
                await Task.Delay(100);
                receivedData_global = serialPort.ReadLine();
            }
            index_platform = receivedData_global.IndexOf("ptfr:") + 5;
            index_username = receivedData_global.IndexOf("usrn:") + 5;
            index_password = receivedData_global.IndexOf("pssw:") + 5;
            index_end = receivedData_global.IndexOf("\r") + 1;
            label28.Text = decode(receivedData_global.Substring(index_platform, index_username - index_platform - 6));
            label27.Text = decode(receivedData_global.Substring(index_username, index_password - index_username - 6));
            label26.Text = decode(receivedData_global.Substring(index_password, index_end - index_password - 1));

            receivedData_global = null;
            receivedData_global = serialPort.ReadLine();
            while (receivedData_global == null)
            {
                await Task.Delay(100);
                receivedData_global = serialPort.ReadLine();
            }
            index_platform = receivedData_global.IndexOf("ptfr:") + 5;
            index_username = receivedData_global.IndexOf("usrn:") + 5;
            index_password = receivedData_global.IndexOf("pssw:") + 5;
            index_end = receivedData_global.IndexOf("\r") + 1;
            label31.Text = decode(receivedData_global.Substring(index_platform, index_username - index_platform - 6));
            label30.Text = decode(receivedData_global.Substring(index_username, index_password - index_username - 6));
            label29.Text = decode(receivedData_global.Substring(index_password, index_end - index_password - 1));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
            var newform = new Form3(0,serialPort);
            newform.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
                var newform = new Form3(1,serialPort);
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
                var newform = new Form3(9, serialPort);
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
                var newform = new Form3(2,serialPort);
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
                var newform = new Form3(3, serialPort);
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
                var newform = new Form3(4,serialPort);
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
                var newform = new Form3(5, serialPort);
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
                var newform = new Form3(6, serialPort);
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
                var newform = new Form3(7, serialPort);
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
                var newform = new Form3(8, serialPort);
                newform.Show();
            }
        }

        private void SimulateKeyboardInput(string textToType)
        {
            foreach (char c in textToType)
            {
                SendKeys.SendWait(c.ToString());
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
                var newform = new Form4(serialPort);
                newform.Show();
            }
        }
    }
}
