﻿using System;
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
using System.Security.Cryptography;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public SerialPort serialPort;
        private string receivedData_global=null;
        private int login_count=0;
        

        public Form1()
        {
            InitializeComponent();
            FindESP32Port();
            this.FormClosing += Form1_FormClosing;
        }

        private void FindESP32Port()
        {
            string[] portNames = SerialPort.GetPortNames();

            foreach (string portName in portNames)
            {
                try
                {
                    using (SerialPort port = new SerialPort(portName))
                    {
                        port.BaudRate = 115200; // Ustawienia zgodne z ESP32
                        port.ReadTimeout = 5000; // Timeout odczytu w milisekundach

                        port.Open();

                        // Wysłanie dowolnej informacji do ESP32
                        port.WriteLine("Test");

                        // Odczytanie odpowiedzi
                        string response = port.ReadLine();

                        // Sprawdzenie, czy odpowiedź zawiera oczekiwaną frazę
                        if (response.Contains("incorrect login data\r"))
                        {
                            serialPort = port; // Przypisanie portu do obiektu SerialPort
                            MessageBox.Show($"ESP32 znaleziony na porcie: {portName}", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Obsługa wyjątków, na przykład gdy nie można otworzyć portu
                    Console.WriteLine($"Błąd przy sprawdzaniu portu {portName}: {ex.Message}");
                }
            }

            MessageBox.Show("ESP32 not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
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

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = encode(textBox1.Text);
            string password = encode(maskedTextBox1.Text);

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
                var newform = new Form2(this,serialPort);
                newform.Show();
                this.Hide();
                //this.Close();
            }
            else if (receivedData_global == "incorrect login data\r")
            {
                login_count++;
                if (login_count >= 10)
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
