using ShopPRO.Modules.Application.Core;
using ShopPRO.Modules.Application.Dtos.Orders;

namespace ShopPRO.Modules.Application.Interfaces
{
    public interface IOrdersService
    {
        ServiceResult GetOrders();
        ServiceResult GetOrder(int id);
        ServiceResult UpdateOrders(OrdersUpdateDto ordersUpdate);
        ServiceResult RemoveOrders(OrdersRemoveDto ordersRemove);
        ServiceResult SaveOrders(OrdersSaveDto ordersSave);
    }
}
