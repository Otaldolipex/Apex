namespace Apex.Core.Models;

//https://apex.com/premium?voucher=ABCD-1234

public class Voucher
{
    public long Id { get; set; } // Id -> Chave primária
    public string Number { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsActive { get; set; } // Uma vez usado -> IsActive = false
    public decimal Amount { get; set; }
}