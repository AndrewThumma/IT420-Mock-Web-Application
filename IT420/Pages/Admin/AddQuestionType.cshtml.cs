using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT420.Core;
using IT420.Data.ExpertData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IT420.Pages.Admin
{
    [Authorize(Policy = "IsAdmin")]
    public class AddQuestionTypeModel : PageModel
    {
        private readonly IExpertQuestionTypeData typeData;
        [BindProperty]
        public ExpertQuestionType Type { get; set; }

        public AddQuestionTypeModel(IExpertQuestionTypeData typeData)
        {
            this.typeData = typeData;
        }
        
        public void OnGet()
        {
            if (Type == null)
            {
                Type = new ExpertQuestionType();
            }
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            typeData.add(Type);
            if(await typeData.Commit())
            {
                TempData["Message"] = $"Question Type Added";
                return RedirectToPage("./Admin");
            }

            return RedirectToPage("./NotFound");
        }
    }
}
