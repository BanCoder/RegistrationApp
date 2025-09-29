using System.Text.Json.Serialization;

namespace RegistrationApp.Model
{
	internal struct UserData
	{
		[JsonPropertyName("Имя пользователя")]
		public string Name {get; set;}
		[JsonPropertyName("Фамилия пользователя")]
		public string Surname { get; set; }
		[JsonPropertyName("Email")]
		public string Email { get; set; }
		[JsonPropertyName("Пароль")]
		public string Password { get; set; }
		public UserData(string userName, string userSurname, string email, string password)
		{
			Name = userName;
			Surname = userSurname;
			Email = email;
			Password = password;
		}
	}
}
