using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IT420.Pages.Admin
{
    [Authorize(Policy ="IsAdmin")]
    public class AdminModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
