using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT420.Areas.Identity.Data;
using IT420.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IT420.Areas.Identity.Pages.Account
{
    public class RestoreUserModel : PageModel
    {
        private readonly IAccountData accountData;
        public UserProfile userProfile { get; set; }

        public RestoreUserModel(IAccountData accountData)
        {
            this.accountData = accountData;
        }

        public IActionResult OnGet(string userId)
        {
            userProfile = accountData.GetById(userId);
            if (userProfile == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public async Task<IActionResult> OnPost(string userId)
        {
            userProfile = accountData.GetById(userId);

            userProfile.IsBanned = false;
            accountData.Update(userProfile);

            if (await accountData.Commit())
            {
                TempData["Message"] = $"{userProfile.UserName} has been restored to good standing";
                return RedirectToPage("./ListUsers");
            }
            return RedirectToPage("./NotFound");
        }
    }
}
