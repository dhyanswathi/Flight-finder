using Flight_Finder.Api.DTO;

namespace Flight_Finder.Api.Models
{
    public interface IUserRepository
    {
        User? GetUserById(string id);
        IEnumerable<User> GetAllUsers();
        User Register(UserRegister registerUser);
        void DeleteUser(string id);
        void UpdateUser (string id, UserRegister updateUser);
        void SaveUser();
    }
}
