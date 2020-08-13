using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Data;

// In the Same way any other DataType or DataStructure can be sent and recieved in Network
namespace Tcp_Client
{
    class TcpClient
    {
        static void Main(string[] args)
        {
            DataTable table = new DataTable();  //create table
            table.Columns.Add("RollNumber");   //add columns
            table.Columns.Add("Message");

            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("Connecting to the Server...");
            try
            {
                clientSocket.Connect(remoteEndPoint);
                Console.WriteLine("Connection Established");
                byte[] bytesToSend = serailize(table);  //Convert Table To Bytes
                clientSocket.Send(bytesToSend); // send to the server
                byte[] recBytes = new byte[10240];  //to save the recieved DataTable from the server
                int numBytes = clientSocket.Receive(recBytes);  //get bytes from server
                table = deserailize(recBytes);  // conver the bytes into DataTable
                //Now Display The DataTable Rows added by the Server
                Console.WriteLine("Displaying Recieved DataTable");
                foreach (DataRow r in table.Rows)
                {
                    Console.WriteLine("{0}\t\t{1}", r["RollNumber"], r["Message"]);
                }
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            clientSocket.Close();
        }
        private static DataTable deserailize(byte[] dataTOCOnvert)   //This Function converts recieved bytes into DataTable
        {
            System.IO.MemoryStream stream = new System.IO.MemoryStream(dataTOCOnvert);
            System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            DataTable table = (DataTable)formatter.Deserialize(stream);
            return table;
        }
        private static byte[] serailize(DataTable table)    //This Function Converts the DatTable into bytes to send it
        {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            formatter.Serialize(stream, table);
            byte[] byteArray = stream.GetBuffer();
            return byteArray;
        }
    }
}