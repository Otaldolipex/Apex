using System.Security.Claims;
using Apex.Api.Common.Api;
using Apex.Core.Handlers;
using Apex.Core.Models;
using Apex.Core.Requests.Transactions;
using Apex.Core.Responses;

namespace Apex.Api.Endpoints.Transactions;

public class DeleteTransactionEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id}", HandleAsync)
            .WithName("Transactions: Delete")
            .WithSummary("Exclui uma transação")
            .WithDescription("Exclui uma transação")
            .WithOrder(3)
            .Produces<Response<Transaction?>>();
    
    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        ITransactionHandler handler,
        long id)
    {
        var request = new DeleteTransactionRequest
        {
            UserId = user.Identity?.Name ?? string.Empty,
            Id = id
        };
        var result = await handler.DeleteAsync(request);
        return result.IsSuccess
            ? TypedResults.Created($"/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result.Data);
    }
}