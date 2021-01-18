using CursosEAD.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CursosEAD.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        { }
        public AppDbContext()
        { }
    }
}
