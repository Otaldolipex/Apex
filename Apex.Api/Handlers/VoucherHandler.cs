using Apex.Api.Data;
using Apex.Core.Handlers;
using Apex.Core.Models;
using Apex.Core.Requests.Orders;
using Apex.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace Apex.Api.Handlers;

public class VoucherHandler(AppDbContext context) : IVoucherHandler
{
    public async Task<Response<Voucher?>> GetByNumberAsync(GetVoucherByNumberRequest request)
    {
        try
        {
            var voucher = await context
                .Vouchers
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Number == request.Number && x.IsActive == true);
            
            return voucher is null
                ? new Response<Voucher?>(null, 404, "Voucher não encontrado")
                : new Response<Voucher?>(voucher);
        }
        
        catch
        {
            return new Response<Voucher?>(null, 500, "Não foi possível recuperar seu voucher");
        }
    }
}