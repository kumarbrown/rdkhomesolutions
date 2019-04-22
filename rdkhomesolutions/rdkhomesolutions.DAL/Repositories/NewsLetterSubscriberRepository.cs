using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RDKHomeSolutions.DAL.Models;

namespace RDKHomeSolutions.DAL.Repositories
{
    public class NewsLetterSubscriberRepository : Repository<NewsLetterSubscriber>, INewsLetterSubscriberRepository
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(NewsLetterSubscriberRepository));

        public RDKHomeSolutionsContext RdkHomeSolutionsContext => Context as RDKHomeSolutionsContext;

        public NewsLetterSubscriberRepository(RDKHomeSolutionsContext context)
            : base(context)
        {

        }

        public async Task<NewsLetterSubscriber> GetNewsLetterSubscriberByEmail(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    throw new ArgumentNullException(nameof(email));
                }

                var newsLetterSubscriber =
                    await RdkHomeSolutionsContext.NewsLetterSubscribers.FirstOrDefaultAsync(x => x.Email == email);

                return newsLetterSubscriber;
            }
            catch (Exception e)
            {
                Log.Error(e);
                throw;
            }
            
        }
    }
}
