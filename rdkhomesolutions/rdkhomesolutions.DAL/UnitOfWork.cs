using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDKHomeSolutions.DAL.Repositories;

namespace RDKHomeSolutions.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RDKHomeSolutionsContext _context;

        public UnitOfWork(RDKHomeSolutionsContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            NewsLetterSubscriberRepository = new NewsLetterSubscriberRepository(context);
        }

        public INewsLetterSubscriberRepository NewsLetterSubscriberRepository { get; }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
