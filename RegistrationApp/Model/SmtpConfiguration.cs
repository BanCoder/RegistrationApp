using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationApp.Model
{
	public class SmtpConfiguration
	{
		public string Server { get; set; }
		public int Port { get; set; }
		public string AdminLogin { get; set; }
		public string Password { get; set; }
	}
}
