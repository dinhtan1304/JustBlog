using FA.JustBlog.Core.DataContext;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.GennericRepo;
using FA.JustBlog.Core.Repositories.IRepository;

namespace FA.JustBlog.Core.Repositories.ImplementRepo
{
    public class PostRepository : GennericRepository<Post>, IPostRepository
    {

        public PostRepository(JustBlogContext context = null) : base(context) { }
        /// <summary>
        /// dem so post lay duoc theo category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public int CountPostsForCategory(string category)
        {
            return context.Posts.Where(p => p.Category.Name.ToLower() == category.ToLower()).Count();
        }
        /// <summary>
        /// dem so post lay duoc theo tag
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public int CountPostsForTag(string tag)
        {
            return context.Posts.Count(p => context.PostTagMaps
                                                    .Where(ptm => context.Tags
                                                                         .Where(t => t.Name.ToLower() == tag.ToLower())
                                                                         .Select(t => t.Id)
                                                                         .Contains(ptm.TagId))
                                                    .Select(ptm => ptm.PostId)
                                                    .Contains(p.Id));
        }
        /// <summary>
        /// Tim post theo thang nam va urlSlug
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="urlSlug"></param>
        /// <returns></returns>
        public Post FindPost(int year, int month, string urlSlug)
        {
            return context.Posts.FirstOrDefault(p => p.PostedOn.Year == year && p.PostedOn.Month == month && p.UrlSlug == urlSlug);
        }

        /// <summary>
        /// lay ra so cac bai post co rate cao theo so lieu nhap vao
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public IList<Post> GetHighestPosts(int size)
        {
            return context.Posts.OrderByDescending(p => p.RateCount).Take(size).ToList();
        }
        /// <summary>
        /// lay ra so cac bai post da duoc sua gan nhat theo so lieu nhap vao
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public IList<Post> GetLatestPost(int size)
        {
            return context.Posts.OrderByDescending(p => p.PostedOn).Take(size).ToList();
        }
        /// <summary>
        /// lay ra so cac bai post co view cao theo so lieu nhap vao
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public IList<Post> GetMostViewedPost(int size)
        {
            return context.Posts.OrderByDescending(p => p.ViewCount).Take(size).ToList();
        }
        /// <summary>
        /// lay ra so cac bai post theo category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public IList<Post> GetPostsByCategory(string category)
        {
            return context.Posts.Where(p => string.IsNullOrEmpty(category) || p.Category.Name.ToLower() == category.ToLower()).ToList();
        }
        /// <summary>
        /// lay ra so cac bai post theo thang ma post duoc tao
        /// </summary>
        /// <param name="monthYear"></param>
        /// <returns></returns>
        public IList<Post> GetPostsByMonth(DateTime monthYear)
        {
            return context.Posts.Where(p => p.PostedOn.Month.Equals(monthYear.Month)).ToList();
        }
        /// <summary>
        /// lay ra so cac bai post theo Tag
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public IList<Post> GetPostsByTag(string tag)
        {
            return context.Posts.Where(p => context.PostTagMaps
                                        .Where(ptm => context.Tags
                                                             .Where(t => (string.IsNullOrEmpty(tag) || t.UrlSlug.ToLower() == tag.ToLower()))
                                                             .Select(t => t.Id)
                                                             .Contains(ptm.TagId))
                                        .Select(ptm => ptm.PostId)
                                        .Contains(p.Id)).ToList();
        }
        /// <summary>
        /// lay ra so cac bai post theo publised
        /// </summary>
        /// <returns></returns>
        public IList<Post> GetPublisedPosts()
        {
            return context.Posts.Where(p => p.Published.Equals(true)).ToList();
        }
        /// <summary>
        /// lay ra so cac bai post theo unpublised
        /// </summary>
        /// <returns></returns>
        public IList<Post> GetUnpublisedPosts()
        {
            return context.Posts.Where(p => p.Published.Equals(false)).ToList();
        }
    }
}
