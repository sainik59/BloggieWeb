using BloggieWeb.Data;
using BloggieWeb.Models.Domain;
using BloggieWeb.Models.ViewModels;
using BloggieWeb.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.Entity;
using System.Text.Json;

namespace BloggieWeb.Pages.Admin.Blogs
{
    public class ListModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;

        public List<BlogPost> BlogPosts { get; set; }
        public ListModel(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository; 
        }
        public async Task OnGet()
        {
           
            var notificationJson = (string)TempData["Notification"];
            if (notificationJson != null)
            {
                ViewData["Notification"] = JsonSerializer.Deserialize<Notification>(notificationJson);
            }
            BlogPosts = (await blogPostRepository.GetAllasync())?.ToList();
        }
    }
}
