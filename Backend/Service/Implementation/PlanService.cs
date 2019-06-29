using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Repository;

namespace Service.Implementation
{
    public class PlanService : IPlanService
    {

        private readonly IPlanRepository planRepository;

        public PlanService(IPlanRepository planRepository)
        {
            this.planRepository = planRepository;
        }

        public bool Delete(int id)
        {
            return planRepository.Delete(id);
        }

        public Plan Get(int id)
        {
            return planRepository.Get(id);
        }

        public IEnumerable<Plan> GetAll()
        {
            return planRepository.GetAll();
        }

        public bool Save(Plan entity)
        {
            return planRepository.Save(entity);
        }

        public bool Update(Plan entity)
        {
            return planRepository.Update(entity);
        }
    }
}
