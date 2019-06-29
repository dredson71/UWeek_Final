using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Repository;

namespace Service.Implementation
{
    public class IngredientService : IIngredientService
    {

        private readonly IIngredientRepository ingredientRepository;

        public IngredientService(IIngredientRepository ingredientRepository)
        {
            this.ingredientRepository = ingredientRepository;
        }

        public bool Delete(int id)
        {
            return ingredientRepository.Delete(id);
        }

        public Ingredient Get(int id)
        {
            return ingredientRepository.Get(id);
        }

        public IEnumerable<Ingredient> GetAll()
        {
            return ingredientRepository.GetAll();
        }

        public bool Save(Ingredient entity)
        {
            return ingredientRepository.Save(entity);
        }

        public bool Update(Ingredient entity)
        {
            return ingredientRepository.Update(entity);
        }
    }
}
