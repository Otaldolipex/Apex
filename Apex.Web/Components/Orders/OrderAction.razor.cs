using Apex.Core.Handlers;
using Apex.Core.Models;
using Apex.Core.Requests.Orders;
using Apex.Web.Pages.Orders;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Apex.Web.Components.Orders;

public partial class OrderActionComponent : ComponentBase
{
    #region Parameters

    [CascadingParameter] 
    public DetailsPage Parent { get; set; } = null!;

    [Parameter, EditorRequired]
    public Order Order { get; set; } = null!;

    #endregion

    #region Services

    [Inject] public IDialogService DialogService { get; set; } = null!;
    [Inject] public IOrderHandler OrderHandler { get; set; } = null!;
    [Inject] public ISnackbar Snackbar { get; set; } = null!;
    
    #endregion

    #region Public Methods

    public async void OnCancelButtonClickedAsync()
    {
        var result = await DialogService.ShowMessageBox(
            "ATENÇÃO",
            "Deseja realmente cancelar este pedido?",
            yesText: "SIM", cancelText: "NÃO");

        if (result is not null && result == true)
            await CancelOrderAsync();
    }

    public async void OnPaymentButtonClickedAsync()
    {
        await PayOrderAsync();
    }
    
    public async void OnRefundButtonClickedAsync()
    {
        var result = await DialogService.ShowMessageBox(
            "ATENÇÃO",
            "Deseja realmente estornar este pedido?",
            yesText: "SIM", cancelText: "NÃO");

        if (result is not null && result == true)
            await RefundOrderAsync();
    }

    #endregion

    #region Private Methods

    private async Task CancelOrderAsync()
    {
        var request = new CancelOrderRequest
        {
            Id = Order.Id
        };
        
        var result = await OrderHandler.CancelAsync(request);
        if  (result.IsSuccess)
            Parent.RefreshState(result.Data!);
        else
            Snackbar.Add(result.Message, Severity.Error);
    }

    private async Task PayOrderAsync()
    {
        await Task.Delay(1);
        Snackbar.Add("Pagamento não implementado", Severity.Error);
    }
    
    private async Task RefundOrderAsync()
    {
        var request = new RefundOrderRequest()
        {
            Id = Order.Id
        };
        
        var result = await OrderHandler.RefundAsync(request);
        if  (result.IsSuccess)
            Parent.RefreshState(result.Data!);
        else
            Snackbar.Add(result.Message, Severity.Error);
    }

    #endregion
}