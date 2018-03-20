using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    public partial class Form1 : Form
    {
        Socket client;
        EndPoint ep;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Loopback, 1234);
            ep = (EndPoint)ipep;
        }

        private void btnKeo_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Keo";
            byte[] SendData = Encoding.ASCII.GetBytes("0");
            client.SendTo(SendData, ep);
            byte[] recv = new byte[20];
            client.ReceiveFrom(recv, ref ep);
            textBox2.Text = Encoding.ASCII.GetString(recv);
        }

        private void btnBua_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Bua";
            byte[] SendData = Encoding.ASCII.GetBytes("1");
            client.SendTo(SendData, ep);
            byte[] recv = new byte[20];
            client.ReceiveFrom(recv, ref ep);
            textBox2.Text = Encoding.ASCII.GetString(recv);
        }

        private void btnBao_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Bao";
            byte[] SendData = Encoding.ASCII.GetBytes("2");
            client.SendTo(SendData, ep);
            byte[] recv = new byte[20];
            client.ReceiveFrom(recv, ref ep);
            textBox2.Text = Encoding.ASCII.GetString(recv);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            client.Close();
        }
    }
}
