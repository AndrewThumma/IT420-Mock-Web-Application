using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT420.Areas.Identity.Data;
using IT420.Core;
using IT420.Data.ExpertData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IT420.Pages.Experts
{
    public class DeleteExpertModel : PageModel
    {
        private readonly IExpertData expertData;
        private readonly IAccountData accountData;
        private readonly IExpertAnswerData answerData;

        public Expert Expert{ get; set; }
        public UserProfile userProfile { get; set; }

        public DeleteExpertModel(IExpertData expertData, IAccountData accountData, IExpertAnswerData answerData)
        {
            this.expertData = expertData;
            this.accountData = accountData;
            this.answerData = answerData;
        }
        
        public IActionResult OnGet(int expertId)
        {
            Expert = expertData.GetById(expertId);
            if (Expert == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public async Task<IActionResult> OnPost(int expertId)
        {
            Expert = expertData.GetById(expertId);
            if (Expert == null)
            {
                return RedirectToPage("./NotFound");
            }

            userProfile = accountData.GetById(Expert.userId);
            userProfile.IsExpert = false;
            accountData.Update(userProfile);
            
            foreach (var answer in Expert.Answers)
            {
                answerData.Delete(answer);
            }

            await answerData.Commit();

            expertData.Delete(Expert);

            if (await expertData.Commit())
            {
                if (await accountData.Commit())
                {
                    TempData["Message"] = $"Expert {Expert.firstName} {Expert.lastName} Deleted";
                    return RedirectToPage("./ManageExperts");
                }                
            }
            return RedirectToPage("./NotFound");
        }
    }
}
