using Flight_Finder.Api.DTO;

namespace Flight_Finder.Api.Models
{
    public interface IUserRepository
    {
        User? GetById(string id);
        IEnumerable<User> GetAll();
        User Register (UserRegister registerUser);
        void Delete(string id);
        void Update (string id, UserRegister updateUser);
        void Save();
    }
}
