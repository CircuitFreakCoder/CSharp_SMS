using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_SMS
{
    public partial class Form_SMS_Sender : Form
    {
        private SerialPort _serialPort;
        public Form_SMS_Sender()
        {
            InitializeComponent();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            string number = textBoxNumber.Text;
            string message = textBoxMessage.Text;

            _serialPort = new SerialPort("COM7", 115200);   //Replace "COM7" with corresponding port name

            Thread.Sleep(1000);

            _serialPort.Open();

            Thread.Sleep(1000);

            _serialPort.Write("AT+CMGF=1\r");

            Thread.Sleep(1000);

            _serialPort.Write("AT+CMGS=\"" + number + "\"\r\n");

            Thread.Sleep(1000);

            _serialPort.Write(message + "\x1A");

            Thread.Sleep(1000);

            labelStatus.Text = "Status: Message sent";

            _serialPort.Close();
        }
    }
}
