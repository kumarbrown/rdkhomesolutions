using System.ComponentModel.DataAnnotations;

namespace RDKHomeSolutions.DAL.Models
{
    public partial class NewsLetterSubscriber
    {
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }
    }
}
