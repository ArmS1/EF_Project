using EF_Project.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_Project.Helpers.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DataContext _context;
        private DbSet<TEntity> _table;

        public Repository(DataContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();
        }

        public void Delete(int id)
        {
            var entity = _table.Find(id);

            _table.Remove(entity);
        }

        public void Remove(TEntity entity)
        {
            _table.Remove(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _table.ToList();
        }

        public TEntity GetById(int id)
        {
            return _table.Find(id);
        }

        public void Insert(TEntity entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.UpdatedDate = DateTime.Now;

            _table.Add(entity);
        }

        public void Update(TEntity entity)
        {
            entity.UpdatedDate = DateTime.Now;

            _table.Update(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
