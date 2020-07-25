using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IT420.Areas.Identity.Data;
using IT420.Core;
using IT420.Data.ExpertData;
using IT420.Migrations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IT420.Areas.Identity.Pages.Account
{
    public class MakeExpertModel : PageModel
    {
        private readonly IAccountData accountData;
        private readonly IExpertData expertData;

        public UserProfile userProfile { get; set; }
        [BindProperty]
        public InputModel Input { get; set; }
        public Expert expert { get; set; }

        public class InputModel
        {
            [Required]
            [MaxLength(100)]
            public string firstName { get; set; }
            [Required]
            [MaxLength(100)]
            public string lastName { get; set; }
            [Required]
            [MaxLength(100)]
            public string specialty { get; set; }
            [Required]
            [Column(TypeName = "text")]
            public string bio { get; set; }
            public IFormFile image { get; set; }
            [Required]
            [ForeignKey("FK_userId")]
            public string userId { get; set; }
        }

        public MakeExpertModel(IAccountData accountData, IExpertData expertData)
        {
            this.accountData = accountData;
            this.expertData = expertData;
        }

        public IActionResult OnGet(string userId)
        {
            userProfile = accountData.GetById(userId);
            if (userProfile == null)
            {
                return RedirectToPage("./NotFound");
            }
            Input = new InputModel
            {
                userId = userProfile.Id,
                firstName = userProfile.firstName,
                lastName = userProfile.lastName
            };
            return Page();
        }

        public async Task<IActionResult> OnPost(string userId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            MemoryStream ms = new MemoryStream();

            foreach (var file in Request.Form.Files)
            {
                file.CopyTo(ms);
            }

            expert = new Expert
            {
                firstName = Input.firstName,
                lastName = Input.lastName,
                bio = Input.bio,
                specialty = Input.specialty,
                userId = Input.userId,
                image = ms.ToArray()
            };

            ms.Close();
            ms.Dispose();

            userProfile = accountData.GetById(userId);
            userProfile.IsExpert = true;
            
            accountData.Update(userProfile);
            expertData.Add(expert);

            if (await expertData.Commit() && await accountData.Commit())
            {
                TempData["Message"] = $"{userProfile.firstName} {userProfile.lastName} added as expert";
                return RedirectToPage("./ListUsers");
            }
            return RedirectToPage("./NotFound");            
        }
    }
}
