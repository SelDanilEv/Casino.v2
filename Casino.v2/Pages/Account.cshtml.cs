using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Casino.v2.Pages
{
    public class AccountModel : PageModel
    {
        public int? UserId;
        public User CurrentUser = new User();
        public bool Checked=false;

        public void OnGet()
        {
            LogIn();
        }

        public IActionResult LogIn()
        {
            UserId = HttpContext.Session.GetInt32("userId");
            if (UserId != null)
                CurrentUser = Data.ActivUsers[(int)UserId];
            Checked = true;
            return Page();
        }

    }
}