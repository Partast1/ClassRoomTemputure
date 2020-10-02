using DataAccessLibrary;
using TempClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassRoomTemputure
{
    public class DataHandler
    {
        float humid = 0;
        float temp = 0;
        List<float> readings = new List<float>();
        DatabaseCrud dbc = new DatabaseCrud();
        DeviceReader deviceReader = new DeviceReader();
        public void ReadFromWebServer()
        {
            readings = deviceReader.Read();
            //send readings over til DatabaseHandler
            for (int i = 0; i < readings.Count; i++)
            {
                if (i == 0)
                {
                    temp = readings[i];
                }
                else
                {
                    humid = readings[i];
                }
            }
            WriteToDatabase(humid, temp);
        }
        public void WriteToDatabase(float humid, float temp)
        {
            dbc.WriteDevice(humid, temp);
        }
    }
}
