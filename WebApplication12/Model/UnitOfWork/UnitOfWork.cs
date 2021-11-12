using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication12.Model.Context;
using WebApplication12.Model.Interfaces;
using WebApplication12.Model.Repository;

namespace WebApplication12.Model.UnitOfWork
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly DataContext _context;
        private IGenericRepository<T> _entity;
        public UnitOfWork( DataContext context )
        {
            _context = context;
        }
        public IGenericRepository<T> Entity { 
        
        get
            {
                return _entity ??(_entity=new GenericRepository<T>  (_context));
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
