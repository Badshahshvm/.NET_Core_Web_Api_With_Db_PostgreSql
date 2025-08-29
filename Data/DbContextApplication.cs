
using Microsoft.EntityFrameworkCore;
using WebApplicationWithDB.Models.Entities;

namespace WebApplicationWithDB.Data
{
    public class DbContextApplication:DbContext
    {
        public DbContextApplication(DbContextOptions <DbContextApplication> options):base(options)
        {

        }

        public DbSet<Employee> employees { get; set; }

    }
}
