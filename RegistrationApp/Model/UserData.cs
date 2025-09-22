namespace RegistrationApp.Model
{
	internal struct UserData
	{
		public string _name;
		public string _surname; 
		public string _email;
		public string _password;
		public UserData(string userName, string userSurname, string email, string password)
		{
			_name = userName;
			_surname = userSurname;
			_email = email;
			_password = password;
		}
	}
}
