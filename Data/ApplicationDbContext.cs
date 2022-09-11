using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FaveProgrammingLang.Models;

namespace FaveProgrammingLang.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<FaveProgrammingLang.Models.Survey>? Survey { get; set; }
    }
}