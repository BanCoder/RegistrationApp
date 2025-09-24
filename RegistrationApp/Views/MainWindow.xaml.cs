using RegistrationApp.ViewModels;
using System.Runtime.InteropServices;
using System.Windows;

namespace RegistrationApp.Views
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private FileManager _fileManager;
		private UserHandler _userHandler;
		public MainWindow()
		{
			InitializeComponent();
			_userHandler = new UserHandler();
		}
		/*
		 * Добавить:
		 * отправка сообщений на почту пользователю
		 * бд в json формат
		*/
		
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			bool isInvalid = _userHandler.ErrorHandler(FirstNameTextBox, LastNameTextBox, EmailTextBox, PasswordBox, AgreementCheckBox);
			if(isInvalid)
			{
				_fileManager = new FileManager("registration_base.json", FirstNameTextBox, LastNameTextBox, EmailTextBox,PasswordBox);
			}
		}
	}
}
