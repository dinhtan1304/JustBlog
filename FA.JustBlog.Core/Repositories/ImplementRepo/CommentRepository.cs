using FA.JustBlog.Core.DataContext;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.GennericRepo;
using FA.JustBlog.Core.Repositories.IRepository;

namespace FA.JustBlog.Core.Repositories.ImplementRepo
{
    public class CommentRepository : GennericRepository<Comment>, ICommentRepositoty
    {

        public CommentRepository(JustBlogContext context) : base(context) { }
        /// <summary>
        /// add comment
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="commentName"></param>
        /// <param name="commentEmail"></param>
        /// <param name="commentTitle"></param>
        /// <param name="commentBody"></param>
        public void AddComment(int postId, string commentName, string commentEmail, string commentTitle, string commentBody)
        {
            var newComment = new Comment
            {
                PostId = postId,
                Name = commentName,
                Email = commentEmail,
                CommentHeader = commentTitle,
                CommentText = commentBody,
                CommentTime = DateTime.Now,
            };

            context.Comments.Add(newComment);
        }
        /// <summary>
        /// lay comment thoe post id
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public IList<Comment> GetCommentsForPost(int postId)
        {
            return context.Comments.Where(c => c.PostId == postId).ToList();
        }
        /// <summary>
        /// lay comment theo post
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public IList<Comment> GetCommentsForPost(Post post)
        {
            return context.Comments.Where(c => c.PostId == post.Id).ToList();
        }
    }
}
