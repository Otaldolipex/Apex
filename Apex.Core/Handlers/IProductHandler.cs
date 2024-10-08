using Apex.Core.Models;
using Apex.Core.Requests.Orders;
using Apex.Core.Responses;

namespace Apex.Core.Handlers;

public interface IProductHandler
{
    Task<PagedResponse<List<Product>?>> GetAllAsync(GetAllProductsRequest request);
    Task<Response<Product?>> GetBySlugAsync(GetProductBySlugRequest request);
}