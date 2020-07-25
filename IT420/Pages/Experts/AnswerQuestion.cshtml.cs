using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT420.Areas.Identity.Data;
using IT420.Core;
using IT420.Data.ExpertData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IT420.Pages.Experts
{
    [Authorize(Policy = "IsExpert")]
    public class AnswerQuestionModel : PageModel
    {
        private readonly IExpertAnswerData answerData;
        private readonly IExpertQuestionData questionData;
        private readonly IExpertData expertData;
        private readonly UserManager<UserProfile> userManager;
        private readonly IAccountData accountData;

        [BindProperty]
        public ExpertQuestionAnswer Answer { get; set; }        
        public ExpertQuestion Question { get; set; }
        public Expert Expert { get; set; }
        public IQueryable<UserProfile> userProfiles { get; set; }
        public UserProfile userProfile { get; set; }

        public AnswerQuestionModel(IExpertAnswerData answerData, IExpertQuestionData questionData, IExpertData expertData, UserManager<UserProfile> userManager, IAccountData accountData)
        {
            this.answerData = answerData;
            this.questionData = questionData;
            this.expertData = expertData;
            this.userManager = userManager;
            this.accountData = accountData;
        }
        
        public IActionResult OnGet(int questionId)
        {
            Question = questionData.GetById(questionId);

            if (Question == null)
            {
                return RedirectToPage("./NotFound");
            }
            userProfile = accountData.GetById(Question.userId);
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            Question = questionData.GetById(Answer.questionId);

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await userManager.GetUserAsync(User);

            Expert = expertData.GetByUserId(user.Id);
            
            Question.answered = true;
            questionData.Update(Question);            
            Answer.expertId =Expert.id;
            answerData.Add(Answer);
            if (await answerData.Commit())
            {
                TempData["Message"] = $"Answer Added";
                return RedirectToPage("./QuestionDetail", new { questionId = Answer.questionId });
            }
            return RedirectToPage("./NotFound");
        }
    }
}
