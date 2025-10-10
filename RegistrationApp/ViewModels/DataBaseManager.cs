using Npgsql;
using System; 
using RegistrationApp.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
namespace RegistrationApp.ViewModels
{
	public class DataBaseManager
	{
		private List<UserData> _userData; 
		private UserHandler _userHandler;
		private string _connectionString; 
		public DataBaseManager(string filePath, TextBox firstNameTextBox, TextBox lastNameTextBox, TextBox emailTextBox,string passwordBox)
		{
			_userHandler = new UserHandler();
			string passwordHash = HashPassword(passwordBox);
			_userData = _userHandler.ReadDataFromUi(firstNameTextBox, lastNameTextBox, emailTextBox, passwordHash);
			_connectionString = App.SqlSettings.SqlConnection;
			_ = InputDataToDataBase(filePath, _userData);
		}
		private async Task InputDataToDataBase(string filePath, List<UserData> userData)
		{
			NpgsqlConnection connection = new NpgsqlConnection(_connectionString);
			await connection.OpenAsync();
			foreach(var users in userData)
			{
				NpgsqlCommand command = new NpgsqlCommand(@"
				INSERT INTO users (first_name, last_name, email, usr_pass)
				VALUES (@firstName, @lastName, @email, @password)
				RETURNING id;", connection);
				command.Parameters.AddWithValue("@firstName", users.Name);
				command.Parameters.AddWithValue("@lastName", users.Surname);
				command.Parameters.AddWithValue("@email", users.Email);
				command.Parameters.AddWithValue("@password", users.Password);
				await command.ExecuteScalarAsync();
			}
		}
		public string HashPassword(string password)
		{
			return $"{BCrypt.Net.BCrypt.HashPassword(password)}";
		}
	}
}
