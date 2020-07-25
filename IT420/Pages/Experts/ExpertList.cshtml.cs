using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT420.Core;
using IT420.Data.ExpertData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IT420.Pages.Experts
{
    [AllowAnonymous]
    public class ExpertListModel : PageModel
    {
        private readonly IExpertData expertData;

        public IQueryable<Expert> Experts { get; set; }

        public ExpertListModel(IExpertData expertData)
        {
            this.expertData = expertData;
        }
        
        public void OnGet()
        {
            Experts = expertData.GetAll();
        }
    }
}
