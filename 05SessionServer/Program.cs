using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using _01UI;
using _04Model;

namespace _05SessionServer
{
    class Program
    {
        private static List<Socket> _connectSocket = new List<Socket>();
        private static Queue<Msg> _msgQu = new Queue<Msg>();
        static void Main(string[] args)
        {
            Console.WriteLine("正在启动Socket服务器…………");
            InitSocket();
            ListenSocket();
            SendMsg();
            Console.ReadKey();
        }

        private static void ListenSocket()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    foreach (var item in _connectSocket)
                    {
                        Console.WriteLine("接受：和客户端的连接状态" + item.Connected);
                        if (item.Connected)
                        {
                            Console.WriteLine("接受端口已连接");
                            var buff = new byte[1024 * 1024];
                            Console.WriteLine("已经准备好接受消息" + DateTime.Now);
                            item.Receive(buff);
                            Console.WriteLine("已接受到一条消息" + DateTime.Now);
                            _msgQu.Enqueue(Tools.DeserializeObject(buff));
                        }
                    }
                }
            });
        }

        private static void SendMsg()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    var temp = _msgQu.Dequeue();
                    if (temp != null)
                    {
                        foreach (var item in _connectSocket)
                        {
                            if (item.Connected)
                            {
                                var buff = Tools.SerializeObject(temp);
                                item.Send(buff, SocketFlags.None);
                            }
                        }
                    }
                }
            });
        }

        private static void InitSocket()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var point = new IPEndPoint(new IPAddress(new Byte[] { 127, 0, 0, 1 }), 60000);
            socket.Bind(point);
            socket.Listen(10);
            Task.Run(() =>
            {
                while (true)
                {
                    var newSocket = socket.Accept();
                    if (newSocket != null)
                    {
                        _connectSocket.Add(newSocket);
                        Console.WriteLine("有一个新连接 " + newSocket.RemoteEndPoint + DateTime.Now);
                    }
                }
            });
        }

    }
}
