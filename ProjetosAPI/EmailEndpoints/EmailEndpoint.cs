using ProjetosAPI.Models;
using System.Net;
using System.Net.Mail;

namespace ProjetosAPI.Endpoints;

public static class EmailEndpoints
{
    public static void MapEmailEndpoints(this WebApplication app)
    {
        app.MapPost("/projetos/email", (EmailDto emailDto) =>
        {
            try
            {
                // 🔐 Variáveis de ambiente
                var emailRemetente = Environment.GetEnvironmentVariable("EMAIL_USER");
                var senha = Environment.GetEnvironmentVariable("EMAIL_PASS");

                if (string.IsNullOrEmpty(emailRemetente) || string.IsNullOrEmpty(senha))
                {
                    return Results.BadRequest("Credenciais de email não configuradas");
                }

                // 📡 Configuração SMTP
                var smtp = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential(emailRemetente, senha),
                    EnableSsl = true
                };

                
                var mensagem = new MailMessage
                {
                    From = new MailAddress(emailRemetente),
                    Subject = emailDto.Assunto,
                    Body = $@"
                                Nome: {emailDto.Nome} {emailDto.Sobrenome}
                                Email: {emailDto.Email}

                                Mensagem:
                                {emailDto.Mensagem}
                                "
                };

                
                mensagem.To.Add(emailRemetente);

                
                mensagem.ReplyToList.Add(emailDto.Email);

               
                smtp.Send(mensagem);

                return Results.Ok("Email enviado com sucesso");
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        });
    }
}