using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using Repository.Context;
using Repository.ViewModel;

namespace Repository.Implementation
{
    public class SuscriptionRepository : ISuscriptionRepository
    {

        private readonly ApplicationDbContext Context;

        public SuscriptionRepository(ApplicationDbContext Context)
        {
            this.Context = Context;
        }

        public bool Delete(int id)
        {
            try
            {
                var suscription = Context.Suscriptions.Single(x => x.Id == id);

                Context.Suscriptions.Remove(suscription);
                Context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public Suscription Get(int id)
        {
            var suscription = new Suscription();
            try
            {
                suscription = Context.Suscriptions.Single(x => x.Id == id);
            }
            catch(System.Exception)
            {
                throw;
            }
            return suscription;
        }

        public IEnumerable<Suscription> GetAll()
        {
            var suscriptions = new List<Suscription>();
            try
            {
                suscriptions = Context.Suscriptions.ToList();
            }
            catch(System.Exception)
            {
                throw;
            }
            return suscriptions;
        }

        public bool Save(Suscription entity)
        {
            try
            {
                Context.Suscriptions.Add(entity);
                Context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(Suscription entity)
        {
            try
            {
                var suscription = Context.Suscriptions.Single(x => x.Id == entity.Id);

                suscription.Qdays = entity.Qdays;
                 suscription.Qpeople = entity.Qpeople;
                  suscription.Subcost = entity.Subcost;
                   suscription.UserId = entity.UserId;

                Context.Suscriptions.Update(suscription);
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
