using System.ComponentModel.DataAnnotations;

namespace YiGong.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}