using ShopPRO.Modules.Domain.Entities;
using ShopPRO.Modules.Domain.Interfaces;
using ShopPRO.Modules.Persistence.Context;
using ShopPRO.Modules.Persistence.Exceptions;
using ShopPRO.Modules.Persistence.Extentions;
using System.Linq;
using System.Linq.Expressions;

namespace ShopPRO.Modules.Persistence.Repositories
{
    public class ScoresRepository : IScoresRepository
    {
        private readonly ShopContext _shopContext;

        public ScoresRepository(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public bool Exists(Expression<Func<Scores, bool>> filter)
        {
            return _shopContext.Scores.Any(filter);
        }

        public List<Scores> GetAll()
        {
            return _shopContext.Scores.ToList();
        }

        public Scores GetEntityByID(string Id)
        {
            var scores = _shopContext.ValidateScoresExists(Id);

            if (scores == null)
            {
                throw new ScoresRepositoryException($"ID no encontrado, {Id}");
            }

            return scores;
        }

        public List<Scores> getScoresById(string studentid)
        {
            var scores = _shopContext.ValidateScoresExists(studentid);

            if (scores is null)
            {
                throw new ScoresRepositoryException($"No se pudo encontrar el score con el id{studentid}");
            }
            var scoresList = new List<Scores> { scores };

            return scoresList;
        }

        public void Remove(Scores entity)
        {
            var existingScores = _shopContext.ValidateScoresExists(entity.Id);

            if (existingScores != null)
            {
                _shopContext.Scores.Remove(existingScores);
                _shopContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("El Score no existe.");
            }
        }

        public void Save(Scores entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");
                }

                _shopContext.Scores.Add(entity);
                _shopContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new OrdersRepositoryException("Error al guardar el score.");
            }
        }

        public void Update(Scores entity)
        {
            try
            {
                Scores scoresToUpdate = GetEntityByID(entity.Id);

                if (scoresToUpdate != null)
                {
                    scoresToUpdate.UpdateFromEntity(entity);
                    _shopContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");
                }
            }
            catch (Exception)
            {
                throw new OrdersRepositoryException("Error al actualizar el score.");
            }
        }
    }
}
