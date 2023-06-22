using FA.JustBlog.Core.DataContext;
using FA.JustBlog.Core.Repositories.ImplementRepo;
using FA.JustBlog.Core.Repositories.IRepository;

namespace FA.JustBlog.Core.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JustBlogContext _context;
        private IPostRepository _postRepository;
        private ICategoryRepository _categoryRepository;
        private ITagRepository _tagRepository;
        private ICommentRepositoty _commentRepositoty;
        private IPostTagMaps _postTagMaps;
        public UnitOfWork(JustBlogContext context = null)
        {
            this._context = context ?? new JustBlogContext();
        }
        public IPostRepository PostRepository => _postRepository ?? new PostRepository(_context);

        public ITagRepository TagRepository => _tagRepository ?? new TagRepository(_context);

        public ICategoryRepository CategoryRepository => _categoryRepository ?? new CategoryRepository(_context);

        public ICommentRepositoty CommentRepositoty => _commentRepositoty ?? new CommentRepository(_context);

        public IPostTagMaps PostTagMaps => _postTagMaps ?? new PostTagMaps(_context);

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();

                }
            }
            this.disposed = true;
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
