namespace ProjetosAPI.DTOs;

public record ProjetoResponse(
    int Id,
    string Nome,
    string Funcao,
    int ano,
    string Descricao,
    string ImagemUrl
);