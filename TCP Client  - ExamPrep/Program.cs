using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP_Client____ExamPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient connectionSocket = new TcpClient("localhost", 8989);

            Stream ns = connectionSocket.GetStream();
            StreamWriter sw = new StreamWriter(ns);
            StreamReader sr = new StreamReader(ns);
            sw.AutoFlush = true;

            while (true)
            {
                string message = Console.ReadLine();
                sw.WriteLine(message);
                string answer = sr.ReadLine();
                Console.WriteLine($"Server: {message}");
            }

            string s = Console.ReadLine();

            ns.Close();
            connectionSocket.Close();
        }
    }
}
