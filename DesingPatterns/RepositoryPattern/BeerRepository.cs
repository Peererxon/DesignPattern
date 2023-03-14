using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesingPatterns.Models;
using Microsoft.EntityFrameworkCore;

namespace DesingPatterns.RepositoryPattern
{
    internal class BeerRepository : IBeerRepository
    {

        private DesingpatternContext _context;

        public BeerRepository(DesingpatternContext context)
        {
            _context = context;
        }

        public void Add(Beer data)
        {
            _context.Beers.Add(data);
        }

        public void Delete(int id)
        {
            var beer = _context.Beers.Find(id);
            _context.Beers.Remove(beer);
        }

        public Beer GetById(int id)
        {
           Beer beer = _context.Beers.FirstOrDefault<Beer>( (beer)=> beer.BeerId == id )!;
            return beer;
        }

        public IEnumerable<Beer> Get()
        {
            return _context.Beers.ToList();
        }

        public void Save() => _context.SaveChanges();

        public void Update(Beer data)
        {
            _context.Entry(data).State = EntityState.Modified;
        }

        // SI no corres save la db no se actualiza nunca
        
    }
}
