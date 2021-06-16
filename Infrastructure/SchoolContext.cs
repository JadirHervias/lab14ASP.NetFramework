using System.Data.Entity;
using Domain;

namespace Infrastructure
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(): base("name = MyContextDB") {
        }

        public DbSet<Student> Students { get; set; }
    }
}
