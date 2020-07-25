using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IT420.Core;
using IT420.Data.ExpertData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IT420.Pages.Experts
{
    public class UpdateExpertModel : PageModel
    {
        private readonly IExpertData expertData;

        [BindProperty]
        public InputModel Input { get; set; }
        public Expert Expert { get; set; }

        public UpdateExpertModel(IExpertData expertData)
        {
            this.expertData = expertData;
        }

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

        public IActionResult OnGet(int expertId)
        {
            Expert = expertData.GetById(expertId);
            if (Expert == null)
            {
                return RedirectToPage("./NotFound");
            }
            Input = new InputModel
            {
                firstName = Expert.firstName,
                lastName = Expert.lastName,
                specialty = Expert.specialty,
                bio = Expert.bio,
                userId = Expert.userId
            };
            return Page();
        }

        public async Task<IActionResult> OnPost(int expertId)
        {
            Expert = expertData.GetById(expertId);

            if (!ModelState.IsValid)
            {
                return Page();
            }

            MemoryStream ms = new MemoryStream();

            foreach (var file in Request.Form.Files)
            {
                file.CopyTo(ms);
            }
            
            

            Expert.firstName = Input.firstName;
            Expert.lastName = Input.lastName;
            Expert.specialty = Input.specialty;
            Expert.bio = Input.bio;
            Expert.image = ms.ToArray();

            expertData.Update(Expert);
            if (await expertData.Commit())
            {
                TempData["Message"] = $"Expert {Expert.id} updated";
                return RedirectToPage("./ExpertList");
            }
            return RedirectToPage("./NotFound");
        }
    }
}
