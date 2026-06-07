using RegistrationApp.ViewModels;
using System;
using System.Windows;

namespace RegistrationApp.Views
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private DataBaseManager _fileManager;
		private UserHandler _userHandler;
		private EmailSender _emailSender;
		public MainWindow()
		{
			InitializeComponent();
			_userHandler = new UserHandler();
		}
		private async void Button_Click(object sender, RoutedEventArgs e)
		{
			bool isInvalid = _userHandler.ErrorHandler(FirstNameTextBox, LastNameTextBox, EmailTextBox, PasswordBox, AgreementCheckBox);
			if (isInvalid)
			{
				try
				{
					_fileManager = new DataBaseManager(FirstNameTextBox, LastNameTextBox, EmailTextBox, PasswordBox.Password);
					bool saved = await _fileManager.SaveToDatabaseAsync();
					if (saved)
					{
						_emailSender = new EmailSender(EmailTextBox.Text, FirstNameTextBox.Text);
						await _emailSender.SendEmailAsync();

						MessageBox.Show("Регистрация успешна!\nПисьмо с подтверждением отправлено.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

						FirstNameTextBox.Clear();
						LastNameTextBox.Clear();
						EmailTextBox.Clear();
						PasswordBox.Clear();
						AgreementCheckBox.IsChecked = false;
					}
					else
					{
						MessageBox.Show("Не удалось сохранить данные в базу данных.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
		}
	}
}
