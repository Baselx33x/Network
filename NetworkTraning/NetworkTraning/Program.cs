using System.Net; 
using System.Net.Sockets;
using System.Text;



// Create a new socket using the InterNetwork address family, Stream socket type, and TCP protocol
Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

// Set the IP address to listen on to any available network interface
IPAddress ipAddress = IPAddress.Any;

// Create an endpoint that consists of the IP address and a specific port number (23000 in this case)
IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 23000);

// Bind the socket to the local endpoint
 socket.Bind(localEndPoint);

// Set the socket to listen for incoming connection requests with a backlog of 10
socket.Listen(10);


Console.WriteLine("About To Accept incoming connection !    ");

// Accept an incoming connection (this will block until a connection is established)
Socket clientSocket = socket.Accept();

Console.WriteLine("Connection Accepted !" + clientSocket.RemoteEndPoint.ToString() + " " + clientSocket.LocalEndPoint.ToString());


byte[] buffer = new byte[3];
int bytesReceived = 0;

while (true)
{
    bytesReceived = clientSocket.Receive(buffer);

    Console.WriteLine("Number of Byters Recived : " + bytesReceived);

    Console.WriteLine("Received: " + Encoding.ASCII.GetString(buffer, 0, bytesReceived));

    if (Encoding.ASCII.GetString(buffer, 0, bytesReceived) == "x")
    {
        break;
    }

    clientSocket.Send(buffer, bytesReceived, SocketFlags.None);
}







Console.ReadLine();


