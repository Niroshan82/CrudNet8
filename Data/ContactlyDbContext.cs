using CrudNet8.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CrudNet8.Data
{
    public class ContactlyDbContext : DbContext
    {
        public ContactlyDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
