using System.Threading.Tasks;
using IT420.Core;
using IT420.Data.BlogData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IT420.Pages.Blogs
{
    public class DeleteBlogModel : PageModel
    {
        private readonly IBlogData blogData;
        
        public Blog blog { get; set; }

        public DeleteBlogModel(IBlogData blogData)
        {
            this.blogData = blogData;
            
        }
        
        public IActionResult OnGet(int blogId)
        {
            blog = blogData.GetById(blogId);
            if (blog == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public async Task<ActionResult> OnPost(int blogId)
        {
            blog = blogData.GetById(blogId);
            if (blog == null)
            {
                return RedirectToPage("./NotFound");
            }
            blogData.Delete(blog);
            if (await blogData.Commit())
            {
                TempData["Message"] = $"Blog Deleted!";
                return RedirectToPage("./List", new { blogTypeId = blog.blogTypeId });
            }
            return RedirectToPage("./NotFound");
        }
    }
}