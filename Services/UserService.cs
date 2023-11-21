using WebCode.Database;
using WebCode.Entities;

namespace WebCode.Services
{
    public class UserService : IUserService
    {
        private readonly MyContext _context;

        public UserService(MyContext context)
        {
            _context = context;
        }

        public void CreateUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public User ValidteUser(string email, string password)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email && u.Password == password);
        }
        public void EditUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }

    public interface IUserService
    {
    }
}
