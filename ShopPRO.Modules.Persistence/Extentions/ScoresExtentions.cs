using ShopPRO.Modules.Domain.Entities;
using ShopPRO.Modules.Persistence.Context;
using static System.Formats.Asn1.AsnWriter;

namespace ShopPRO.Modules.Persistence.Extentions
{
    public static class ScoresExtentions
    {
        public static void UpdateFromEntity(this Scores scoresToUpdate, Scores entity)
        {
            scoresToUpdate.score = entity.score;
        }

        public static Scores ValidateScoresExists(this ShopContext context, string studentid)
        {
            var scores = context.Scores.Find(studentid);
            return scores;
        }
    }
}
