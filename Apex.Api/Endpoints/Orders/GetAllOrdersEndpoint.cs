using System.Security.Claims;
using Apex.Api.Common.Api;
using Apex.Core;
using Apex.Core.Handlers;
using Apex.Core.Models;
using Apex.Core.Requests.Orders;
using Apex.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Apex.Api.Endpoints.Orders;

public class GetAllOrdersEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
            .WithName("Orders: Get All")
            .WithSummary("Recupera todos os pedidos")
            .WithDescription("Recupera todos os pedidos")
            .WithOrder(5)
            .Produces<PagedResponse<List<Order>?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IOrderHandler handler,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetAllOrdersRequest
        {
            UserId = user.Identity!.Name ?? string.Empty,
            PageNumber = pageNumber,
            PageSize = pageSize
        };

        var result = await handler.GetAllAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}