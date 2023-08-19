namespace BlogWebUI.Areas.Writer.Models
{
    public class UserProfileEdit
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        //IFormFile : dosyanın wrootun içine kaydedilmesi için gerekli olan tür
        public string PictureURL { get; set; }
        //IFormFile : dosyanın wrootun içine kaydedilmesi için gerekli olan tür
        public IFormFile Picture { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
