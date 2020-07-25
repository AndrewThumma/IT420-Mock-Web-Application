using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT420.Core;
using IT420.Data.BlogData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IT420.Pages.Admin
{
    [Authorize(Policy = "IsAdmin")]
    public class AddBlogTypeModel : PageModel
    {
        private readonly IBlogTypeData typeData;
        [BindProperty]
        public BlogType Type { get; set; }

        public AddBlogTypeModel(IBlogTypeData typeData)
        {
            this.typeData = typeData;
        }
        
        public void OnGet()
        {
            if (Type == null)
            {
                Type = new BlogType();
            }
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            typeData.Add(Type);
            
            if (await typeData.Commit())
            {
                TempData["Message"] = $"Type Added";
                return RedirectToPage("./Admin");
            }
            return RedirectToPage("./NotFound");
        }
    }
}
