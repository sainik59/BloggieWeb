using BloggieWeb.Models.Domain;

namespace BloggieWeb.Repositories
{
    public interface IBlogPostRepository
    {
        Task<IEnumerable<BlogPost>> GetAllasync(); // This will getting all the  Blogposts stored inside db
        Task<BlogPost> GetAsync(Guid id);  // Getting single blog post 

        Task<BlogPost> AddtheAsync(BlogPost blogPost);

        Task<BlogPost> UpdateAsync(BlogPost blogPost);
        Task<bool> DeleteAsync(Guid id);
          

    }
}
