using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT420.Areas.Identity.Data;
using IT420.Core;
using IT420.Data.ExpertData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IT420.Pages.Experts
{
    [AllowAnonymous]
    public class QuestionListModel : PageModel
    {
        private readonly IExpertQuestionData questionData;
        private readonly IExpertQuestionTypeData typeData;
        private readonly IAccountData accountData;

        public IQueryable<ExpertQuestion> questions { get; set; }
        public IQueryable<UserProfile> userProfiles { get; set; }
        public ExpertQuestionType type { get; set; }
        [TempData]
        public string Message { get; set; }
        [BindProperty(SupportsGet = true)]
        public string searchTerm { get; set; }


        public QuestionListModel(IExpertQuestionData questionData, IExpertQuestionTypeData typeData, IAccountData accountData)
        {
            this.questionData = questionData;
            this.typeData = typeData;
            this.accountData = accountData;
        }
        
        public void OnGet(int questionTypeId)
        {
            questions = questionData.GetAllByName(searchTerm, questionTypeId);
            type = typeData.GetById(questionTypeId);
            userProfiles = accountData.GetAll();
        }
    }
}
