using System.Security.Claims;
using Apex.Api.Common.Api;
using Apex.Core.Handlers;
using Apex.Core.Models;
using Apex.Core.Requests.Orders;
using Apex.Core.Responses;

namespace Apex.Api.Endpoints.Orders;

public class RefundOrderEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/{id}/refund", HandleAsync)
            .WithName("Orders: Refund an order")
            .WithSummary("Estorna um pedido")
            .WithDescription("Estorna um pedido")
            .WithOrder(6)
            .Produces<Response<Order?>>();

    private static async Task<IResult> HandleAsync(
        IOrderHandler handler,
        long id,
        ClaimsPrincipal user)
    {
        var request = new RefundOrderRequest
        {
            Id = id,
            UserId = user.Identity!.Name ?? string.Empty
        };
        
        var result = await handler.RefundAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}