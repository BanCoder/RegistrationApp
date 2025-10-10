using Microsoft.Extensions.Configuration;
using RegistrationApp.Model;
using System.IO;
using System.Windows;

namespace RegistrationApp
{
	/// <summary>
	/// Логика взаимодействия для App.xaml
	/// </summary>
	public partial class App : Application
	{
		public static IConfiguration Configuration { get; private set; }
		public static SmtpSettings Settings { get; private set; }
		public static SqlSettings SqlSettings { get; private set; }
		protected override void OnStartup(StartupEventArgs e)
		{
			var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).AddUserSecrets<App>();
			Configuration = builder.Build();
			Settings = Configuration.GetSection("SmtpSettings").Get<SmtpSettings>();
			SqlSettings = Configuration.GetSection("ConnectionSettings").Get<SqlSettings>();
			base.OnStartup(e);
		}
	}
}
