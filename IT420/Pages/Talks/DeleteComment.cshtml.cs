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
    public class DeleteCommentModel : PageModel
    {
        private readonly ITalkCommentData talkCommentData;
        public TalkComment Comment { get; set; }

        public DeleteCommentModel(ITalkCommentData talkCommentData)
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

        public async Task<IActionResult> OnPost(int SelectedCommentId)
        {
            Comment = talkCommentData.GetById(SelectedCommentId);
            if (Comment == null)
            {
                return RedirectToPage("./NotFound");
            }

            talkCommentData.Delete(Comment);
            
            if (await talkCommentData.Commit())
            {
                TempData["Messate"] = $"Comment Deleted!";
                return RedirectToPage("./Detail", new { SelectedTalkId = Comment.TalkId });
            }

            return RedirectToPage("./NotFound");
        }
    }
}