using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT420.Areas.Identity.Data;
using IT420.Core;
using IT420.Data.ExpertData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IT420.Areas.Identity.Pages.Account
{
    public class RemoveExpertModel : PageModel
    {
        private readonly IAccountData accountData;
        private readonly IExpertData expertData;

        public UserProfile userProfile { get; set; }
        public Expert expert { get; set; }

        public RemoveExpertModel(IAccountData accountData, IExpertData expertData)
        {
            this.accountData = accountData;
            this.expertData = expertData;
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
            userProfile.IsExpert = false;

            expert = expertData.GetByUserId(userId);
            expertData.Delete(expert);

            if (await expertData.Commit() && await accountData.Commit())
            {
                TempData["Message"] = $"Expert {expert.firstName} {expert.lastName} deleted";
                return RedirectToPage("./ListUsers");
            }
            return RedirectToPage("./NotFound");            
        }
    }
}
