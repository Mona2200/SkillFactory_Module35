using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public bool RememberMe { get; set; }

        [Required]
        public string ReturnUrl { get; set; }
    }
}
