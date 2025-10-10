using RegistrationApp.Model;
using System;
using System.Net;
using System.Net.Mail;

namespace RegistrationApp.ViewModels
{
	internal class EmailSender
	{
		public EmailSender(string userLogin, string userName)
		{
			SendEmail(userLogin, userName); 
		}
		private void SendEmail(string userLogin, string userName)
		{
			string emailDomain = GetEmailDomain(userLogin);
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
			using (SmtpClient smtpClient = new SmtpClient(config.Server, config.Port))
			{
				smtpClient.Credentials = new NetworkCredential(config.AdminLogin, config.Password);
				smtpClient.EnableSsl = true;
				using (MailMessage mailMessage = new MailMessage())
				{
					mailMessage.From = new MailAddress(config.AdminLogin);
					mailMessage.To.Add(userLogin);
					mailMessage.Subject = "Подтверждение регистрации в форме";
					mailMessage.Body = $"Здравствуйте, {userName}!\r\nЕсли вы видите это сообщение - значит регистрация прошла успешно.";
					smtpClient.Send(mailMessage);
				}
			}
		}
		private string GetEmailDomain(string email)
		{
			MailAddress mailAddress = new MailAddress(email);
			return mailAddress.Host; 
		}
	}
}
