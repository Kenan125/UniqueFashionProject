using DataAccess.Contexts;
using DataAccess.Repositories;
using Entity.Interfaces;
using Entity.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UniqueFashionDbContext _context;
        private bool disposed = false;
        private Dictionary<Type, object> _repositories;

        public UnitOfWork(UniqueFashionDbContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }
        public IRepository<T> GetRepository<T>() where T : class
        {
            if (_repositories.ContainsKey(typeof(T)))
            {
                return (IRepository<T>)_repositories[typeof(T)];
            }

            var repository = new Repository<T>(_context);
            _repositories[typeof(T)] = repository;
            return repository;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);  //GC - Garbage Collector
        }

        public async ValueTask DisposeAsync()
        {
            if (!disposed)
            {
                if (_context != null)
                {
                    await _context.DisposeAsync();
                }

                disposed = true;
            }

            GC.SuppressFinalize(this);
        }
    }
}
