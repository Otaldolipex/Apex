using Apex.Core.Requests.Account;
using Apex.Core.Responses;

namespace Apex.Core.Handlers;

public interface IAccountHandler
{
    Task<Response<string>> LoginAsync(LoginRequest request);
    Task<Response<string>> RegisterAsync(RegisterRequest request);
    Task LogoutAsync();
}