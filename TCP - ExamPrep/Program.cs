using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TCP___ExamPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            //Server
            TcpListener serverSocket = new TcpListener(8989);
            serverSocket.Start();
            TcpClient connectionSocket = serverSocket.AcceptTcpClient();
            Console.WriteLine("Server Activated");

            Stream ns = connectionSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;

            while (true)
            {
                string message = sr.ReadLine();
                Console.WriteLine($"Client: {message}");
                string answer = Console.ReadLine();
                sw.WriteLine(answer);
            }

            string s = Console.ReadLine();

            ns.Close();
            connectionSocket.Close();
            serverSocket.Stop();
        }
    }
}
