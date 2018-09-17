using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPSocketConcurrentM
{
    class EchoService
    {
        private readonly TcpClient _connectionSocket;

        public EchoService(TcpClient connectionSocket)
        {
            // TODO: Complete member initialization
            this._connectionSocket = connectionSocket;
        }
        internal void DoIt()
        {
            Stream ns = _connectionSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns) {AutoFlush = true};
            // enable automatic flushing
            string message = sr.ReadLine();
            while (!string.IsNullOrEmpty(message))
            {
                Console.WriteLine("Client: " + message);
                var answer = message.ToUpper();
                sw.WriteLine(answer);
                message = sr.ReadLine();

            }
            ns.Close();
            _connectionSocket.Close();
        }
    }
}
