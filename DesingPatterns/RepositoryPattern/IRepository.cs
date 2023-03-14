using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPatterns.RepositoryPattern
{
    //Repositorio con genericos
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> Get();

        TEntity GetById(int id);

        void Delete(int id);

        void Update(TEntity data);
        void Add(TEntity entity);

        void Save();

    }
}
