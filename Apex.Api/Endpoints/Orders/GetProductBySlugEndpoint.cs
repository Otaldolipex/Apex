using Apex.Api.Common.Api;
using Apex.Core.Handlers;
using Apex.Core.Models;
using Apex.Core.Requests.Orders;
using Apex.Core.Responses;

namespace Apex.Api.Endpoints.Orders;

public class GetProductBySlugEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{slug}", HandleAsync)
            .WithName("Products: Get by Slug")
            .WithSummary("Recupera um produto")
            .WithDescription("Recupera um produto")
            .WithOrder(2)
            .Produces<Response<Product?>>();

    private static async Task<IResult> HandleAsync(
        IProductHandler handler,
        string slug)
    {
        var request = new GetProductBySlugRequest
        {
            Slug = slug
        };
        
        var result = await handler.GetBySlugAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}