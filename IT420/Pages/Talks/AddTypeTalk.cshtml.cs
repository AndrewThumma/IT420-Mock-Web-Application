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

namespace IT420.Pages.Talks
{
    
    public class AddTypeTalkModel : PageModel
    {
        private readonly ITalkData talkData;
        [BindProperty]
        public Talk Talk { get; set; }

        public AddTypeTalkModel(ITalkData talkData)
        {
            this.talkData = talkData;            
            if (Talk == null)
            {
                Talk = new Talk();
                Talk.CreatedDate = DateTime.Now;
            }
        }
        
        public void OnGet(int SelectedTypeID)
        {
            Talk.TypeId = SelectedTypeID;
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Talk.userId = User.Claims.First(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;            
            
            talkData.Add(Talk);

            if (await talkData.Commit())
            {
                Talk newTalk = talkData.GetNewest();
                TempData["Message"] = $"Talk Added";
                return RedirectToPage("./Detail", new { SelectedTalkId = newTalk.TalkId });                
            }
            return RedirectToPage("./NotFound");
        }
    }
}