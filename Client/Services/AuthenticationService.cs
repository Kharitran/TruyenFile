using System;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using SharedLibrary.Enums;
using SharedLibrary.Models;

namespace Client.Services
{
    public class AuthenticationService
    {
        private TcpClient client;
        private NetworkStream stream;
        private BinaryFormatter formatter;

        public AuthenticationService()
        {
        }

        public void SetConnection(TcpClient tcpClient)
        {
            client = tcpClient;
            stream = client.GetStream();
            formatter = new BinaryFormatter();
        }

        public bool Login(string username, string password)
        {
            try
            {
                formatter.Serialize(stream, CommandType.Login);
                formatter.Serialize(stream, new User
                {
                    Username = username,
                    Password = password
                });

                var response = (ResponseCode)formatter.Deserialize(stream);
                return response == ResponseCode.LoginSuccess;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Register(string username, string password)
        {
            try
            {
                formatter.Serialize(stream, CommandType.Register);
                formatter.Serialize(stream, new User
                {
                    Username = username,
                    Password = password
                });

                var response = (ResponseCode)formatter.Deserialize(stream);
                return response == ResponseCode.RegisterSuccess;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}