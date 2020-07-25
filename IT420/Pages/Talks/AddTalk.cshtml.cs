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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IT420.Pages.Talks
{
    
    public class AddTalkModel : PageModel
    {
        private readonly ITalkData talkData;
        private readonly ITypeData typeData;

        [BindProperty]
        public Talk Talk { get; set; }
        public SelectList typeList { get; set; }
        public IQueryable<TalkType> Types { get; set; }

        public AddTalkModel(ITalkData talkData, ITypeData typeData)
        {
            this.talkData = talkData;
            this.typeData = typeData;
            if (Talk == null)
            {
                Talk = new Talk();
                Talk.CreatedDate = DateTime.Now;
            }
        }

        public void OnGet()
        {
            Types = typeData.GetAll();
            typeList = new SelectList(Types, "TypeId", "Type");
        }

        public async Task<IActionResult> OnPost()
        {
            Types = typeData.GetAll();
            typeList = new SelectList(Types, "TypeId", "Type");
            
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