using FA.JustBlog.Core.DataContext;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Core.Repositories.GennericRepo
{
    public class GennericRepository<TEntity> : IGennericRepository<TEntity> where TEntity : class
    {
        protected readonly JustBlogContext context;
        protected DbSet<TEntity> entities;
        /// <summary>
        /// ket noi toi database
        /// </summary>
        /// <param name="context"></param>
        public GennericRepository(JustBlogContext context = null)
        {
            this.context = context ?? new JustBlogContext();
            entities = this.context.Set<TEntity>();
        }
        /// <summary>
        /// ham create new emtity
        /// </summary>
        /// <param name="entity"></param>
        public void Create(TEntity entity)
        {
            entities.Add(entity);
        }

        public void CreateRange(TEntity entity)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Delete 1 entity
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                entities.Attach(entity);
            }
            entities.Remove(entity);
        }
        /// <summary>
        /// Delete theo id tim duoc
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            TEntity entityToDelete = entities.Find(id);
            Delete(entityToDelete);
        }
        /// <summary>
        /// tim etity theo id truyen vao
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity Find(int id)
        {
            return entities.Find(id);
        }
        /// <summary>
        /// lay tat cac entity trong list
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll()
        {
            return entities;
        }
        /// <summary>
        /// updata mot entity
        /// </summary>
        /// <param name="entity"></param>
        public void Update(TEntity entity)
        {
            entities.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public void UpdateRange(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
