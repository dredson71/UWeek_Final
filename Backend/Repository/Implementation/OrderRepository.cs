using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using Repository.Context;

namespace Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {

        private readonly ApplicationDbContext Context;

        public OrderRepository(ApplicationDbContext Context)
        {
            this.Context = Context;
        }

        public bool Delete(int id)
        {
            try
            {
                var order = Context.Orders.Single(x => x.DishId == id);

                Context.Remove(order);
                Context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public Order Get(int id)
        {
            var order = new Order();
            try
            {
                order = Context.Orders.Single(x => x.DishId == id);
            }
            catch (System.Exception)
            {
                throw;
            }
            return order;
        }

        public IEnumerable<Order> GetAll()
        {
            var orders = new List<Order>();
            try
            {
                orders = Context.Orders.ToList();
            }
            catch (System.Exception)
            {
                throw;
            }
            return orders;
        }

        public bool Save(Order entity)
        {
            try
            {
                Context.Add(entity);
                Context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(Order entity)
        {
            try
            {
                var order = Context.Orders.Single(x => x.DishId == entity.DishId);

                order.DishId = entity.DishId;
                order.SuscriptionId = entity.SuscriptionId;

                Context.Update(order);
                Context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }
    }
}
