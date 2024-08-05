using ShopPRO.Modules.Domain.Entities;
using ShopPRO.Modules.Persistence.Context;

namespace ShopPRO.Modules.Persistence.Extentions
{
    public static class OrdersExtentions
    {
        public static void UpdateFromEntity(this Orders ordersToUpdate, Orders entity)
        {
            ordersToUpdate.orderdate = entity.orderdate;
            ordersToUpdate.requireddate = entity.requireddate;
            ordersToUpdate.shippeddate = entity.shippeddate;
            ordersToUpdate.freight = entity.freight;
            ordersToUpdate.shipname = entity.shipname;
            ordersToUpdate.shipaddress = entity.shipaddress;
            ordersToUpdate.shipcity = entity.shipcity;
            ordersToUpdate.shipregion = entity.shipregion;
            ordersToUpdate.shippostalcode = entity.shippostalcode;
            ordersToUpdate.shipcountry = entity.shipcountry;
        }

        public static Orders ValidateOrdersExists(this ShopContext context, int orderid)
        {
            var orders = context.Orders.Find(orderid);
            return orders;
        }
    }
}
