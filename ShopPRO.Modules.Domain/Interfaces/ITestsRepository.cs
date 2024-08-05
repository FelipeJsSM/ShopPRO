using ShopPRO.Common.Data.Repository;

namespace ShopPRO.Modules.Domain.Interfaces
{
    public interface ITestsRepository : IBaseRepository<Entities.Tests, string>
    {
        List<Modules.Domain.Entities.Tests> getOrdersById(string id);
    }
}
