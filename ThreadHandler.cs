using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ClassRoomTemputure
{
    public class ThreadHandler
    {
        DataHandler dh = new DataHandler();
        public void DeviceThread()
        {
            while (true)
            {
                dh.ReadFromWebServer();
                Thread.Sleep(5000);
            }
        }
    }
}