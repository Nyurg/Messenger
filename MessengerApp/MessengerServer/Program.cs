using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MessengerServer
{
    // User class
    class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public NamedPipeServerStream server { get; set; }
        public Thread thread { get; set; }
        public StreamReader reader { get; set; }
        public StreamWriter writer { get; set; }

        public User() { }

        public User(int id, string username, NamedPipeServerStream server, 
            StreamReader reader, StreamWriter writer, Thread thread)
        {
            this.id = id;
            this.username = username;
            this.server = server;
            this.reader = reader;
            this.writer = writer;
            this.thread = thread;
        }
    }
    
    class Program
    {
        // List of users connected to the server
        static List<User> users = new List<User>();

        // Run on start
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.ToString() + " | " + "Server launched");

            DetectNewClient().Wait();
        }

        // Asynchronously listens for a client connecting
        private static async Task DetectNewClient()
        {
            // Recieves username through pipe
            NamedPipeServerStream sendUsernamePipeServer = new NamedPipeServerStream
                ("sendUsername", PipeDirection.In, 1, PipeTransmissionMode.Message, PipeOptions.Asynchronous);

            // Waits for a client to login
            while (!sendUsernamePipeServer.IsConnected) await sendUsernamePipeServer.WaitForConnectionAsync();

            // Retrieves username and closes
            StreamReader readUsername = new StreamReader(sendUsernamePipeServer);
            string username = readUsername.ReadLine();
            sendUsernamePipeServer.Close();

            AddNewUser(username);

            // Runs task again, loop forever
            DetectNewClient().Wait();
        }

        // Adds new user
        private static void AddNewUser(string username)
        {
            User newUser = new User();
            
            // Gives the server a name the same as clients username
            NamedPipeServerStream server = new NamedPipeServerStream(username, PipeDirection.InOut, 3,
                PipeTransmissionMode.Message, PipeOptions.Asynchronous);
            StreamReader reader = new StreamReader(server);
            StreamWriter writer = new StreamWriter(server);
            Thread thread = new Thread(() => ServerThread(newUser));

            newUser = new User(users.Count, username, server, reader, writer, thread);
            users.Add(newUser);

            // Begins the user server thread
            users.Last().thread.Start();
        }

        private static void ServerThread(User user)
        {
            // Waits for a client to connect
            user.server.WaitForConnection();

            // Show user has joined
            string joinedMessage = user.username + " has joined the room";
            Console.WriteLine(DateTime.Now.ToString() + " | " + joinedMessage);
            ReturnMessageToUsers(joinedMessage);

            // Loop until break
            while (true)
            {
                // Wait until a message is sent from client
                string messageBase = user.username + " : ";
                string message = messageBase + user.reader.ReadLine();

                // If the client disconnects, break
                if (!user.server.IsConnected ||
                    message == messageBase ) break;
                
                // Show message
                Console.WriteLine(DateTime.Now.ToString() + " | " + message);
                ReturnMessageToUsers(message);
            }

            // Close server thread and remove user from list
            user.server.Close();
            users.Remove(user);
            Console.WriteLine(DateTime.Now.ToString() + " | " + "{0} has disconnected from the room", user.username);
        }

        // Send a message to all of the clients connected
        private static void ReturnMessageToUsers(string message)
        {
            foreach (User user in users)
            {
                user.writer.WriteLine(message);
                user.writer.Flush();
            }
        }

    }
}
