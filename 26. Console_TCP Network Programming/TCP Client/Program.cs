using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP_Client
{
    class TcpClient
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Connecting To Server ... ");
            IPAddress ip = IPAddress.Parse("127.0.0.1");    //IP on the localHost to connect to server ... wohi ip hogi jo server ki ha
            int port = 8080;   //same as server
            IPEndPoint remoteEndPoint = new IPEndPoint(ip, port);   //endpoint banega client ka b usi ip aur port pe
            Socket clientSocket = null; //server se data lene aur bhejne k liye socket use hoga
            try
            {
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.Connect(remoteEndPoint);   //connecting the cliets socket to the remote endpoint jispe server ha
                Console.WriteLine("Connected to the Server");
                //ab user se string lenge usko bytes me convert karenge aur server ko bhej denge
                Console.WriteLine("Enter String to be Reversed");
                string toSend = Console.ReadLine();
                byte[] toSend_ConvertedToBytes = Encoding.ASCII.GetBytes(toSend);   //ye string bytes me convert hoga ku k network pe hum sirf bytes me data bhej skte hain
                clientSocket.Send(toSend_ConvertedToBytes); //aur ye bhej diya
                //ab aik byte array me server se reverse hua va string recieve krenge aur usko string me convert krke display kr denge
                byte[] recbytes = new byte[1024];
                clientSocket.Receive(recbytes);
                string reversedStringRecieved = Encoding.ASCII.GetString(recbytes);
                Console.WriteLine("Reversed : {0}", reversedStringRecieved);
                clientSocket.Close();   //End Connection when work is done
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }

            
        }
    }
}
