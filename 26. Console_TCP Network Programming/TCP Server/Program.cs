using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace TCP_Server
{
    class TcpServer
    {    //In this Program we will make the server which simply accepts a string from client and returns its reverse
        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");    //Create an IP and use the localhost ie 127.0.0.1  
            int port = 8080;    //any port not in use
            IPEndPoint localEndPoint = new IPEndPoint(ip, port);    //create and initialize an endpoint with ip and port using its constructor
            Socket clientSocket = null; // socket acts as the communication link between server and its clients
            try
            {
                Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);   //Initialize the socket on TCP Protocol
                serverSocket.Bind(localEndPoint);    //binding the socket to the localendpoint created on the ip and port
                serverSocket.Listen(1);  //start listenting to requets
                Console.WriteLine("Server up!");
                Console.WriteLine("Waiting for a connection...");
                while (true)
                {
                    clientSocket = serverSocket.Accept();   //accept requests from clients
                    Console.WriteLine("Connection Accepted...");
                    //*Data Recieved is always in bytes*
                    byte[] recbytes = new byte[1024];  // create a byte array to recieve the bytes sent by clients 
                    int numBytes = clientSocket.Receive(recbytes);    // saves the recieved bytes in recbytes and no of bytes recieved in numBytes
                    string TheRecievedStringData = Encoding.ASCII.GetString(recbytes, 0, numBytes); //convert the data recieved in bytes to string
                    TheRecievedStringData = ReverseString(TheRecievedStringData);    //reverse the string
                    byte[] SendBack = Encoding.ASCII.GetBytes(TheRecievedStringData);   //convert the reversed string to bytes to send it back to the client .... *Every thing being send is converted to bytes first*
                    clientSocket.Send(SendBack);    //sending bytes back to the connected client 
                    clientSocket.Close();   //connection bnd krde us se
                    Console.WriteLine("Client Disconnected...");
                }
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            clientSocket.Close();   //close connection with the client
        }
        public static string ReverseString(string myStr)    //function to reverse the string
        {
            char[] myArr = myStr.ToCharArray();
            Array.Reverse(myArr);
            return new string(myArr);
        }
    }
}
