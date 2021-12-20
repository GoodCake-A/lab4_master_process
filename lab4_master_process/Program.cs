using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.IO.MemoryMappedFiles;


namespace lab4_master_process
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Socket listenSocket = ConfigureSocket();

                Console.WriteLine("Сервер запущен. Ожидание подключений...");

                while (true)
                {
                    Socket handler = listenSocket.Accept();
                    Console.WriteLine("Установленно соединение");
                    CreateProcess(handler);
                    Console.WriteLine("Соединение закрыто");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        static public Socket ConfigureSocket()
        {
            // получаем адреса для запуска сокета
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(ServerSettings.ServerIp), ServerSettings.ServerPort);

            // создаем сокет
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // связываем сокет с локальной точкой, по которой будем принимать данные
            listenSocket.Bind(ipPoint);

            // начинаем прослушивание
            listenSocket.Listen(ServerSettings.RequestQueueLength);

            return listenSocket;

        }

        static public void CreateProcess(Socket requestHandler)
        {
            Process myProcess = new Process();
        }

    }
}
