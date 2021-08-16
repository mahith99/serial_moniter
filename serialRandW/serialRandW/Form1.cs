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

namespace serialRandW
{
    
    public partial class Form1 : Form
    {
        int flag;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Write(textBox1.Text);
                textBox1.Text = "";
            }
            catch
            {
                MessageBox.Show("error:2");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(SerialPort.GetPortNames());
                comboBox1.Text = "";
                comboBox2.Text = "baud";
            }
            catch
            {
                MessageBox.Show("error");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Text = "CONNECT";
            flag = 0;
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(SerialPort.GetPortNames());
            comboBox1.Text = "";
            comboBox2.Text = "baud";
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (flag==0) {
                try
                {
                    serialPort1.PortName = comboBox1.Text;
                    serialPort1.BaudRate = int.Parse(comboBox2.Text);
                    serialPort1.Open();
                    timer1.Start();
                    button2.Text = "DISCONNECT";
                    flag = 1;
                    groupBox1.Enabled = false;
                    groupBox2.Enabled = true;
                    button1.Enabled = false;
                }
                catch
                {
                    MessageBox.Show("error:1");
                }
            }
            else if (flag == 1)
            {
                try
                {
                    serialPort1.Close();
                    timer1.Stop();
                    button2.Text = "CONNECT";
                    flag = 0;
                    groupBox1.Enabled = true;
                    groupBox2.Enabled = false;
                    button1.Enabled = true;
                    richTextBox1.Text = "";
                }
                catch
                {
                    MessageBox.Show("error");
                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen) 
                { 
                    richTextBox1.Text += serialPort1.ReadExisting();
                }
            }
            catch
            {
                MessageBox.Show("error:3");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }
    }
}
