using SM.SA.Domain.Entities;
using System.Data.Entity;

namespace SM.SA.Infrastructure.Context
{

    public class SAContext : DbContext
    {
        public SAContext()
        : base("ConnStr")
        {

        }

        public DbSet<Student> Students { get; set; }
    }

}
