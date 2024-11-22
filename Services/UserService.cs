using Repositories;
using Repositories.Entities;

namespace Services
{
    public class UserService
    {
        private UserRepository _repository;

        public UserService(UserRepository repository)
        {
            _repository = repository;
        }

        public User CheckLogin(string username, string password)
        {
            return this._repository.Get().SingleOrDefault(x => x.UserName == username && x.Password == password);
        }
    }
}
