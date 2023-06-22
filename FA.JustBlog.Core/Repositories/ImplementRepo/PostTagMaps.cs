using FA.JustBlog.Core.DataContext;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.GennericRepo;
using FA.JustBlog.Core.Repositories.IRepository;

namespace FA.JustBlog.Core.Repositories.ImplementRepo
{
    public class PostTagMaps : GennericRepository<PostTagMap>, IPostTagMaps
    {
        public PostTagMaps(JustBlogContext context) : base(context) { }
    }
}
