using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RDKHomeSolutions.Website.Models
{
    public class NewsLetterSubscribeModel
    {
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }
    }
}