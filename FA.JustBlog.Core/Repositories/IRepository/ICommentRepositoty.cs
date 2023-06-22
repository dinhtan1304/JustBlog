using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.GennericRepo;

namespace FA.JustBlog.Core.Repositories.IRepository
{
    public interface ICommentRepositoty : IGennericRepository<Comment>
    {
        void AddComment(int postId, string commentName, string commentEmail, string commentTitle, string commentBody);

        IList<Comment> GetCommentsForPost(int postId);
        IList<Comment> GetCommentsForPost(Post post);
    }
}
