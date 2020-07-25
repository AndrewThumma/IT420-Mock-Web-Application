using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT420.Core;
using IT420.Data.ExpertData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IT420.Pages.Experts
{
    public class UpdateAnswerModel : PageModel
    {
        private readonly IExpertAnswerData answerData;
        [BindProperty]
        public ExpertQuestionAnswer Answer { get; set; }

        public UpdateAnswerModel(IExpertAnswerData answerData)
        {
            this.answerData = answerData;
        }
        
        public IActionResult OnGet(int answerId)
        {
            Answer = answerData.GetById(answerId);
            if (Answer == null)
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
            
            answerData.Update(Answer);
            if (await answerData.Commit())
            {
                TempData["Message"] = $"Answer Updated";
                return RedirectToPage("./QuestionDetail", new { questionId = Answer.questionId });
            }
            return RedirectToPage("./NotFound");
        }
    }
}
