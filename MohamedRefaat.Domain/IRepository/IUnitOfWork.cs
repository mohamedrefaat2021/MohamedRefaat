using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MohamedRefaat.Domain.IRepository
{
    public interface IUnitOfWork<T> : IDisposable where T : class
    {
        IRepositoryAsync<T> Repository { get; }       
        bool Commit();
        Task<bool> CommitAsync();
    }
}
