using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Tcp_Server;

namespace TCP_Server
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
                    string name = Encoding.ASCII.GetString(recBytes, 0, numBytes);    //convert bytes to String
                    DataTable results = dbConnection.SearchByName(name);    //get results in Datatable
                    byte[] bytesToSend = serailize(results);  //convert to bytes
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