using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT420.Data;
using IT420.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using IT420.Data.TalkData;
using Microsoft.AspNetCore.Authorization;
using IT420.Areas.Identity.Data;

namespace IT420.Pages.Talks
{
    [AllowAnonymous]
    public class ListModel : PageModel
    {
        private readonly ITalkData talkData;
        private readonly ITypeData typeData;
        private readonly IAccountData accountData;

        public IEnumerable<Core.Talk> Talks { get; set; }
        public IQueryable<UserProfile> userProfiles { get; set; }
        public TalkType Type { get; set; }        

        [BindProperty(SupportsGet =true)]
        public string searchTerm { get; set; }

        [TempData]
        public string Message { get; set; }

        public ListModel(ITalkData talkData, ITypeData typeData, IAccountData accountData)
        {            
            this.talkData = talkData;
            this.typeData = typeData;
            this.accountData = accountData;
        }

        public void OnGet(int SelectedTypeID)
        {            
            //Talks = talkData.GetTalksByType(SelectedTypeID);
            Talks = talkData.GetTalksByName(searchTerm, SelectedTypeID);
            Type = typeData.GetType(SelectedTypeID);
            userProfiles = accountData.GetAll();
        }
    }
}