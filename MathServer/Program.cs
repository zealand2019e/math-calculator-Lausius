using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace MathServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Server.Start();
        }
    }

    class Server
    {
        public static void Start()
        {
            TcpListener serverSocket = new TcpListener(IPAddress.Loopback, 30001);
            serverSocket.Start();
            TcpClient connectionSocket = serverSocket.AcceptTcpClient();
            Console.WriteLine("Server Activated");
            using (connectionSocket)
            {
                Stream ns = connectionSocket.GetStream();
                StreamReader sr = new StreamReader(ns);
                StreamWriter sw = new StreamWriter(ns);
                sw.AutoFlush = true;
                var message = sr.ReadLine();
                Console.WriteLine(message);
                string[] numberArray = message.Split(" ");
                double firstNumber = Convert.ToDouble(numberArray[0]);
                double secondNumber = Convert.ToDouble(numberArray[2]);
                double result = firstNumber + secondNumber;
                sw.WriteLine(message + " = " + result);
            }
        }
    }
}
