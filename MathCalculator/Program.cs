using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace MathCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Client.Start();
        }
    }

    class Client
    {
        public static void Start()
        {
            TcpClient clientSocket = new TcpClient("localhost", 30001);

            using (clientSocket)
            {
                Console.WriteLine("Server found");
                Stream ns = clientSocket.GetStream();
                StreamReader sr = new StreamReader(ns);
                StreamWriter sw = new StreamWriter(ns);
                sw.AutoFlush = true;

                string mathExpression = Console.ReadLine();
                sw.WriteLine(mathExpression);
                var result = sr.ReadLine();
                Console.WriteLine(result);
                Console.ReadLine();
                //Console.WriteLine(mathExpression + " = " + result);
            }
        }
    }
}