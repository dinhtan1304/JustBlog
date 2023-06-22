using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.GennericRepo;

namespace FA.JustBlog.Core.Repositories.IRepository
{
    public interface IPostRepository : IGennericRepository<Post>
    {
        Post FindPost(int year, int month, string urlSlug);
        IList<Post> GetPublisedPosts();
        IList<Post> GetUnpublisedPosts();
        IList<Post> GetLatestPost(int size);
        IList<Post> GetPostsByMonth(DateTime monthYear);
        int CountPostsForCategory(string category);
        IList<Post> GetPostsByCategory(string category);
        int CountPostsForTag(string tag);
        IList<Post> GetPostsByTag(string tag);

        IList<Post> GetMostViewedPost(int size);
        IList<Post> GetHighestPosts(int size);
    }
}
