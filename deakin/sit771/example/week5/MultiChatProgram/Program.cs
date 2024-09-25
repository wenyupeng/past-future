using System;
using SplashKitSDK;

namespace ChatProgram
{
    public class Program
    {
        /// <summary>
        /// Print the menu to the Terminal.
        /// </summary>
        private static void PrintMenu()
        {
            Console.WriteLine("1: Broadcast message");
            Console.WriteLine("2: Send message");
            Console.WriteLine("3: Connect to server");
            Console.WriteLine("4: Wait for a connection");
            Console.WriteLine("5: Check Messages");
            Console.WriteLine("6: Quit");
        }

        /// <summary>
        /// Read a message from the user and broadcast it
        /// to all ChatPeer
        /// </summary>
        /// <param name="peer">The ChatPeer to broadcast the message from</param>
        private static void BroadcastMessage(ChatPeer peer)
        {
            Console.Write("What message do you want to send: ");
            string message = Console.ReadLine();
            peer.Broadcast(message);
        }

        /// <summary>
        /// Send a message to a specific person.
        /// </summary>
        /// <param name="peer"></param>
        private static void SendTargetMessage(ChatPeer peer)
        {
            Console.Write("Who to: ");
            string name = Console.ReadLine();

            Console.Write("What message do you want to send: ");
            string message = Console.ReadLine();
            peer.SendMessageTo(name, message);
        }

        /// <summary>
        /// Collect the required details from the user, and make 
        /// a new connection to the ChatPeer.
        /// </summary>
        /// <param name="peer">The peer to make the new connection from</param>
        private static void MakeNewConnection(ChatPeer peer)
        {
            string address;
            ushort port;

            Console.Write("Enter address: ");
            address = Console.ReadLine();

            Console.Write("Enter port: ");
            port = Convert.ToUInt16(Console.ReadLine());

            peer.ConnectToPeer(address, port);
        }

        /// <summary>
        /// Wait for incomming connections, and get the peer to establish these
        /// </summary>
        /// <param name="peer"></param>
        private static void WaitForConnection(ChatPeer peer)
        {
            Console.WriteLine("Waiting for a connection...");

            while ( ! SplashKit.HasNewConnections()  )
            {
                SplashKit.AcceptAllNewConnections();
                SplashKit.Delay(200);
            }

            peer.CheckNewConnections();

            Console.WriteLine("Got one...");
        }

        public static void Main(string[] args)
        {
            Console.Write("What is your name: ");
            string name = Console.ReadLine();
            Console.Write("Which port: ");
            ushort port = Convert.ToUInt16(Console.ReadLine());
            ChatPeer peer = new ChatPeer(port) { Name = name };

            int opt;
            do
            {
                PrintMenu();
                opt = Convert.ToInt32(Console.ReadLine());

                switch (opt)
                {
                    case 1:
                        BroadcastMessage(peer);
                        break;
                    case 2:
                        SendTargetMessage(peer);
                        break;
                    case 3:
                        MakeNewConnection(peer);
                        break;
                    case 4:
                        WaitForConnection(peer);
                        break;
                    case 5:
                        peer.PrintNewMessages();
                        break;
                    case 6:
                        peer.Close();
                        break;
                    default:
                        Console.WriteLine("Enter a value between 1 and 4");
                        break;
                }
            } while (opt != 6);
        }
    }
}