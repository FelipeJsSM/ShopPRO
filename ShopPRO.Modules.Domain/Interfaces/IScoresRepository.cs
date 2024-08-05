using ShopPRO.Common.Data.Repository;

namespace ShopPRO.Modules.Domain.Interfaces
{
    public interface IScoresRepository : IBaseRepository<Entities.Scores, string>
    {
        List<Modules.Domain.Entities.Scores> getScoresById(string id);
    }
}
