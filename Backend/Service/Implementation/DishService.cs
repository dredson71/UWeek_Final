using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Repository;

namespace Service.Implementation
{
    public class DishService : IDishService
    {

        private readonly IDishRepository dishRepository;

        public DishService(IDishRepository dishRepository)
        {
            this.dishRepository = dishRepository;
        }

        public bool Delete(int id)
        {
            return dishRepository.Delete(id);
        }

        public Dish Get(int id)
        {
            return dishRepository.Get(id);
        }

        public IEnumerable<Dish> GetAll()
        {
            return dishRepository.GetAll();
        }

        public bool Save(Dish entity)
        {
            return dishRepository.Save(entity);
        }

        public bool Update(Dish entity)
        {
            return dishRepository.Update(entity);
        }
    }
}
