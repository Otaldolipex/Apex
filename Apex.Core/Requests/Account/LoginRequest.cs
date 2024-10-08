using System.ComponentModel.DataAnnotations;

namespace Apex.Core.Requests.Account;

public class LoginRequest : Request
{
    [Required(ErrorMessage = "E-mail")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Senha inválida")]
    public string Password { get; set; } = string.Empty;
}