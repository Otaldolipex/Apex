using Apex.Core.Enums;
using Microsoft.AspNetCore.Components;

namespace Apex.Web.Components.Orders;

public partial class OrderStatusComponent : ComponentBase
{
    #region Parameters

    [Parameter, EditorRequired]
    public EOrderStatus Status {get; set; }

    #endregion
}