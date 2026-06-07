namespace RegistrationApp.Model
{
	public class SmtpSettings
	{
		public SmtpConfiguration Gmail {  get; set; }
		public SmtpConfiguration MailRu { get; set; }
		public SmtpConfiguration Yandex { get; set; }
	}
}
