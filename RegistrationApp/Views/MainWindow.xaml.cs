using RegistrationApp.ViewModels;
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
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			bool isInvalid = _userHandler.ErrorHandler(FirstNameTextBox, LastNameTextBox, EmailTextBox, PasswordBox, AgreementCheckBox);
			if(isInvalid)
			{
				_fileManager = new DataBaseManager(FirstNameTextBox, LastNameTextBox, EmailTextBox,PasswordBox.Password);
				_emailSender = new EmailSender(EmailTextBox.Text, FirstNameTextBox.Text); 
			}
		}
	}
}
