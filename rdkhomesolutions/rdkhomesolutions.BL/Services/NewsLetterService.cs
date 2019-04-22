using RDKHomeSolutions.DAL;
using System;
using System.Threading.Tasks;
using RDKHomeSolutions.DAL.Models;

namespace RDKHomeSolutions.BL.Services
{
    public class NewsLetterService : INewsLetterService
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(NewsLetterService));
        private readonly IUnitOfWork _unitOfWork;

        public NewsLetterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<(bool result, string message)> Subscribe(string emailAddress)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(emailAddress))
                {
                    return (false, "An email address is required");
                }

                var newsLetterSubscriber =
                    await _unitOfWork.NewsLetterSubscriberRepository.GetNewsLetterSubscriberByEmail(emailAddress);

                if (newsLetterSubscriber != null)
                {
                    return (false, $"An email address: {emailAddress} already exists.");
                }

                newsLetterSubscriber = new NewsLetterSubscriber
                {
                    Email = emailAddress
                };

                _unitOfWork.NewsLetterSubscriberRepository.Add(newsLetterSubscriber);

                await _unitOfWork.Complete();

                return (true, $"Email address: {emailAddress} successfully added.");
            }
            catch (Exception e)
            {
                Log.Error($"An error occurred trying to subscribe the following email address {emailAddress}", e);
                return (false, $"An error occurred trying to subscribe the following email address {emailAddress}");
            }
        }
    }
}
