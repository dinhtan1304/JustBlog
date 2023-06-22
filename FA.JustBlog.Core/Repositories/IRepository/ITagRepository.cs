using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.GennericRepo;

namespace FA.JustBlog.Core.Repositories.IRepository
{
    public interface ITagRepository : IGennericRepository<Tag>
    {
        Tag GetTagByUrlSlug(string urlSlug);

        IEnumerable<Tag> GetTagByPostId(int postId);
    }
}
