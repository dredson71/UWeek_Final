using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Repository;

namespace Service.Implementation
{
    public class SuscriptionService : ISuscriptionService
    {

        private readonly ISuscriptionRepository suscriptionRepository;

        public SuscriptionService(ISuscriptionRepository suscriptionRepository)
        {
            this.suscriptionRepository = suscriptionRepository;
        }

        public bool Delete(int id)
        {
            return suscriptionRepository.Delete(id);
        }

        public Suscription Get(int id)
        {
            return suscriptionRepository.Get(id);
        }

        public IEnumerable<Suscription> GetAll()
        {
            return suscriptionRepository.GetAll();
        }

        public bool Save(Suscription entity)
        {
            return suscriptionRepository.Save(entity);
        }

        public bool Update(Suscription entity)
        {
            return suscriptionRepository.Update(entity);
        }
    }
}
