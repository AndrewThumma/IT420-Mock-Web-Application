using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using IT420.Core;
using IT420.Data.ExpertData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IT420.Pages.Experts
{
    public class DeleteQuestionModel : PageModel
    {
        private readonly IExpertQuestionData questionData;
        private readonly IExpertAnswerData answerData;
        private readonly UserManager<UserProfile> userManager;

        public ExpertQuestion Question { get; set; }
        public ExpertQuestionAnswer Answer { get; set; }

        public DeleteQuestionModel(IExpertQuestionData questionData, IExpertAnswerData answerData, UserManager<UserProfile> userManager)
        {
            this.questionData = questionData;
            this.answerData = answerData;
            this.userManager = userManager;
        }
        
        public IActionResult OnGet(int questionId)
        {
            Question = questionData.GetById(questionId);
            if (Question == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public async Task<IActionResult> OnPost(int questionId)
        {
            Question = questionData.GetById(questionId);
            if (Question == null)
            {
                return RedirectToPage("./NotFound");
            }

            if (Question.answered == true)
            {
                answerData.Delete(Question.Answer);
                await answerData.Commit();
            }

            questionData.Delete(Question);
            await answerData.Commit();
            TempData["Message"] = $"Question Deleted";
            return RedirectToPage("./QuestionList", new { questionTypeId = Question.typeId });
        }
    }
}
