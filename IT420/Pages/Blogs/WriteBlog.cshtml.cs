using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IT420.Areas.Identity.Data;
using IT420.Core;
using IT420.Data;
using IT420.Data.BlogData;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IT420.Pages.Blogs
{
    public class WriteBlogModel : PageModel
    {
        private readonly IBlogData blogData;
        private readonly IBlogTypeData typeData;
        private readonly IAccountData accountData;
        private readonly IWebHostEnvironment hostEnvironment;        

        public Blog Blog { get; set; }
        public IEnumerable<BlogType> Types { get; set; }        
        public SelectList typeList { get; set; }
        [BindProperty]
        public InputModel Input { get; set; }

        public WriteBlogModel(IBlogData blogData, IBlogTypeData typeData, IAccountData accountData, IWebHostEnvironment hostEnvironment)
        {
            this.blogData = blogData;
            this.typeData = typeData;
            this.accountData = accountData;
            this.hostEnvironment = hostEnvironment;            
            if (Blog == null)
            {
                Blog = new Blog();
            }
        }

        public class InputModel
        {
            [Required]
            [MaxLength(100)]
            public string name { get; set; }
            [Required]
            [MinLength(20)]
            [DataType(DataType.MultilineText)]
            public string body { get; set; }
            [Required]
            [ForeignKey("blogTypeId")]
            public int blogTypeId { get; set; }
            public IFormFile blogImageURL { get; set; }
            public bool approved { get; set; }
            public DateTime CreatedDate { get; set; }                    
        }

        
        public void OnGet()
        {            
            Types = typeData.GetAll();
            typeList = new SelectList(Types, "blogTypeId", "type");            
        }

        public async Task<ActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                Types = typeData.GetAll();
                typeList = new SelectList(Types, "blogTypeId", "type");
                return Page();
            }

            //Upload image or use default image            
            string filename = null;

            if (Input.blogImageURL != null)
            {
                string uploadFolder = Path.Combine(hostEnvironment.WebRootPath, "images/BlogImages");
                filename = Guid.NewGuid().ToString() + "_" + Input.blogImageURL.FileName;
                string filePath = Path.Combine(uploadFolder, filename);
                await Input.blogImageURL.CopyToAsync(new FileStream(filePath, FileMode.Create));
            }
            else
            {
                filename = "new.jpg";
            }



            //Create new Blog
            Blog = new Blog
            {
                blogTypeId = Input.blogTypeId,
                name = Input.name,
                body = Input.body,
                blogImageURL = filename,
                approved = false,
                userId = User.Claims.First(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value
            };            
            
            blogData.Add(Blog);            
            if ( await blogData.Commit())
            {
                TempData["Message"] = $"Blog Added";
                return RedirectToPage("../Index", new { blogTypeId = Blog.blogTypeId });
            }
            return RedirectToPage("./NotFound");
            
        }
    }
}