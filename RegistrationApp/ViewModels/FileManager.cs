using RegistrationApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;

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
			InputDataToFile(filePath, _userData); 
		}
		
		private void InputDataToFile(string filePath, List<UserData> userData)
		{
			using (StreamWriter sw = new StreamWriter(filePath, true))
			{
				try
				{
					if (userData != null)
					{
						foreach (var item in userData)
						{
							sw.WriteLine($"Имя пользователя: {item._name}\n" +
								$"Фамилия пользователя: {item._surname}\n" +
								$"Email: {item._email}\n" +
								$"Password: {item._password}\n");
						}
					}
					else
					{
						sw.WriteLine("Данных не обнаружено!");
					}
				}
				catch (Exception ex)
				{
					sw.WriteLine($"Данные не были загружены!\n{ex.Message}");
				}
			}
		}
	}
}
