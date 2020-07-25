using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT420.Core;
using IT420.Data.ExpertData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IT420.Pages.Experts
{
    public class ManageExpertsModel : PageModel
    {
        private readonly IExpertData expertData;
        public IQueryable<Expert> Experts { get; set; }
        [TempData]
        public string Message { get; set; }

        public ManageExpertsModel(IExpertData expertData)
        {
            this.expertData = expertData;
        }
        
        public void OnGet()
        {
            Experts = expertData.GetAll();
        }
    }
}
