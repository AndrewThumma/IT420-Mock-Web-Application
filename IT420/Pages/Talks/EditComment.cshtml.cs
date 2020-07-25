using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT420.Core;
using IT420.Data;
using IT420.Data.TalkData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IT420.Pages.Talks
{
    public class EditCommentModel : PageModel
    {
        private readonly ITalkCommentData talkCommentData;

        [BindProperty]
        public TalkComment Comment { get; set; }

        public EditCommentModel(ITalkCommentData talkCommentData)
        {
            this.talkCommentData = talkCommentData;
        }
        
        public IActionResult OnGet(int SelectedCommentId)
        {
            Comment = talkCommentData.GetById(SelectedCommentId);
            if (Comment == null)
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

            talkCommentData.Update(Comment);
            if (await talkCommentData.Commit())
            {
                TempData["Message"] = $"Comment Updated";
                return RedirectToPage("./Detail", new { SelectedTalkId = Comment.TalkId });
            }
            return RedirectToPage("./NotFound");
        }
    }
}