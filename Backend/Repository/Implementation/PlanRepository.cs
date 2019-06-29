using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using Repository.Context;
using Repository.ViewModel;

namespace Repository.Implementation
{
    public class PlanRepository : IPlanRepository
    {

        private readonly ApplicationDbContext Context;

        public PlanRepository(ApplicationDbContext Context)
        {
            this.Context = Context;
        }

        public bool Delete(int id)
        {
            try
            {
                var plan = Context.Plans.Single(x => x.Id == id);

                Context.Plans.Remove(plan);
                Context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public Plan Get(int id)
        {
            var plan = new Plan();
            try
            {
                plan = Context.Plans.Single(x => x.Id == id);
            }
            catch(System.Exception)
            {
                throw;
            }
            return plan;
        }

        public IEnumerable<Plan> GetAll()
        {
            var plans = new List<Plan>();
            try
            {
                plans = Context.Plans.ToList();
            }
            catch(System.Exception)
            {
                throw;
            }
            return plans;
        }

        public bool Save(Plan entity)
        {
            try
            {
                Context.Plans.Add(entity);
                Context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(Plan entity)
        {
            try
            {
                var plan = Context.Plans.Single(x => x.Id == entity.Id);

                plan.Name = entity.Name;

                Context.Plans.Update(plan);
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
