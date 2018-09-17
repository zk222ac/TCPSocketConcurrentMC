﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPSocketConcurrentM
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            TcpListener serverSocket = new TcpListener(ip, 6789);

            //TcpListener serverSocket = new TcpListener(6789);
            serverSocket.Start();


            while (true)
            {
                Console.WriteLine("Server is being ready for handshake");
                TcpClient connectionSocket = serverSocket.AcceptTcpClient();
                Console.WriteLine("Server activated now");
                EchoService service = new EchoService(connectionSocket);
                //Use Task and delegates

                //Task solution with delegates
                Task.Factory.StartNew(() => service.DoIt());

                //OR
                //Task.Factory.StartNew(service.DoIt);

                //OR
                //Task.Run(( ) => service.DoIt());

                //OR
                //Thread solution
                //Thread myThread = new Thread(new ThreadStart(service.DoIt));

                //OR
                //Thread myThread = new Thread(service.DoIt);
                //myThread.Start();

            }

            serverSocket.Stop();
        }
    }
}
