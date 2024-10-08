using Apex.Api.Common.Api;
using Apex.Core;
using Apex.Core.Handlers;
using Apex.Core.Models;
using Apex.Core.Requests.Orders;
using Apex.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Apex.Api.Endpoints.Orders;

public class GetAllProductsEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
            .WithName("Products: Get All")
            .WithSummary("Recupera todos os produtos")
            .WithDescription("Recupera todos os produtos")
            .WithOrder(1)
            .Produces<PagedResponse<List<Product>>>();

    private static async Task<IResult> HandleAsync(
        IProductHandler handler,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetAllProductsRequest
        {
            PageNumber = pageNumber,
            PageSize = pageSize
        };
        
        var result = await handler.GetAllAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}