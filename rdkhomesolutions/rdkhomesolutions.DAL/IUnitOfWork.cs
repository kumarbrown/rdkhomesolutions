using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDKHomeSolutions.DAL.Repositories;

namespace RDKHomeSolutions.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        INewsLetterSubscriberRepository NewsLetterSubscriberRepository { get; }
        Task<int> Complete();
    }
}
