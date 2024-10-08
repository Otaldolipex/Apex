using Apex.Core.Handlers;
using Apex.Core.Models;
using Apex.Core.Requests.Orders;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Apex.Web.Pages.Products;

public partial class ListProductsPage : ComponentBase
{
    #region Properties
    
    public bool IsBusy { get; set; }
    public List<Product> Products { get; set; } = [];

    #endregion

    #region Services

    [Inject] public ISnackbar Snackbar { get; set; } = null!;
    
    [Inject] public IProductHandler Handler { get; set; } = null!;

    #endregion

    #region Overrides

        protected override async Task OnInitializedAsync()
        {
            IsBusy = true;
            try
            {
                var request = new GetAllProductsRequest();
                var result = await Handler.GetAllAsync(request);
                if (result.IsSuccess)
                    Products = result.Data ?? [];
                else
                    Snackbar.Add(result.Message, Severity.Error); 
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
            finally
            {
                IsBusy = false;
            }
        }

    #endregion
}