using Apex.Core.Models;
using Apex.Core.Requests.Orders;
using Apex.Core.Responses;

namespace Apex.Core.Handlers;

public interface IVoucherHandler
{
    Task<Response<Voucher?>> GetByNumberAsync(GetVoucherByNumberRequest request);
}