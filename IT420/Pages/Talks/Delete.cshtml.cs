using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT420.Core;
using IT420.Data;
using IT420.Data.TalkData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IT420.Pages.Talks
{
    public class DeleteModel : PageModel
    {
        private readonly ITalkData talkData;
        private readonly ITalkCommentData talkCommentData;
        
        public Talk Talk { get; set; }
        public IEnumerable<TalkComment> TalkComments { get; set; }

        public DeleteModel(ITalkData talkData, ITalkCommentData talkCommentData)
        {
            this.talkData = talkData;
            this.talkCommentData = talkCommentData;
        }
        
        public IActionResult OnGet(int SelectedTalkId)
        {
            Talk = talkData.GetTalkById(SelectedTalkId);
            if (Talk == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public async Task<IActionResult> OnPost(int SelectedTalkId)
        {
            Talk = talkData.GetTalkById(SelectedTalkId);
            TalkComments = talkCommentData.GetAll(SelectedTalkId);
            if (TalkComments != null)
            {
                foreach (var comment in TalkComments)
                {
                    talkCommentData.Delete(comment);
                }
            }
            talkData.Delete(Talk);
            
            if (await talkData.Commit())
            {
                TempData["Message"] = $"{Talk.Name} Deleted";
                return RedirectToPage("./List", new { SelectedTypeID = Talk.TypeId });
            }

            return RedirectToPage("./NotFound");

        }
    }
}