using Microsoft.EntityFrameworkCore;
namespace FimlesCrudRazor.Models
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> options): base(options)
        {
            //Default
        }
        public DbSet<Filme> Filme { get; set; }
    }
}