using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using DataAccessLibrary;
using TempClassLibrary;

namespace ClassRoomTemputure
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadHandler th = new ThreadHandler();
            Thread t = new Thread(new ThreadStart(th.DeviceThread));
            t.Start();
            Console.ReadLine();
        }
    }
}