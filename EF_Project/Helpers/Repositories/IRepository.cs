using EF_Project.Entities;

namespace EF_Project.Helpers.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        void Remove(TEntity entity);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();

        void Save();
    }
}
