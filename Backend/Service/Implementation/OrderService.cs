using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Repository;

namespace Service.Implementation
{
    public class OrderService : IOrderService   
    {

        private readonly IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public bool Delete(int id)
        {
            return orderRepository.Delete(id);
        }

        public Order Get(int id)
        {
            return orderRepository.Get(id);
        }

        public IEnumerable<Order> GetAll()
        {
            return orderRepository.GetAll();
        }

        public bool Save(Order entity)
        {
            return orderRepository.Save(entity);
        }

        public bool Update(Order entity)
        {
            return orderRepository.Update(entity);
        }
    }
}
