using Microsoft.EntityFrameworkCore;
using Portifolio.Api.Models;

namespace ProjetoAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Projeto> Projetos => Set<Projeto>();
}