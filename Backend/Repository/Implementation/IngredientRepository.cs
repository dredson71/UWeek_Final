using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using Repository.Context;

namespace Repository.Implementation
{
    public class IngredientRepository : IIngredientRepository
    {

        private readonly ApplicationDbContext Context;

        public IngredientRepository(ApplicationDbContext Context)
        {
            this.Context = Context;
        }

        public bool Delete(int id)
        {
            try
            {
                var ingredient = Context.Ingredients.Single(x => x.Id == id);

                Context.Remove(ingredient);
                Context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public Ingredient Get(int id)
        {
            var ingredient = new Ingredient();
            try
            {
                ingredient = Context.Ingredients.Single(x => x.Id == id);
            }
            catch (System.Exception)
            {
                throw;
            }
            return ingredient;
        }

        public IEnumerable<Ingredient> GetAll()
        {
            var ingredients = new List<Ingredient>();
            try
            {
                ingredients = Context.Ingredients.ToList();
            }
            catch (System.Exception)
            {
                throw;
            }
            return ingredients;
        }

        public bool Save(Ingredient entity)
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

        public bool Update(Ingredient entity)
        {
            try
            {
                var ingredient = Context.Ingredients.Single(x => x.Id == entity.Id);

                ingredient.Name = entity.Name;
                ingredient.Description = entity.Description;

                Context.Update(ingredient);
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
