using FA.JustBlog.Core.DataContext;
using FA.JustBlog.Core.Repositories.ImplementRepo;
using FA.JustBlog.Core.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Test
{
    public class BaseTest
    {
        protected ICategoryRepository _categoryRepository;
        protected IPostRepository _postRepository;
        protected ITagRepository _tagRepository;

        protected JustBlogContext _context;
        /// <summary>
        /// set up va ket noi toi cac class repository
        /// </summary>
        public BaseTest()
        {
            DbContextOptions<JustBlogContext> dbContextOptions = new DbContextOptionsBuilder<JustBlogContext>().UseInMemoryDatabase(databaseName: "JustBlogDB").Options;

            _context = new JustBlogContext(dbContextOptions);
            _context.SeedDataTest();

            _categoryRepository = new CategoryRepository(_context);
            _postRepository = new PostRepository(_context);
            _tagRepository = new TagRepository(_context);
        }
    }
}
