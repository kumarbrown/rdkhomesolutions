using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDKHomeSolutions.BL.Services
{
    public interface INewsLetterService
    {
        Task<(bool result, string message)> Subscribe(string emailAddress);
    }
}
