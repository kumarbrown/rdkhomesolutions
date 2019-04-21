using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDKHomeSolutions.DAL.Models;

namespace RDKHomeSolutions.DAL.Repositories
{
    public interface INewsLetterSubscriberRepository : IRepository<NewsLetterSubscriber>
    {
        Task<NewsLetterSubscriber> GetNewsLetterSubscriberByEmail(string email);
    }
}
