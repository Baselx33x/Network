using System.Net; 
using System.Net.Sockets;




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


Console.WriteLine("About To Accept incoming connection !");

// Accept an incoming connection (this will block until a connection is established)
Socket clientSocket = socket.Accept();

Console.WriteLine(clientSocket.ToString() + "Connection Accepted !");




Console.ReadLine();


