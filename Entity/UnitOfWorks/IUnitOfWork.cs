using Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;

        Task CommitAsync();
    }
}
