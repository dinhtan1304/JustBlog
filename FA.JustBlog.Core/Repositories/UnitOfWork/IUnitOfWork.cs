using FA.JustBlog.Core.Repositories.IRepository;

namespace FA.JustBlog.Core.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IPostRepository PostRepository { get; }
        ITagRepository TagRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ICommentRepositoty CommentRepositoty { get; }
        IPostTagMaps PostTagMaps { get; }
        void SaveChange();
    }
}
