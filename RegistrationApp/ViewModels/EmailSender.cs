using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;
using RegistrationApp.Model;
using System;
using System.Net.Mail;
using System.Threading.Tasks;
namespace RegistrationApp.ViewModels
{
	public class EmailSender
	{
		private string _userLogin;
		private string _userName;
		public EmailSender(string userLogin, string userName)
		{
			_userLogin = userLogin;
			_userName = userName;
		}
		public async Task SendEmailAsync()
		{
			string emailDomain = GetEmailDomain(_userLogin);
			SmtpConfiguration config = new SmtpConfiguration();

			switch (emailDomain)
			{
				case "gmail.com":
					config = App.Settings.Gmail;
					break;
				case "mail.ru":
					config = App.Settings.MailRu;
					break;
				case "yandex.ru":
					config = App.Settings.Yandex;
					break;
				default:
					throw new ArgumentException("Неподдерживаемый почтовый индекс!");
			}
			var emailMessage = new MimeMessage();
			emailMessage.From.Add(new MailboxAddress("", config.AdminLogin));
			emailMessage.To.Add(new MailboxAddress("", _userLogin));
			emailMessage.Subject = "Подтверждение регистрации в форме";
			emailMessage.Body = new TextPart("plain")
			{
				Text = $"Здравствуйте, {_userName}!\r\nЕсли вы видите это сообщение - значит регистрация прошла успешно."
			};
			using (var smtpClient = new MailKit.Net.Smtp.SmtpClient())
			{
				if (config.Port == 465)
				{
					await smtpClient.ConnectAsync(config.Server, config.Port, true);
				}
				else if (config.Port == 587)
				{
					await smtpClient.ConnectAsync(config.Server, config.Port, SecureSocketOptions.StartTls);
				}
				else
				{
					await smtpClient.ConnectAsync(config.Server, config.Port, true);
				}

				await smtpClient.AuthenticateAsync(config.AdminLogin, config.Password);
				await smtpClient.SendAsync(emailMessage);
				await smtpClient.DisconnectAsync(true);
			}
		}
		private string GetEmailDomain(string email)
		{
			MailAddress mailAddress = new MailAddress(email);
			return mailAddress.Host;
		}
	}
}
