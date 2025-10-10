using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationApp.Model
{
	public class SmtpSettings
	{
		public SmtpConfiguration Gmail {  get; set; }
		public SmtpConfiguration MailRu { get; set; }
		public SmtpConfiguration Yandex { get; set; }
	}
}
