using BloggieWeb.Data;
using BloggieWeb.Models.Domain;
using BloggieWeb.Models.ViewModels;
using BloggieWeb.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace BloggieWeb.Pages.Admin.Blogs
{
    public class EditModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;

        [BindProperty]
        public BlogPost BlogPost { get; set; }

        [BindProperty]
        public IFormFile FeaturedImage { get; set; }
        public EditModel(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }
        public async Task OnGet(Guid id)
        {
            BlogPost= await blogPostRepository.GetAsync(id);
        }

        public async Task<IActionResult> OnPostEdit()
        {
            try
            {
                
                await blogPostRepository.UpdateAsync(BlogPost);

                ViewData["Notification"] = new Notification
                {                   
                    Type = Enum.NotificationType.Success,
                    Message = "Record updated successfully"
                };
            }
            catch (Exception ex)
            {
                ViewData["Notification"] = new Notification
                {
                    Type = Enum.NotificationType.Error,
                    Message = "Something went wrong!"
                };
                
            }
            return Page();
            //return RedirectToPage("/Admin/Blogs/List");

        }

        public async Task<IActionResult> OnPostDelete()
        {
            var deleted = await blogPostRepository.DeleteAsync(BlogPost.Id);

            if (deleted != null)
            {
                var notification = new Notification
                {
                    Type = Enum.NotificationType.Success,
                    Message = "Blog was deleted successfully!"
                };
                TempData["Notification"] = JsonSerializer.Serialize(notification);

                return RedirectToPage("/Admin/Blogs/List");
            }

            return Page(); // used to stay on current page if a null value encounters.

        }
    }
}


