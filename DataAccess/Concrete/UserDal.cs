using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class UserDal : IUserDal
    {
        

        
        public void Add(User user)
        {
            using (DataContext context = new DataContext())
            {
                var addedEntity = context.Entry(user);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public async Task<User> GetByMail(string email)
        {
            using (DataContext context = new DataContext())
            {
                return await context.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
            }
        }
        public void LogIn(User user)
        {
            using(DataContext context = new DataContext())
            {
                var updatedEntry = context.Entry(user);
                updatedEntry.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public User GetCurrentUser()
        {
            using (DataContext context = new DataContext())
            {
                return context.Set<User>().SingleOrDefault(p => p.Status == true);
            }
        }
        
        public void LogOut(User user) { 
            using(DataContext context = new DataContext()) {
                var updatedEntry = context.Entry(user);
                updatedEntry.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
