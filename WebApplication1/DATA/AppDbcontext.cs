namespace WebApplication1.DATA
{
    using Microsoft.EntityFrameworkCore;
    public class AppDbcontext : DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options)
        {
        }

        public DbSet<MODELS.AutorModel> Autores { get; set; }
        public DbSet<MODELS.LivrosModel> Livros { get; set; }


    }
}