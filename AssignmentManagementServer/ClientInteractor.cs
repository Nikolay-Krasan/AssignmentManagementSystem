using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using CommonCode;
using CommonCode.Requests;

namespace AssignmentManagementServer
{
    public class ClientInteractor
    {
        private static AssignmentOrganizer _assignmentOrganizer;
        private static UsersOrganizer _usersOrganizer;
        private static TcpListener _tcpListener;

        private const int Port = 8000;

        public ClientInteractor(AssignmentOrganizer assignmentOrganizer, UsersOrganizer usersOrganizer)
        {
            _assignmentOrganizer = assignmentOrganizer;
            _usersOrganizer = usersOrganizer;
        }

        public void HandleRequests()
        {
            _tcpListener = new TcpListener(IPAddress.Any, Port);
            _tcpListener.Start();

            while (true)
            {
                var tcpClient = _tcpListener.AcceptTcpClient();
                var socket = _tcpListener.AcceptSocket();

                var requestTask = Task.Factory.StartNew(() => HandleClientRequest(socket));
            }
        }

        private void HandleClientRequest(Socket socket)
        {
            //var client = ((TcpClient) stateInfo);
            var buffer = new byte[1024];

            //client.GetStream().Read(buffer, 0, buffer.Length);

            socket.Receive(buffer);

            var memoryStream = new MemoryStream(buffer);
            var binaryFormatter = new BinaryFormatter();
            memoryStream.Position = 0;
            var deserializedRequest = binaryFormatter.Deserialize(memoryStream);
            //ProcessRequest(deserializedRequest as RequestBase, socket);

            var asen = new ASCIIEncoding();
            byte[] ba = asen.GetBytes("Huynya kakaya-to");
            socket.Send(ba);
        }

        private void ProcessRequest(RequestBase deserializedRequest, Socket socket)
        {
            if (deserializedRequest is AssignmentRequest)
            {
                _assignmentOrganizer.HandleRequest(deserializedRequest as AssignmentRequest);
                var binaryFormatter = new BinaryFormatter();
            }

            if (deserializedRequest is UserRequest)
            {
                var users = _usersOrganizer.HandleRequest(deserializedRequest as UserRequest);
                var memoryStream = new MemoryStream();
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, users);
                var userDataBytes = memoryStream.ToArray();

                var asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes("Huynya kakaya-to");

                //socket.Send(userDataBytes);
            }
        }
    }
}