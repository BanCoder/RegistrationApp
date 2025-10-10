using RegistrationApp.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace RegistrationApp.ViewModels
{
	internal class UserHandler
	{
		private List<UserData> _users; 
		private ErrorValidator _errorValidator;
		public UserHandler()
		{
			_errorValidator = new ErrorValidator();
			_users = new List<UserData>();
		}
		public List<UserData> ReadDataFromUi(TextBox firstNameTextBox, TextBox lastNameTextBox, TextBox emailTextBox,string password)
		{
			string name = firstNameTextBox.Text;
			string surname = lastNameTextBox.Text;
			string email = emailTextBox.Text;
			_users.Add(new UserData(name, surname, email, password));
			return _users;
		}
		public bool ErrorHandler(TextBox firstNameTextBox, TextBox lastNameTextBox, TextBox emailTextBox, PasswordBox passwordBox, CheckBox agreementBox)
		{
			
			if (string.IsNullOrEmpty(firstNameTextBox.Text) || !_errorValidator.ValidateUserNameAndSurname(firstNameTextBox, "имя"))
			{
				MessageBox.Show("Введите ваше имя!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
				return false; 
			}
			else if (string.IsNullOrEmpty(lastNameTextBox.Text) || !_errorValidator.ValidateUserNameAndSurname(lastNameTextBox, "фамилию"))
			{
				MessageBox.Show("Введите вашу фамилию!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
				return false;
			}
			else if (string.IsNullOrEmpty(emailTextBox.Text) || !_errorValidator.ValidateEmail(emailTextBox.Text))
			{
				MessageBox.Show("Неверно введена почта!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
				return false;
			}
			else if (!_errorValidator.ValidatePassword(passwordBox.Password))
			{
				return false;
			}
			else if(agreementBox.IsChecked != true)
			{
				MessageBox.Show("Примите условия использования!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); 
				return false;
			}
			MessageBox.Show("Вы зарегистрированы!\n" +
				"Мы отправили вам на почту подтверждающее сообщение!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
			return true;
		}
	}
}
