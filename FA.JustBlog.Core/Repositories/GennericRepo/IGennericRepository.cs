namespace FA.JustBlog.Core.Repositories.GennericRepo
{
    public interface IGennericRepository<TEntity> where TEntity : class
    {
        void Create(TEntity entity);

        void CreateRange(TEntity entity);

        void Update(TEntity entity);

        void UpdateRange(TEntity entity);

        void Delete(TEntity entity);

        void Delete(int id);

        IEnumerable<TEntity> GetAll();

        TEntity Find(int id);
    }
}
