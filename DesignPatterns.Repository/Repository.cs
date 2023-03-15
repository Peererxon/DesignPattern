using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DesingpatternContext _context;
        private DbSet<TEntity> _dbSet;

        public Repository(DesingpatternContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(int id)
        {
            var dataToDelete = _dbSet.Find(id);
            if (dataToDelete != null)
            {
                _dbSet.Remove(dataToDelete);
            }
        }

        public IEnumerable<TEntity> Get()
        {
            return _dbSet.ToList();
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id)!;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(TEntity data)
        {
            _dbSet.Attach(data);
            _context.Entry(data).State = EntityState.Modified;
        }
    }
