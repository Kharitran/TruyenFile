using SharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Server.Core
{
    public class Authentication
    {
        private const string UsersFilePath = "users.dat";
        private readonly List<User> users;

        public Authentication()
        {
            users = new List<User>();
            LoadUsers();
        }

        private void LoadUsers()
        {
            if (File.Exists(UsersFilePath))
            {
                try
                {
                    var lines = File.ReadAllLines(UsersFilePath);
                    foreach (var line in lines)
                    {
                        var parts = line.Split('|');
                        if (parts.Length == 3)
                        {
                            users.Add(new User
                            {
                                Username = parts[0],
                                Password = parts[1],
                                Role = (UserRole)Enum.Parse(typeof(UserRole), parts[2])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading users: {ex.Message}");
                }
            }
            else
            {
                users.Add(new User
                {
                    Username = "admin",
                    Password = HashPassword("admin123"),
                    Role = UserRole.Admin
                });
                SaveUsers();
            }
        }

        private void SaveUsers()
        {
            try
            {
                var lines = users.Select(u => $"{u.Username}|{u.Password}|{u.Role}");
                File.WriteAllLines(UsersFilePath, lines);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving users: {ex.Message}");
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        public bool Authenticate(string username, string password, out UserRole role)
        {
            role = UserRole.User;
            var hashedPassword = HashPassword(password);

            var user = users.FirstOrDefault(u =>
                u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                u.Password == hashedPassword);

            if (user != null)
            {
                role = user.Role;
                return true;
            }
            return false;
        }

        public bool Register(string username, string password, UserRole role = UserRole.User)
        {
            if (users.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
                return false;

            users.Add(new User
            {
                Username = username,
                Password = HashPassword(password),
                Role = role
            });

            SaveUsers();
            return true;
        }
    }
}