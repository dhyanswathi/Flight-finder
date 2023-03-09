using Flight_Finder.Api.DTO;

namespace Flight_Finder.Api.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly FlightFinderDBContext _context;
        public UserRepository(FlightFinderDBContext context) => _context = context;

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User? GetById(string id)
        {
            return _context.Users.FirstOrDefault(x => x.UserId == id);
        }

        public User Register(UserRegister registerUser)
        {
            var user = new User
            {
                UserId = Guid.NewGuid().ToString(),
                FirstName = registerUser.FirstName,
                LastName = registerUser.LastName,
                Email = registerUser.Email,
                Password = registerUser.Password
            };

            _context.Users.Add(user);
            Save();

            return user;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var user = GetById(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                Save();
            }
        }

        public void Update(string id, UserRegister updateUser)
        {
            var user = GetById(id);
           
            user.FirstName = updateUser.FirstName;
            user.LastName = updateUser.LastName;
            user.Email = updateUser.Email;
            user.Password = updateUser.Password;

            _context.Users.Update(user);
            Save();
        }
    }
}
