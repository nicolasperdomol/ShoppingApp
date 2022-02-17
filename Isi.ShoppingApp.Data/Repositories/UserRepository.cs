using Isi.ShoppingApp.Core.Entities;
using Isi.Utility.Authentication;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace Isi.ShoppingApp.Data.Repositories
{
    public class UserRepository
    {
        private readonly string connectionString;
        public UserRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["UserDatabase"].ConnectionString;
        }

        public List<User> GetUsers()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT Username, PasswordSalt, PasswordHash, Admin, Balance " +
                                  "FROM dbo.Users";

            List<User> users = new List<User>();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                users.Add(ReadNextUser(reader));
            }
            return users;
        }

        private User ReadNextUser(SqlDataReader reader)
        {

           string firstName = reader.GetString(0);
           string lastName = reader.GetString(1);
           string username = reader.GetString(2);
           //TODO byte[] passwordSalt = reader.GetBytes(3);
           //TODO byte[] passwordHash = reader.GetByte(4); 
           bool isAdmin = reader.GetBoolean(5);
        
          //return new User(firstName, lastName, username, new HashedPassword(passwordSalt, passwordHash), isAdmin);
            return null;
        }

        public User GetUser(string username)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT FirstName, LastName, Username, PasswordSalt, PasswordHash, Admin, Balance " +
                                  "FROM dbo.Users " +
                                  "WHERE Username = @Username";

            command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                return ReadNextUser(reader);

            return null;
        }

        public HashedPassword GetUserPassword(string username)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT PasswordSalt, PasswordHash " +
                                  "FROM dbo.Users " +
                                  "WHERE Username = @Username";

            command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                return ReadNextUser(reader).HashedPassword;

            return null;
        }

        public User CreateUser(User user)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO dbo.UserDatabase (FirstName, LastName, Username, PasswordSalt, PasswordHash, Admin, Balance) " +
                "VALUES(@FirstName, @LastName, @Username, @PasswordSalt, @PasswordHash, @Admin, @Balance)";

            command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = user.FirstName;
            command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = user.LastName;
            command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = user.Username;
            command.Parameters.Add("@PasswordSalt", SqlDbType.VarBinary).Value = user.HashedPassword.Salt;
            command.Parameters.Add("@PasswordHash", SqlDbType.NVarChar).Value = user.HashedPassword.Hash;
            command.Parameters.Add("@Admin", SqlDbType.NVarChar).Value = user.IsAdmin;
            command.Parameters.Add("@Balance", SqlDbType.NVarChar).Value = user.Balance;

            return new User(user.FirstName, user.LastName, user.Username, user.HashedPassword, user.IsAdmin);
        }

        public bool DeleteUser(string username)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM dbo.UserDatabase WHERE Username = @Username";

            command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;

            int rowsChanged = command.ExecuteNonQuery();
            return (rowsChanged > 0);
        }
    }
}
