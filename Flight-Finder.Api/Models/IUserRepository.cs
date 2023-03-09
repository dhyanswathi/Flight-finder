using Flight_Finder.Api.DTO;

namespace Flight_Finder.Api.Models
{
    public interface IUserRepository
    {
        User GetById(string id);
        IEnumerable<User> GetAll();
        void Register (UserRegister user);
        void Delete(string id);
        void Update (UserRegister user);
    }
}
