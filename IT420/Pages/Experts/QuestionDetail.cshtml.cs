using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT420.Areas.Identity.Data;
using IT420.Core;
using IT420.Data.ExpertData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IT420.Pages.Experts
{
    public class QuestionDetailModel : PageModel
    {
        private readonly IExpertQuestionData questionData;
        private readonly UserManager<UserProfile> userManager;
        private readonly IAccountData accountData;

        public ExpertQuestion Question { get; set; }
        public string userId { get; set; }
        public UserProfile userProfile { get; set; }
        [TempData]
        public string Message { get; set; }

        public QuestionDetailModel(IExpertQuestionData questionData, UserManager<UserProfile> userManager, IAccountData accountData)
        {
            this.questionData = questionData;
            this.userManager = userManager;
            this.accountData = accountData;
        }
        
        public async Task<IActionResult> OnGet(int questionId)
        {
            Question = questionData.GetById(questionId);
            if (Question == null)
            {
                return RedirectToPage("./NotFound");
            }
            var user = await userManager.GetUserAsync(User);
            userId = user.Id;
            userProfile = accountData.GetById(Question.userId);
            return Page();
        }
    }
}
