using Repositories;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MentorService
    {
        private MentorRepository _repository;

        public MentorService(MentorRepository repository)
        {
            _repository = repository;
        }

        public void CreateMentor(Mentor mentor)
        {
            this._repository.CreateAsync(mentor).Wait();
        }

        public void DeleteMentor(Mentor mentor)
        {
            this._repository.RemoveAsync(mentor).Wait();
        }

        public IQueryable GetAll()
        {
            return this._repository.Get();
        }

        public void UpdateMentor(Mentor mentor)
        {
            this._repository.UpdateAsync(mentor).Wait();
        }
    }
}
