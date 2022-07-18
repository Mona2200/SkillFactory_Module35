using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SocialNetwork.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Pages
{
   public class IndexModel : PageModel
   {
      public RegisterViewModel RegisterView { get; set; }

      public LoginViewModel LoginView { get; set; }

      public IndexModel()
      {
         RegisterView = new RegisterViewModel();
         LoginView = new LoginViewModel();
      }

      public void OnGet()
      {

      }
   }
}
