using Microsoft.EntityFrameworkCore;

namespace Casestudy.Models
{
    public class MyDbcontext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public MyDbcontext(DbContextOptions<MyDbcontext> options)
            : base(options)
        {
        }
    }
}
