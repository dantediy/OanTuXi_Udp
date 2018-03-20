using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 1234);
            server.Bind(ipep);
            EndPoint ep = ipep;

            byte[] recv = new byte[20];
            server.ReceiveFrom(recv, ref ep);

            int clientR = Convert.ToInt32(Encoding.ASCII.GetString(recv));

            Random r = new Random();

            while (true)
            {
                int serverR = r.Next(0, 3);
                if ((serverR == 0 && clientR == 0) || (serverR == 1 && clientR == 1) || (serverR == 2 && clientR == 2))
                {
                    byte[] sendData = Encoding.ASCII.GetBytes("Hoa");
                    server.SendTo(sendData, ep);
                }
                if (serverR == 0 && clientR == 1)
                {
                    byte[] sendData = Encoding.ASCII.GetBytes("Thang");
                    server.SendTo(sendData, ep);
                }
                if (serverR == 0 && clientR == 2)
                {
                    byte[] sendData = Encoding.ASCII.GetBytes("Thua");
                    server.SendTo(sendData, ep);
                }
                if (serverR == 1 && clientR == 0)
                {
                    byte[] sendData = Encoding.ASCII.GetBytes("Thua");
                    server.SendTo(sendData, ep);
                }
                if (serverR == 1 && clientR == 2)
                {
                    byte[] sendData = Encoding.ASCII.GetBytes("Thang");
                    server.SendTo(sendData, ep);
                }
                if (serverR == 2 && clientR == 0)
                {
                    byte[] sendData = Encoding.ASCII.GetBytes("Thang");
                    server.SendTo(sendData, ep);
                }
                if (serverR == 2 && clientR == 1)
                {
                    byte[] sendData = Encoding.ASCII.GetBytes("Thua");
                    server.SendTo(sendData, ep);
                }
            }
            server.Close();
        }
    }
}
