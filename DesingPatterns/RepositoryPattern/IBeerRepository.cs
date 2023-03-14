using DesingPatterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPatterns.RepositoryPattern
{
    public interface IBeerRepository
    {
        IEnumerable<Beer> Get();

        Beer GetById(int id );

        void Delete(int id);

        void Update(Beer data);

        void Save();

    }
}
