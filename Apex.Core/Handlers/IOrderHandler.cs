using Apex.Core.Models;
using Apex.Core.Requests.Orders;
using Apex.Core.Responses;

namespace Apex.Core.Handlers;

public interface IOrderHandler
{
    Task<Response<Order?>> CancelAsync(CancelOrderRequest request);
    Task<Response<Order?>> CreateAsync(CreateOrderRequest request);
    Task<Response<Order?>> PayAsync(PayOrderRequest request);
    Task<Response<Order?>> RefundAsync(RefundOrderRequest request);
    Task<PagedResponse<List<Order>?>> GetAllAsync(GetAllOrdersRequest request);
    Task<Response<Order?>> GetByNumberAsync(GetOrderByNumberRequest request);
}