using ShopPRO.Common.Data.Repository;

namespace ShopPRO.Modules.Domain.Interfaces
{
    public interface IOrdersRepository : IBaseRepository<Entities.Orders, int>
    {
        List<Modules.Domain.Entities.Orders> getOrdersById(int id);
    }
}
