using ShopPRO.Modules.Domain.Entities;
using ShopPRO.Modules.Domain.Interfaces;
using ShopPRO.Modules.Persistence.Context;
using ShopPRO.Modules.Persistence.Exceptions;
using ShopPRO.Modules.Persistence.Extentions;
using System.Linq.Expressions;

namespace ShopPRO.Modules.Persistence.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly ShopContext _shopContext;

        public OrdersRepository(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public bool Exists(Expression<Func<Orders, bool>> filter)
        {
            return _shopContext.Orders.Any(filter);
        }

        public List<Orders> GetAll()
        {
            return _shopContext.Orders.ToList();
        }

        public Orders GetEntityByID(int Id)
        {
            var orders = _shopContext.ValidateOrdersExists(Id);

            if (orders == null)
            {
                throw new OrdersRepositoryException($"ID no encontrado, {Id}");
            }

            return orders;
        }

        public List<Orders> getOrdersById(int orderid)
        {
            var orders = _shopContext.ValidateOrdersExists(orderid);

            if (orders is null)
            {
                throw new OrdersRepositoryException($"No se pudo encontrar la orden con el id{orderid}");
            }
            var ordersList = new List<Orders> { orders };

            return ordersList;
        }

        public void Remove(Orders entity)
        {
            var existingOrders = _shopContext.ValidateOrdersExists(entity.Id);

            if (existingOrders != null)
            {
                _shopContext.Orders.Remove(existingOrders);
                _shopContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("La orden no existe.");
            }
        }

        public void Save(Orders entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");
                }

                _shopContext.Orders.Add(entity);
                _shopContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new OrdersRepositoryException("Error al guardar el empleado.");
            }
        }

        public void Update(Orders entity)
        {
            try
            {
                Orders ordersToUpdate = GetEntityByID(entity.Id);

                if (ordersToUpdate != null)
                {
                    ordersToUpdate.UpdateFromEntity(entity);
                    _shopContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");
                }
            }
            catch (Exception)
            {
                throw new OrdersRepositoryException("Error al actualizar la orden.");
            }
        }
    }
}
