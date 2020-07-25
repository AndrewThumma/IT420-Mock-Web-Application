using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT420.Areas.Identity.Data;
using IT420.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IT420.Areas.Identity.Pages.Account
{
    public class ListUsersModel : PageModel
    {
        private readonly IAccountData accountData;
        public IEnumerable<UserProfile> Users { get; set; }
        [TempData]
        public string Message { get; set; }

        public ListUsersModel(IAccountData accountData)
        {
            this.accountData = accountData;
        }
        
        public void OnGet()
        {
            Users = accountData.GetAll();
        }
    }
}
