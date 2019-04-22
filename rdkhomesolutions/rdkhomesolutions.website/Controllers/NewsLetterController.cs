using RDKHomeSolutions.BL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using RDKHomeSolutions.Website.Models;


namespace RDKHomeSolutions.Website.Controllers
{
    public class NewsLetterController : Controller
    {
        private readonly INewsLetterService newsLetterService;
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(NewsLetterController));

        public NewsLetterController(INewsLetterService newsLetterService)
        {
            this.newsLetterService = newsLetterService ?? throw new ArgumentNullException(nameof(newsLetterService));
        }

        [HttpPost]
        public async Task<ActionResult> Subscribe(NewsLetterSubscribeModel newsLetterSubscribeModel)
        {
            var resultModel = new ResultModel();
            try
            {
                if (!ModelState.IsValid)
                {
                    resultModel.Result = false;
                    resultModel.Message = "Please submit a valid email address";
                    return Json(resultModel);
                }

                var resultTuple = await newsLetterService.Subscribe(newsLetterSubscribeModel.Email);
                resultModel.Result = resultTuple.result;
                resultModel.Message = resultTuple.message;
            }
            catch (Exception e)
            {
                resultModel.Result = false;
                resultModel.Message = "An error occurred please contact support@rdkhomesolutions.com";
                Log.Error(e);
            }
            return Json(resultModel);
        }
    }
}