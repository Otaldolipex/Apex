using System.Security.Claims;
using Apex.Api.Common.Api;
using Apex.Core.Handlers;
using Apex.Core.Models;
using Apex.Core.Requests.Orders;
using Apex.Core.Responses;

namespace Apex.Api.Endpoints.Orders;

public class PayOrderEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/{id}/pay", HandleAsync)
            .WithName("Orders: Pay an order")
            .WithSummary("Paga um pedido")
            .WithDescription("Paga um pedido")
            .WithOrder(3)
            .Produces<Response<Order?>>();

    private static async Task<IResult> HandleAsync(
        IOrderHandler handler,
        long id,
        PayOrderRequest request,
        ClaimsPrincipal user)
    {
        request.Id = id;
        request.UserId = user.Identity!.Name ?? string.Empty;
        
        var result = await handler.PayAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}