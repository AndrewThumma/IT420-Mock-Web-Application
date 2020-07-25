using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT420.Areas.Identity.Data;
using IT420.Core;
using IT420.Data;
using IT420.Data.TalkData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace IT420.Pages.Talks
{
    public class DetailModel : PageModel
    {
        private readonly ITalkData talkData;
        private readonly ITalkCommentData commentData;
        private readonly IAccountData accountData;

        public Core.Talk talk { get; set; }
        [BindProperty]
        public TalkComment Comment { get; set; }
        public IEnumerable<TalkComment> comments { get; set; }
        public IQueryable<UserProfile> userProfiles { get; set; }
        [TempData]
        public string Message { get; set; }

        public DetailModel(ITalkData talkData, ITalkCommentData commentData, IAccountData accountData)
        {
            this.talkData = talkData;
            this.commentData = commentData;
            this.accountData = accountData;
            if (Comment == null)
            {
                Comment = new TalkComment();
            }
        }

        public IActionResult OnGet(int SelectedTalkId)
        {
            talk = talkData.GetTalkById(SelectedTalkId);
            if (talk != null)
            {
                RedirectToPage("./Talks/NotFound");
            }
            comments = commentData.GetAll(SelectedTalkId);
            Comment.TalkId = SelectedTalkId;
            Comment.userId = User.Claims.First(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
            userProfiles = accountData.GetAll();
            return Page();
        }

        //code for posting new comment
        public async Task<IActionResult> OnPost(int SelectedTalkId)
        {            
            if (!ModelState.IsValid)
            {
                return Page();
            }

            commentData.Add(Comment);
            
            if (await commentData.Commit())
            {
                TempData["Message"] = $"Comment Added";
                return RedirectToPage("./Detail", new { SelectedTalkId = Comment.TalkId });
            }

            return RedirectToPage("./NotFound");
        }
    }
}