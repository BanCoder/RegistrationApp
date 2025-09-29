using System;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
<<<<<<< HEAD
=======
using Newtonsoft; 
>>>>>>> new-bd-branch

namespace RegistrationApp
{
	internal class ErrorValidator
	{
		public bool ValidateAndFarmateUserNameAndSurname(TextBox userName, string fieldName)
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
		public bool ValidateEmail(string emailAddress)
		{
			try
			{
				MailAddress mail = new MailAddress(emailAddress);
				return true;
			}
			catch (FormatException)
			{
				return false;
			}
		}
		public bool ValidatePassword(string password)
		{
			var input = password;

			if (string.IsNullOrWhiteSpace(input))
			{
				MessageBox.Show("Введите пароль!\n" +
					"Пароль должен состоять минимум из 8 символов!"); 
			}

			var hasNumber = new Regex(@"[0-9]+");
			var hasUpperChar = new Regex(@"[A-Z]+");
<<<<<<< HEAD
			var hasMiniMaxChars = new Regex(@".{8,12}");
=======
			var hasMiniMaxChars = new Regex(@".{8,16}");
>>>>>>> new-bd-branch
			var hasLowerChar = new Regex(@"[a-z]+");
			var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

			if (!hasLowerChar.IsMatch(input))
			{
				MessageBox.Show("Пароль должен содержать хотя бы одну строчную букву!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); 
				return false;
			}
			else if (!hasUpperChar.IsMatch(input))
			{
				MessageBox.Show("Пароль должен содержать хотя бы одну заглавную букву!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
				return false;
			}
			else if (!hasMiniMaxChars.IsMatch(input))
			{
				MessageBox.Show("Длина пароля не должна быть меньше 8 символов!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
				return false;
			}
			else if (!hasNumber.IsMatch(input))
			{
				MessageBox.Show("Пароль должен содержать хотя бы одно числовое значение!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
				return false;
			}

			else if (!hasSymbols.IsMatch(input))
			{
				MessageBox.Show("Пароль должен содержать хотя бы один символ в особом регистре( ! @ # $ % ^ & * _ )", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
				return false;
			}
			else
			{
				return true;
			}
		}
	}
}
