using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IT420.Areas.Identity.Data;
using IT420.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace IT420.Areas.Identity.Pages.Account.Manage
{
    public class ChangeImageModel : PageModel
    {
        private readonly IAccountData accountData;
        private readonly UserManager<UserProfile> userManager;
        private readonly SignInManager<UserProfile> signInManager;

        [TempData]
        public string StatusMessage { get; set; }
        public UserProfile userProfile { get; set; }
        [BindProperty]
        public InputModel Input { get; set; }

        public ChangeImageModel(IAccountData accountData, UserManager<UserProfile> userManager, SignInManager<UserProfile> signInManager)
        {
            this.accountData = accountData;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        

        public class InputModel
        {            
            [Display(Name = "User Image")]
            public IFormFile userImage { get; set; }
        }

        public async Task<IActionResult> OnGet()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }
            userProfile = accountData.GetById(userManager.GetUserId(User));

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userManager.GetUserId(User)}'.");
            }
            userProfile = accountData.GetById(userManager.GetUserId(User));

            MemoryStream ms = new MemoryStream();

            foreach (var file in Request.Form.Files)
            {
                file.CopyTo(ms);
            }

            ms.Close();
            ms.Dispose();

            userProfile.userImg = ms.ToArray();
            accountData.Update(userProfile);
            await accountData.Commit();
            
            await signInManager.RefreshSignInAsync(user);
            StatusMessage = "User Image Updated";
            return RedirectToPage();
            
        }
    }
}
