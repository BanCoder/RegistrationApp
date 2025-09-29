using RegistrationApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;
using System.Text.Json;
using System.Windows;


namespace RegistrationApp.ViewModels
{
	internal class FileManager
	{
		private List<UserData> _userData; 
		private UserHandler _userHandler;
		public FileManager(string filePath, TextBox firstNameTextBox, TextBox lastNameTextBox, TextBox emailTextBox, PasswordBox passwordBox)
		{
			_userHandler = new UserHandler(); 
			_userData = _userHandler.ReadDataFromUi(firstNameTextBox, lastNameTextBox, emailTextBox, passwordBox); 
			InputDataToJsonFile(filePath, _userData); 
		}
		
		private void InputDataToJsonFile(string filePath, List<UserData> userData)
		{
			using (StreamWriter sw = new StreamWriter(filePath, true))
			{
				try
				{
					var options = new JsonSerializerOptions()
					{
						WriteIndented = true,
						Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
					};
					string json = JsonSerializer.Serialize(userData, options);
					sw.WriteLine(json);
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Ошибка загрузки данных {ex.Message}");
				}
			}
				
		}
	}
}
