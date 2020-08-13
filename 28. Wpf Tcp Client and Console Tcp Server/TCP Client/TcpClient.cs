using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP_Client
{
    class TcpClient
    {
        private static Socket clientSocket { set; get; }
        public static void Create_Connection()
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");    //IP on the localHost to connect to server ... wohi ip hogi jo server ki ha
            int port = 8080;   //same as server
            IPEndPoint remoteEndPoint = new IPEndPoint(ip, port);   //endpoint banega client ka b usi ip aur port pe
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(remoteEndPoint);   //connecting the cliets socket to the remote endpoint jispe server ha
        }
        public static DataTable Search(string name) //this function sends the name string to the server and returns the datatable with results
        {
            byte[] toSend_ConvertedToBytes = Encoding.ASCII.GetBytes(name);
            clientSocket.Send(toSend_ConvertedToBytes);
            byte[] recbytes = new byte[10240];  //size is bigger for DataTable
            clientSocket.Receive(recbytes);
            DataTable result = deserailize(recbytes);   //convert recieved bytes to DataTable
            return result;  //return the result table
        }
        private static DataTable deserailize(byte[] dataTOCOnvert)   //This Function converts recieved bytes into DataTable
        {
            System.IO.MemoryStream stream = new System.IO.MemoryStream(dataTOCOnvert);
            System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            DataTable table = (DataTable)formatter.Deserialize(stream);
            return table;
        }
    }
}
