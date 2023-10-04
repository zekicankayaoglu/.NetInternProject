using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal
    {
        void Add(User user);
        Task<User> GetByMail(string email);
        void LogIn(User user);
        User GetCurrentUser();
        void LogOut(User user);
    }
}
