using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using Repository.Context;
using Repository.ViewModel;

namespace Repository.Implementation
{
    public class DishRepository : IDishRepository
    {

        private readonly ApplicationDbContext Context;

        public DishRepository(ApplicationDbContext Context)
        {
            this.Context = Context;
        }

        public bool Delete(int id)
        {
            try
            {
                var dish = Context.Dishes.Single(x => x.Id == id);

                Context.Dishes.Remove(dish);
                Context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public Dish Get(int id)
        {
            var dish = new Dish();
            try
            {
                dish = Context.Dishes.Single(x => x.Id == id);
            }
            catch(System.Exception)
            {
                throw;
            }
            return dish;
        }

        public IEnumerable<Dish> GetAll()
        {
            var dishes = new List<Dish>();
            try
            {
                dishes = Context.Dishes.ToList();
            }
            catch(System.Exception)
            {
                throw;
            }
            return dishes;
        }

        public bool Save(Dish entity)
        {
            try
            {
                Context.Dishes.Add(entity);
                Context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(Dish entity)
        {
            try
            {
                var dish = Context.Dishes.Single(x => x.Id == entity.Id);

                dish.Name = entity.Name;
                dish.Recipe = entity.Recipe;
                dish.Description = entity.Description;


                Context.Dishes.Update(dish);
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
