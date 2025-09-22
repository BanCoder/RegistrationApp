using RegistrationApp.Model;
using RegistrationApp.Views;
using System.Collections.Generic;
using System.Windows;
using System.Linq; 
using System.Windows.Controls;
using System.Globalization;

namespace RegistrationApp.ViewModels
{
	internal class UserHandler
	{
		private List<UserData> _users; 
		public List<UserData> ReadDataFromUi(TextBox firstNameTextBox, TextBox lastNameTextBox, TextBox emailTextBox, PasswordBox passwordBox)
		{
			_users = new List<UserData>(); 
			string name = firstNameTextBox.Text;
			string surname = lastNameTextBox.Text;
			string email = emailTextBox.Text;
			string password = passwordBox.Password;
			_users.Add(new UserData(name, surname, email, password));
			return _users;
		}
		public bool ErrorHandler(TextBox firstNameTextBox, TextBox lastNameTextBox, TextBox emailTextBox, PasswordBox passwordBox, CheckBox agreementBox)
		{
			if (passwordBox.Password.Length < 8 || passwordBox.Password.Length == 0)
			{
				MessageBox.Show("Введите пароль!" +
					"Пароль должен состоять минимум из 8 символов!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
				return false;
			}
			else if (firstNameTextBox.Text.Length == 0 || !ValidateAndFarmateUserNameAndSername(firstNameTextBox, "имя"))
			{
				MessageBox.Show("Введите ваше имя!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
				return false; 
			}
			else if (lastNameTextBox.Text.Length == 0 || !ValidateAndFarmateUserNameAndSername(lastNameTextBox, "фамилию"))
			{
				MessageBox.Show("Введите вашу фамилию!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
				return false;
			}
			else if (emailTextBox.Text.Length == 0 || !emailTextBox.Text.Contains('@') || !emailTextBox.Text.Contains('.'))
			{
				MessageBox.Show("Неверно введена почта!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
				return false;
			}
			else if(agreementBox.IsChecked != true)
			{
				MessageBox.Show("Примите условия использования!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); 
				return false;
			}
				return true;
		}
		private bool ValidateAndFarmateUserNameAndSername(TextBox userName, string fieldName)
		{
			string name = userName.Text.Trim();
			if (string.IsNullOrEmpty(name))
			{
				MessageBox.Show($"Введите {fieldName}!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return false;
			}
			if (!name.All(char.IsLetter))
			{
				MessageBox.Show($"{fieldName} должен содержать только буквы!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return false;
			}
			string formattedName = char.ToUpper(name[0]) + name.Substring(1).ToLower();
			userName.Text = formattedName;
			return true;
		}
	}
}
