using System.Security.Claims;
using Apex.Api.Common.Api;
using Apex.Core.Handlers;
using Apex.Core.Models;
using Apex.Core.Requests.Categories;
using Apex.Core.Responses;

namespace Apex.Api.Endpoints.Categories;

public class CreateCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsynk)
            .WithName("Categories: Create")
            .WithSummary("Cria uma nova categoria")
            .WithDescription("Cria uma nova categoria")
            .WithOrder(1)
            .Produces<Response<Category?>>();
            

    private static async Task<IResult> HandleAsynk(
        ClaimsPrincipal user,
        ICategoryHandler handler,
        CreateCategoryRequest request)
    {
        request.UserId = user.Identity?.Name ?? string.Empty;
        var result = await handler.CreateAsync(request);
        return result.IsSuccess 
            ? TypedResults.Created($"/{result.Data?.Id}", result) 
            : TypedResults.BadRequest(result.Data);
    }
}