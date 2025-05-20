using BloggieWeb.Data;
using BloggieWeb.Migrations;
using BloggieWeb.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BloggieWeb.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BloggieDbContext bloggieDbContext;

        public BlogPostRepository(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext = bloggieDbContext;
        }
        public async Task<BlogPost> AddtheAsync(BlogPost blogPost)
        {

            await bloggieDbContext.BlogPosts.AddAsync(blogPost);
            await bloggieDbContext.SaveChangesAsync();
            return blogPost;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existingBlog = await bloggieDbContext.BlogPosts.FindAsync(id);

            if (existingBlog != null)
            {
                bloggieDbContext.BlogPosts.Remove(existingBlog);
                await bloggieDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<BlogPost>> GetAllasync() // copy from list page
        {
            return await bloggieDbContext.BlogPosts.ToListAsync();
        }

        public async Task<BlogPost> GetAsync(Guid id) //copy from edit page
        {
            return await bloggieDbContext.BlogPosts.FindAsync(id);
        }

        public async Task<BlogPost> UpdateAsync(BlogPost blogPost)
        {
            var existingBlogPost = await bloggieDbContext.BlogPosts.FindAsync(blogPost.Id);

            if (existingBlogPost != null)
            {
                existingBlogPost.Heading = blogPost.Heading;
                existingBlogPost.Content = blogPost.Content;
                existingBlogPost.PageTitle = blogPost.PageTitle;
                existingBlogPost.ShortDescription = blogPost.ShortDescription;
                existingBlogPost.FeaturedImageUrl = blogPost.FeaturedImageUrl;
                existingBlogPost.UrlHandle = blogPost.UrlHandle;
                existingBlogPost.PublishedDate = blogPost.PublishedDate;
                existingBlogPost.Aurthor = blogPost.Aurthor;
                existingBlogPost.Visible = blogPost.Visible;
            }

            await bloggieDbContext.SaveChangesAsync();
            return existingBlogPost;
        }
    }
}