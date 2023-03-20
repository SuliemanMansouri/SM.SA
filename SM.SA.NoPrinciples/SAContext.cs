using System.Data.Entity;

namespace SM.SA.NoPrinciples
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
