using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using DataAccessLibrary;

namespace ClassRoomTemputure
{
    public class DeviceReader
    {
        WebserverCrud webserverCrud = new WebserverCrud();
        DataFactory df = new DataFactory();
        public List<float> Read()
        {
            List<float> readings = new List<float>();
            //Opening TcpClient
            using (TcpClient Client = df.CreateTcpClient())
            {
                //Connection method from library
                webserverCrud.Connect(Client);
                //Starting network stream
                using (NetworkStream netStream = Client.GetStream())
                {
                    //BinaryWriter wries /n to webserver
                    webserverCrud.Write(netStream);
                    //Reads the webserver and returns a list<float>
                    readings = webserverCrud.Read(netStream);
                    return readings;
                }
            }
        }
    }
}
