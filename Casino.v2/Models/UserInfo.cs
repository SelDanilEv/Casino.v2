using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Casino.v2.Models
{
    public class UserInfo : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string Message { get; set; }

        private int returnedId;


        public void OnGet()
        {
            Page();
        }

        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("userId");
            return Page();
        }

        public IActionResult OnPostLogIn()
        {
            returnedId = Data.Authorization(Username, Password);
            switch (returnedId)
            {
                case -2:
                    Message = "Invalid Login";
                    break;
                case -1:
                    Message = "Invalid Password or Login";
                    break;
                default:
                    HttpContext.Session.SetInt32("userId", returnedId);
                    Data.ActivUsers.ToArray()[returnedId].CorrectTransition = true;
                    return RedirectToPage("Account");
            }
            return Page();
        }

        public async void Serialize()
        {
            await Task.Run(() => Data.Serialize("UsersFile", Data.ActivUsers));
        }

        public IActionResult OnPostLogOn()
        {
            User user = new User(Username, Password, 1000);
            bool flag = Data.AddUser(user);
            if (flag) Message = "Account was created";
            else Message = "This name was occupied";
            Serialize();
            return Page();
        }

    }
}
