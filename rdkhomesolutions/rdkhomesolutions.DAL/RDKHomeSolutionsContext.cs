using RDKHomeSolutions.DAL.Models;

namespace RDKHomeSolutions.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RDKHomeSolutionsContext : DbContext
    {
        public RDKHomeSolutionsContext()
            : base("name=RDKHomeSolutions")
        {
        }

        public virtual DbSet<NewsLetterSubscriber> NewsLetterSubscribers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NewsLetterSubscriber>()
                .Property(e => e.Email)
                .IsUnicode(false);
        }
    }
}
