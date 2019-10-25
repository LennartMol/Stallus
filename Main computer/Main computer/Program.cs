using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_computer
{
    class Program
    {
        static Socket_server server = new Socket_server();
        static void Main(string[] args)
        {
            server.startServer();
            while (true)
            {
                Console.WriteLine(server.receiveMessage());
            }
        }
    }
}
