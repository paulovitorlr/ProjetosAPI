using ProjetosAPI.Data;
using ProjetosAPI.Models;
using Microsoft.EntityFrameworkCore;
using ProjetosAPI.DTOs;



namespace ProjetosAPI.Endpoints;

public static class ProjetoEndpoints
{
    public static void MapProjetoEndpoints(this WebApplication app)
    {
        app.MapGet("/projetos", async 
            (int? page,
            int? pageSize,
            AppDbContext db) =>
        {
            int currentPage = page ?? 1;
            int size = pageSize ?? 3;

            var projetos = await db.Projetos
                .Where(p => p.Ativo)
                .Skip((currentPage -1) * size)
                .Take(size)
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


        //Repassar tudo caso for atualizar
        app.MapPut("/projetos/{id}", async (int id, Projeto inputProjeto, AppDbContext db) =>
        {
            var projeto = await db.Projetos.FindAsync(id);

            if (projeto == null) return Results.NotFound();

            projeto.Nome = inputProjeto.Nome;
            projeto.Ano = inputProjeto.Ano;
            projeto.Funcao = inputProjeto.Funcao;
            projeto.Descricao = inputProjeto.Descricao;
            projeto.ImagemUrl = inputProjeto.ImagemUrl;

            await db.SaveChangesAsync();

            return Results.NoContent();

        });

        app.MapDelete("/projetos/{id}", async (int id, AppDbContext db) =>
        {
            if (await db.Projetos.FindAsync(id) is Projeto projeto)
            {
                db.Projetos.Remove(projeto);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }

            return Results.NotFound();
        });
    }
}