using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT420.Core;
using IT420.Data;
using IT420.Data.TalkData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IT420.Pages.Admin
{
    [Authorize(Policy = "IsAdmin")]
    public class AddTalkTypeModel : PageModel
    {
        private readonly ITypeData typeData;
        [BindProperty]
        public TalkType Type { get; set; }

        public AddTalkTypeModel(ITypeData typeData)
        {
            this.typeData = typeData;
        }
        
        public void OnGet()
        {
            if (Type == null)
            {
                Type = new TalkType();
            }
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            typeData.Add(Type);
            if (await typeData.Commit())
            {
                TempData["Message"] = $"New Talk Type Added";
                return RedirectToPage("./Admin");
            }
            return RedirectToPage("./NotFound");
        }
    }
}
