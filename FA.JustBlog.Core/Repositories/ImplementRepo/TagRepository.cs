using FA.JustBlog.Core.DataContext;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.GennericRepo;
using FA.JustBlog.Core.Repositories.IRepository;

namespace FA.JustBlog.Core.Repositories.ImplementRepo
{
    public class TagRepository : GennericRepository<Tag>, ITagRepository
    {
        public TagRepository(JustBlogContext context) : base(context) { }

        /// <summary>
        /// lay tag theo category
        /// </summary>
        /// <param name="urlSlug"></param>
        /// <returns></returns>
        public Tag GetTagByUrlSlug(string urlSlug)
        {
            return context.Tags.FirstOrDefault(t => t.UrlSlug.ToLower() == urlSlug.ToLower());
        }

        IEnumerable<Tag> ITagRepository.GetTagByPostId(int postId)
        {
            return context.PostTagMaps
                          .Join(context.Tags, postTag => postTag.TagId, tag => tag.Id, (postTag, tag) => new { postTag, tag })
                          .Where(joinResult => joinResult.postTag.PostId == postId)
                          .Select(joinResult => joinResult.tag);
        }
    }
}
