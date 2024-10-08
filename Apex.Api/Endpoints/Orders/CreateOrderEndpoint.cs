using System.Security.Claims;
using Apex.Api.Common.Api;
using Apex.Core.Handlers;
using Apex.Core.Models;
using Apex.Core.Requests.Orders;
using Apex.Core.Responses;

namespace Apex.Api.Endpoints.Orders;

public class CreateOrderEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Orders: Create a new order")
            .WithSummary("Cria um novo pedido")
            .WithDescription("Cria um novo pedido")
            .WithOrder(1)
            .Produces<Response<Order?>>();
            

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IOrderHandler handler,
        CreateOrderRequest request)
    {
        request.UserId = user.Identity!.Name ?? string.Empty;

        var result = await handler.CreateAsync(request);
        return result.IsSuccess
            ? TypedResults.Created($"v1/orders/{result.Data?.Number}", result)
            : TypedResults.BadRequest(result);
    }
}