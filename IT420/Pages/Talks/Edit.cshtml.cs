using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT420.Core;
using IT420.Data;
using IT420.Data.TalkData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;

namespace IT420.Pages.Talks
{
    public class EditModel : PageModel
    {
        private readonly ITalkData talkData;

        [BindProperty]
        public Talk Talk { get; set; }

        public EditModel(ITalkData talkData)
        {
            this.talkData = talkData;
        }
        
        public IActionResult OnGet(int SelectedTalkId)
        {
            Talk = talkData.GetTalkById(SelectedTalkId);
            if (Talk == null)
            {
                RedirectToPage("./NotFound");
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            talkData.Update(Talk);
            if (await talkData.Commit())
            {
                TempData["Message"] = $"Talk Upated";
                return RedirectToPage("./detail", new { SelectedTalkId = Talk.TalkId });
            }
            return RedirectToPage("./NotFound");
        }
    }
}