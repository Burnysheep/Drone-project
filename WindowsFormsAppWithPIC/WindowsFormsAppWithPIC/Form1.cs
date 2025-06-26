using System;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

namespace WindowsFormsAppWithPIC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            selectPort.DataSource = SerialPort.GetPortNames();
            compStatus.Text = "Not Connected";
            compStatus.ForeColor = Color.Violet;
        }

        private void buttConnect_Click(object sender, EventArgs e)
        {
            serialComp.PortName = selectPort.Text;
            serialComp.BaudRate = 9600;
            serialComp.Open();
            if(serialComp.IsOpen) {
                compStatus.Text = "Connected";
                compStatus.ForeColor = Color.Green;
            }
        }

        private void buttDisconnect_Click(object sender, EventArgs e)
        {
            serialComp.Close();
            if (!serialComp.IsOpen)
            {
                compStatus.Text = "Disconnected";
                compStatus.ForeColor = Color.Red;
            }
        }

        private void buttExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttOpen_Click(object sender, EventArgs e)
        {
            if (!serialComp.IsOpen)
            {
                MessageBox.Show("Comp Port not connected");
            }
            else serialComp.Write("1");
        }

        private void buttClose_Click(object sender, EventArgs e)
        {
            if (!serialComp.IsOpen)
            {
                MessageBox.Show("Comp Port not connected");
            }
            else serialComp.Write("0");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!serialComp.IsOpen)
            {
                MessageBox.Show("Comp Port not connected");
            }
            else serialComp.Write("2");
        }
        private void buttReset_Click(object sender, EventArgs e)
        {
            if (!serialComp.IsOpen)
            {
                MessageBox.Show("Comp Port not connected");
            }
            else serialComp.Write("3");
        }

        private void serialComp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string alldata = "";

            alldata = serialComp.ReadLine();
            alldata = alldata.Trim();
            int len = alldata.Length;
            if (len > 0)
            {
                TempText(alldata.Substring(1, 4));
                HumidText(alldata.Substring(5, 4));
                ObstructText(alldata.Substring(9, 1));
                StaffText(alldata.Substring(10));
            }

        }

        private void TempText(string text)
        {
            if (tempDisplay.InvokeRequired)
            {
                tempDisplay.Invoke(new Action<string>(TempText), new object[] { text });
            }
            else
            {
                tempDisplay.Text = text;
            }
        }

        private void HumidText(string text)
        {
            if (humidDisplay.InvokeRequired)
            {
                humidDisplay.Invoke(new Action<string>(HumidText), new object[] { text });
            }
            else
            {
                humidDisplay.Text = text;
            }
        }
        private void StaffText(string text)
        {
            if (staffDisplay.InvokeRequired)
            {
                staffDisplay.Invoke(new Action<string>(StaffText), new object[] { text });
            }
            else
            {
                staffDisplay.Text = text;
            }
        }

        private void ObstructText(string text)
        {
            if (obstructDisplay.InvokeRequired)
            {
                obstructDisplay.Invoke(new Action<string>(ObstructText), new object[] { text });
            }
            else
            {
                obstructDisplay.Text = text;
            }
        }
    }
}
