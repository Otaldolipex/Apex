using System.Security.Claims;
using Apex.Api.Common.Api;
using Apex.Core.Handlers;
using Apex.Core.Requests.Transactions;
using Apex.Core.Models;
using Apex.Core.Responses;

namespace Apex.Api.Endpoints.Transactions;

public class GetTransactionByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
            .WithName("Transactions: Get By Id")
            .WithSummary("Recupera uma transação")
            .WithDescription("Recupera uma transação")
            .WithOrder(4)
            .Produces<Response<Transaction?>>();
    
    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        ITransactionHandler handler,
        long id)
    {
        var request = new GetTransactionByIdRequest
        {
            UserId = user.Identity?.Name ?? string.Empty,
            Id = id
        };
        var result = await handler.GetByIdAsync(request);
        return result.IsSuccess
            ? TypedResults.Created($"/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result.Data);
    }
}