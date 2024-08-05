using ShopPRO.Modules.Application.Core;
using ShopPRO.Modules.Application.Dtos.Scores;

namespace ShopPRO.Modules.Application.Interfaces
{
    public interface IScoresService
    {
        ServiceResult GetScores();
        ServiceResult GetScore(string id);
        ServiceResult UpdateScores(ScoresUpdateDto scoresUpdate);
        ServiceResult RemoveScores(ScoresRemoveDto scoresRemove);
        ServiceResult SaveScores(ScoresSaveDto scoresSave);
    }
}
