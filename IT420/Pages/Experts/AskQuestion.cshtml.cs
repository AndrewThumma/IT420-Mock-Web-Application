using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT420.Core;
using IT420.Data.ExpertData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Language.Intermediate;

namespace IT420.Pages.Experts
{
    public class AskQuestionModel : PageModel
    {
        private readonly IExpertQuestionData questionData;
        private readonly IExpertQuestionTypeData typeData;
        private readonly UserManager<UserProfile> userManager;

        [BindProperty]
        public ExpertQuestion Question { get; set; }
        public ExpertQuestionType Type { get; set; }
        public SelectList typeList { get; set; }


        public AskQuestionModel(IExpertQuestionData questionData, IExpertQuestionTypeData typeData, UserManager<UserProfile> userManager)
        {
            this.questionData = questionData;
            this.typeData = typeData;
            this.userManager = userManager;
        }
        
        public void OnGet(int questionTypeId)
        {
            if (Question == null)
            {
                Question = new ExpertQuestion();
            }
            Type = typeData.GetById(questionTypeId);
            
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await userManager.GetUserAsync(User);
            Question.userId = user.Id;
            
            questionData.Add(Question);
            if (await questionData.Commit())
            {
                TempData["Message"] = $"Question Added";
                return RedirectToPage("./QuestionList", new { questionTypeId = Question.typeId });
            }
            return RedirectToPage("./NotFound");
        }
    }
}
