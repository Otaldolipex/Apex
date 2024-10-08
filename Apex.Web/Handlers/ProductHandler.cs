using System.Net.Http.Json;
using Apex.Core.Handlers;
using Apex.Core.Models;
using Apex.Core.Requests.Orders;
using Apex.Core.Responses;

namespace Apex.Web.Handlers;

public class ProductHandler(IHttpClientFactory httpClientFactory) : IProductHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);

    public async Task<PagedResponse<List<Product>?>> GetAllAsync(GetAllProductsRequest request)
        => await _client.GetFromJsonAsync<PagedResponse<List<Product>?>>("v1/products") 
           ?? new PagedResponse<List<Product>?>(null, 400, "Não foi possível obter os produtos");

    public async Task<Response<Product?>> GetBySlugAsync(GetProductBySlugRequest request)
        => await _client.GetFromJsonAsync<Response<Product?>>($"v1/products/{request.Slug}")
           ?? new Response<Product?>(null, 400, "Não foi possível obter os produto");
}