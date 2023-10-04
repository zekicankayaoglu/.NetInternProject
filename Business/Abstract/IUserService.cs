using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<User> GetByMail(string email);

        void Add(User user);
        void LogIn(User user);
        User GetCurrentUser();
        void LogOut(User user);
    }
}
