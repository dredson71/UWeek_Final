using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Repository;

namespace Service.Implementation
{
    public class AllergyService : IAllergyService
    {

        private readonly IAllergyRepository allergyRepository;

        public AllergyService(IAllergyRepository allergyRepository)
        {
            this.allergyRepository = allergyRepository;
        }

        public bool Delete(int id)
        {
            return allergyRepository.Delete(id);
        }

        public Allergy Get(int id)
        {
            return allergyRepository.Get(id);
        }

        public IEnumerable<Allergy> GetAll()
        {
            return allergyRepository.GetAll();
        }

        public bool Save(Allergy entity)
        {
            return allergyRepository.Save(entity);
        }

        public bool Update(Allergy entity)
        {
            return allergyRepository.Update(entity);
        }
    }
}
