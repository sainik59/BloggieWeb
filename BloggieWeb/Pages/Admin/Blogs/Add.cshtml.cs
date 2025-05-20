using BloggieWeb.Data;
using BloggieWeb.Models.Domain;
using BloggieWeb.Models.ViewModels;
using BloggieWeb.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace BloggieWeb.Pages.Admin.Blogs
{
    public class AddModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;

        [BindProperty]
        public AddBlogPost AddBlogPostRequest { get; set; }

        [BindProperty]

        public IFormFile FeaturedImage {  get; set; }

        public AddModel(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }

        public void OnGet()
        {
        }
        
        public async Task<IActionResult> OnPost() 
        {
            // This method is without data binding

            //var heading = Request.Form["heading"];
            //var pageTitle = Request.Form["pageTitle"];
            //var content = Request.Form["content"];
            //var shortDescription = Request.Form["shortDescription"];
            //var featuredImageUrl = Request.Form["featuredImageUrl"];

            var blogPost = new BlogPost()
            {
                Heading = AddBlogPostRequest.Heading,
                PageTitle = AddBlogPostRequest.PageTitle,
                Content = AddBlogPostRequest.Content,
                ShortDescription = AddBlogPostRequest.ShortDescription,
                FeaturedImageUrl = AddBlogPostRequest.FeaturedImageUrl,
                UrlHandle = AddBlogPostRequest.UrlHandle,
                PublishedDate = AddBlogPostRequest.PublishedDate,
                Aurthor = AddBlogPostRequest.Aurthor,
                Visible = AddBlogPostRequest.Visible,

            };

            await blogPostRepository.AddtheAsync(blogPost);
            var notification = new Notification
            {
                Type = Enum.NotificationType.Success,
                Message = "New Blog is Created"
            };
            TempData["Notification"] = JsonSerializer.Serialize(notification);
            return RedirectToPage("/Admin/Blogs/List");

        }
    }
}
