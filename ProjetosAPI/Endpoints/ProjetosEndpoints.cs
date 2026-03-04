using Microsoft.EntityFrameworkCore;
using ProjetosAPI.Data;
using ProjetosAPI.DTOs;
using ProjetosAPI.Models;

namespace ProjetosAPI.Endpoints;

public static class ProjetoEndpoints
{
    public static void MapProjetoEndpoints(this WebApplication app)
    {
        app.MapGet("/projetos", async (AppDbContext db) =>
        {
            var projetos = await db.Projetos
                .Where(p => p.Ativo)
                .Select(p => new ProjetoResponse(
                    p.Id,
                    p.Nome,
                    p.Funcao,
                    p.Ano,
                    p.Descricao,
                    p.ImagemUrl
                ))
                .ToListAsync();

            return Results.Ok(projetos);
        });

        app.MapPost("/projetos", async (Projeto projeto, AppDbContext db) =>
        {
            db.Projetos.Add(projeto);
            await db.SaveChangesAsync();
            return Results.Created($"/projetos/{projeto.Id}", projeto);
        });
    }
}