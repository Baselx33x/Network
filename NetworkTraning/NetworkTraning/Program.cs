using System.Net; 
using System.Net.Sockets;
using System.Text;


Socket ServerSide()
{
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

    Console.WriteLine("Connection Accepted !" + " " + clientSocket.LocalEndPoint.ToString());

    return clientSocket;
}

// Method for handling client-side communication via a socket
void HandlInfo(Socket clientSocket)
{
    // Buffer to store received data
    byte[] buffer = new byte[128];
    int bytesReceived = 0; // Variable to store the number of bytes received

    // Continuously receive data
    while (true)
    {
        // Receive data into the buffer and get the number of bytes received
        bytesReceived = clientSocket.Receive(buffer);

        Console.WriteLine("Number of Bytes Received: " + bytesReceived);
        Console.WriteLine("Received: " + Encoding.ASCII.GetString(buffer, 0, bytesReceived));

        // Check if the received data is "x" and break if true
        if (Encoding.ASCII.GetString(buffer, 0, bytesReceived) == "x")
        {
            break;
        }

        // Send the received data back to the client
        clientSocket.Send(buffer, bytesReceived, SocketFlags.None);
    }
}


HandlInfo(ServerSide());



Console.ReadLine();


