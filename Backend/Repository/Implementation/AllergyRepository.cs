using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using Repository.Context;
using Repository.ViewModel;

namespace Repository.Implementation
{
    public class AllergyRepository : IAllergyRepository
    {

        private readonly ApplicationDbContext Context;

        public AllergyRepository(ApplicationDbContext Context)
        {
            this.Context = Context;
        }

        public bool Delete(int id)
        {
            try
            {
                var allergy = Context.Allergies.Single(x => x.IngredientId == id);

                Context.Allergies.Remove(allergy);
                Context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public Allergy Get(int id)
        {
            var allergy = new Allergy();
            try
            {
                allergy = Context.Allergies.Single(x => x.IngredientId == id);
            }
            catch(System.Exception)
            {
                throw;
            }
            return allergy;
        }

        public IEnumerable<Allergy> GetAll()
        {
            var allergies = new List<Allergy>();
            try
            {
                allergies = Context.Allergies.ToList();
            }
            catch(System.Exception)
            {
                throw;
            }
            return allergies;
        }

        public bool Save(Allergy entity)
        {
            try
            {
                Context.Allergies.Add(entity);
                Context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(Allergy entity)
        {
            try
            {
                var allergy = Context.Allergies.Single(x => x.IngredientId == entity.IngredientId);

                allergy.IngredientId = entity.IngredientId;
                allergy.UserId = entity.UserId;


                Context.Allergies.Update(allergy);
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
