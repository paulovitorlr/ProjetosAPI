using Microsoft.EntityFrameworkCore;
using ProjetosAPI.Models;

namespace ProjetosAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Projeto> Projetos => Set<Projeto>();
}