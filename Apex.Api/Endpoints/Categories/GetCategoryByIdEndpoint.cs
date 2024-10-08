using Apex.Api.Common.Api;
using Apex.Core.Handlers;
using Apex.Core.Models;
using Apex.Core.Requests.Categories;
using Apex.Core.Responses;

namespace Apex.Api.Endpoints.Categories;

public class GetCategoryByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
            .WithName("Categories: Get By Id")
            .WithSummary("Recupera uma categoria")
            .WithDescription("Recupera uma categoria")
            .WithOrder(4)
            .Produces<Response<Category?>>();
        
    private static async Task<IResult> HandleAsync(
        ICategoryHandler handler,
        long id)
    {
        var request = new GetCategoryByIdRequest()
        {
            UserId = "test@balta.io",
            Id = id
        };
        
        var result = await handler.GetByIdAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}