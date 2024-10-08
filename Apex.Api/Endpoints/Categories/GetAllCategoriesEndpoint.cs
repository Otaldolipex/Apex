using System.Security.Claims;
using Apex.Api.Common.Api;
using Apex.Core;
using Apex.Core.Handlers;
using Apex.Core.Models;
using Apex.Core.Requests.Categories;
using Apex.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Apex.Api.Endpoints.Categories;

public class GetAllCategoriesEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
            .WithName("Categories: Get All")
            .WithSummary("Recupera todas as categoria")
            .WithDescription("Recupera todas as categoria")
            .WithOrder(5)
            .Produces<PagedResponse<List<Category>?>>();
        
    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        ICategoryHandler handler,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetAllCategoriesRequest
        {
            UserId = user.Identity?.Name ?? string.Empty,
            PageNumber = pageNumber,
            PageSize = pageSize,
        };
        
        var result = await handler.GetAllAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}