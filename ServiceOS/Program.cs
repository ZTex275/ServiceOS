using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Data;
using System.Diagnostics;

namespace ServiceOS
{
    public class Program
    {
        static int port = 8005; // ���� ��� ������ �������� ��������
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            // �������� ������ ��� ������� ������
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);

            // ������� �����
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                // ��������� ����� � ��������� ������, �� ������� ����� ��������� ������
                listenSocket.Bind(ipPoint);

                // �������� �������������
                listenSocket.Listen(10);

                Debug.WriteLine("������ �������. �������� �����������...");

                while (true)
                {
                    Socket handler = listenSocket.Accept();
                    // �������� ���������
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0; // ���������� ���������� ������
                    byte[] data = new byte[256]; // ����� ��� ���������� ������

                    do
                    {
                        bytes = handler.Receive(data);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (handler.Available > 0);

                    Debug.WriteLine(DateTime.Now.ToShortTimeString() + ": " + builder.ToString());

                    // ���������� �����
                    string message = "���� ��������� ����������";
                    data = Encoding.Unicode.GetBytes(message);
                    handler.Send(data);
                    // ��������� �����
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
