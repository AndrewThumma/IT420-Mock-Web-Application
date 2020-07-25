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
    public class EditUserModel : PageModel
    {
        private readonly IAccountData accountData;
        [BindProperty]
        public UserProfile userProfile { get; set; }

        public EditUserModel(IAccountData accountData)
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

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            accountData.Update(userProfile);
            if (await accountData.Commit())
            {
                TempData["Message"] = $"User {userProfile.firstName} {userProfile.lastName} updated";
                return RedirectToPage("./ListUsers");
            }
            return RedirectToPage("./NotFound");
        }
    }
}
