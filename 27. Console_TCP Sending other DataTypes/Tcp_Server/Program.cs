using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Data;

namespace Tcp_Server
{
    class TcpServer
    {
        static void Main(string[] args)
        {
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            Socket clientSocket = null;
            try
            {
                Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(localEndPoint);
                serverSocket.Listen(1);
                Console.WriteLine("Waiting for a connection...");
                while (true)
                {
                    clientSocket = serverSocket.Accept();
                    Console.WriteLine("Connection Accepted...");
                    byte[] recBytes = new byte[10240];
                    int numBytes = clientSocket.Receive(recBytes);  //bytes recieved
                    DataTable table = deserailize(recBytes);    //convert bytes to Table
                    table.Rows.Add(170, "Hello");   //add columns to the table
                    byte[] bytesToSend = serailize(table);  //conver to bytes
                    clientSocket.Send(bytesToSend); //send Back to the client
                    clientSocket.Close();   //jb kaam ho jaye uska toh us se connection tod le
                    Console.WriteLine("Client Disconnected...");
                }
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
}
        private static DataTable deserailize(byte[] dataTOCOnvert)   //This Function converts recieved bytes into DataTable
        {
            System.IO.MemoryStream stream = new System.IO.MemoryStream(dataTOCOnvert);
            System.Runtime.Serialization.IFormatter formatter = new System.Runtime.
            Serialization.Formatters.Binary.BinaryFormatter();
            DataTable table = (DataTable)formatter.Deserialize(stream);
            return table;
        }
        private static byte[] serailize(DataTable table)    //This Function Converts the DatTable into bytes to send it
        {
            //serialize the DataTable and send the serialized DataTable to the client
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            System.Runtime.Serialization.IFormatter formatter = new System.Runtime.
            Serialization.Formatters.Binary.BinaryFormatter();
            formatter.Serialize(stream, table);
            byte[] byteArray = stream.GetBuffer();
            return byteArray;
        }
    }
}
