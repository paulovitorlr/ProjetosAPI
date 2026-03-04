namespace ProjetosAPI.DTOs;

public record ProjetoResponse(
    int Id,
    string Nome,
    string Funcao,
    DateTime Data,
    string Descricao,
    string ImagemUrl
);