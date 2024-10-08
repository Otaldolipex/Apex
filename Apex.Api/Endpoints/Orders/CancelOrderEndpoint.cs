using System.Security.Claims;
using Apex.Api.Common.Api;
using Apex.Core.Handlers;
using Apex.Core.Models;
using Apex.Core.Requests.Orders;
using Apex.Core.Responses;

namespace Apex.Api.Endpoints.Orders;

public class CancelOrderEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/{id}/cancel", HandleAsync)
            .WithName("Orders: Cancel order")
            .WithSummary("Cancela um pedido")
            .WithDescription("Cancela um pedido")
            .WithOrder(2)
            .Produces<Response<Order?>>();
    
    private static async Task<IResult> HandleAsync(
        IOrderHandler handler,
        long id,
        ClaimsPrincipal user)
    {
        var request = new CancelOrderRequest
        {
            Id = id,
            UserId = user.Identity!.Name ?? string.Empty
        };

        var result = await handler.CancelAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}