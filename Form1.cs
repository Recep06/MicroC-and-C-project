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
using System.IO;


namespace 
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = SerialPort.GetPortNames();
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = comboBox1.Text;
            serialPort1.BaudRate = 9600;
     
            serialPort1.Open();

            timer1.Start();

            button6.Enabled = false;
            button5.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            button6.Enabled = true;
            button5.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            serialPort1.DiscardOutBuffer();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.Write(Convert.ToString("1"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Write(Convert.ToString("2"));
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
           try
            {
               
                string sonuc = serialPort1.ReadExisting();
                textBox1.Text = sonuc;
               
                StreamWriter SW = File.AppendText(Application.StartupPath + "\\veri.txt");
                string satır = "duman=";
                SW.Write(satır);
                SW.WriteLine(sonuc);
                SW.Close();

            }
            catch(Exception)
            {
                timer1.Stop();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

     

        

        private void button3_Click_1(object sender, EventArgs e)
        {
            serialPort1.Write(Convert.ToString("3"));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            serialPort1.Write(Convert.ToString("4"));
        }
    }
}
