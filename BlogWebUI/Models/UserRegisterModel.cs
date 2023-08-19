using System.ComponentModel.DataAnnotations;

namespace BlogWebUI.Models
{
	public class UserRegisterModel
	{
		[Required(ErrorMessage = "Lütfen Adınızı ve soyadınızı Giriniz")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Lütfen Kullanıcı Adı Giriniz")]
		public string UserName { get; set; }
		public string ImageURL { get; set; }

		[Required(ErrorMessage = "Lütfen Mail Giriniz")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Lütfen Şifreyi Giriniz")]
		public string Password { get; set; }
		[Required(ErrorMessage = "Lütfen Şifreyi tekrar giriniz")]
		[Compare("Password", ErrorMessage = "Şifreler Birbiriyle Uyuşmuyor !")]
		public string ConfirmPassword { get; set; }
	}
}
