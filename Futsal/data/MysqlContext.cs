using Futsal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Futsal.data
{
    public class MysqlContext : DbContext
    {
        public MysqlContext(DbContextOptions options) : base(options)
        {
             
        }

         public DbSet<booking> Book { get; set; }

        public DbSet<Users> User { get; set; }
    }
}
