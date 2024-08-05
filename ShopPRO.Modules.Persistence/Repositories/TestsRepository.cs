using ShopPRO.Modules.Domain.Entities;
using ShopPRO.Modules.Domain.Interfaces;
using ShopPRO.Modules.Persistence.Context;
using ShopPRO.Modules.Persistence.Exceptions;
using ShopPRO.Modules.Persistence.Extentions;
using System.Linq;
using System.Linq.Expressions;
namespace ShopPRO.Modules.Persistence.Repositories
{
    public class TestsRepository : ITestsRepository
    {
        private readonly ShopContext _shopContext;

        public TestsRepository(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public bool Exists(Expression<Func<Tests, bool>> filter)
        {
            return _shopContext.Tests.Any(filter);
        }

        public List<Tests> GetAll()
        {
            return _shopContext.Tests.ToList();
        }

        public Tests GetEntityByID(string Id)
        {
            var tests = _shopContext.ValidateTestsExists(Id);

            if (tests == null)
            {
                throw new TestsRepositoryException($"ID no encontrado, {Id}");
            }

            return tests;
        }

        public List<Tests> getOrdersById(string testid)
        {
            var tests = _shopContext.ValidateTestsExists(testid);

            if (tests is null)
            {
                throw new TestsRepositoryException($"No se pudo encontrar el test con el id{testid}");
            }
            var testsList = new List<Tests> { tests };

            return testsList;
        }

        public void Remove(Tests entity)
        {
            var existingTests = _shopContext.ValidateTestsExists(entity.Id);

            if (existingTests != null)
            {
                _shopContext.Tests.Remove(existingTests);
                _shopContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("El Test no existe.");
            }
        }

        public void Save(Tests entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");
                }

                _shopContext.Tests.Add(entity);
                _shopContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new TestsRepositoryException("Error al guardar el test.");
            }
        }

        public void Update(Tests entity)
        {
            throw new NotImplementedException();
        }
    }
}
