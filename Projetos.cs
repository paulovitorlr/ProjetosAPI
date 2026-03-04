namespace ProjetosAPI.Models;

public class Projeto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Funcao { get; set; } = string.Empty;
    public DateTime Data { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public string ImagemUrl { get; set; } = string.Empty;
    public bool Ativo { get; set; } = true;
}