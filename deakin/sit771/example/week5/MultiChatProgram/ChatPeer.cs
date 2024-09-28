using SplashKitSDK;
using System;
using System.Collections.Generic;

namespace ChatProgram
{

    /// <summary>
    /// The ChatPeer has a built in server that will listen for connecting
    /// clients, and can itself connect to other peers. Once a connection
    /// is made, you can broadcast messages to the other party.
    /// </summary>
    public class ChatPeer
    {
        /// <summary>
        /// The name used for this peer on the network.
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }

        /// <summary>
        /// The server that the peer is listening for connections on.
        /// </summary>
        private ServerSocket _server;

        private Dictionary<string, Connection> _peers = new Dictionary<string, Connection>();

        /// <summary>
        /// Creates a new ChatPeer at the indicated port.
        /// </summary>
        /// <param name="port">The port to listen to incomming connections on</param>
        public ChatPeer(ushort port)
        {
            _server = new ServerSocket("ChatServer", port);
        }

        /// <summary>
        /// Establish a connection between this Peer and the one on the end of the connection.
        /// </summary>
        /// <param name="con">The connection to use to establish the link</param>
        private void EstablishConnection(Connection con)
        {
            // Send my name...
            con.SendMessage(Name);

            // Wait for a message...
            SplashKit.CheckNetworkActivity();
            for(int i = 0; i < 10 && ! con.HasMessages; i++)
            {
                SplashKit.Delay(200);
                SplashKit.CheckNetworkActivity();
            }

            if ( ! con.HasMessages )
            {
                con.Close();
                throw new Exception("Timeout waiting for name of peer");
            }

            // Read the name
            string name = con.ReadMessageData();

            // See if we can register this...
            if ( _peers.ContainsKey(name) )
            {
                con.Close();
                throw new Exception("Unable to connect to multiple peers with the same name");
            }

            // Register
            _peers[name] = con;
            Console.WriteLine($"Connected to {name} at { SplashKit.Ipv4ToStr(con.IP) }:{con.Port}");
        }

        /// <summary>
        /// Connect to another Chat Peer at the indicate address and port.
        /// </summary>
        /// <param name="address">The address of the peer</param>
        /// <param name="port">The port the peer is listening on</param>
        public void ConnectToPeer(string address, ushort port)
        {
            Connection newConnection = new Connection($"{address}:{port}", address, port);
            try
            {
                EstablishConnection(newConnection);
            }
            catch ( Exception e )
            {
                Console.WriteLine( e.Message );
            }
        }

        /// <summary>
        /// Check for new connections to this peer
        /// </summary>
        public void CheckNewConnections()
        {
            while ( _server.HasNewConnections )
            {
                Connection newConnection = _server.FetchNewConnection();

                try
                {
                    EstablishConnection(newConnection);
                }
                catch
                {
                    // ignore errors
                }
            }
        }

        /// <summary>
        /// Broadcast a message to all of the connections made from and 
        /// to this peer.
        /// </summary>
        /// <param name="message">The message to send</param>
        public void Broadcast(string message)
        {
            SplashKit.BroadcastMessage(message);
        }

        /// <summary>
        /// Send a targetted message to a user.
        /// </summary>
        /// <param name="name">The name of the user to send to</param>
        /// <param name="message">The message to send</param>
        public void SendMessageTo(string name, string message)
        {
            if ( _peers.ContainsKey(name) )
            {
                _peers[name].SendMessage(message);
            }
        }

        /// <summary>
        /// Output all of the incomming messages to the Terminal.
        /// This will check for network activity, and then read 
        /// all of the new messages from the network and output
        /// their data to Terminal.
        /// </summary>
        public void PrintNewMessages()
        {
            SplashKit.CheckNetworkActivity();

            while ( SplashKit.HasMessages() )
            {
                using(Message m = SplashKit.ReadMessage())
                {
                    Console.WriteLine($"Got message from {m.Host}:{m.Port}");
                    Console.WriteLine(m.Data);
                }
            }
        }

        /// <summary>
        /// Close the peer and all of the connections.
        /// </summary>
        public void Close()
        {
            _server.Close();
            SplashKit.CloseAllConnections();
        }
    }
}