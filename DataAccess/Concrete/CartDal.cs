using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class CartDal : ICartDal
    {

        public void add(Cart cart)
        {
            using (DataContext context = new DataContext())
            {
                var addedEntity = context.Entry(cart);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void delete(Cart cart)
        {
            using (DataContext context = new DataContext())
            {
                var deletedEntity = context.Entry(cart);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Cart> getUserCart(int userId)
        {
            using (DataContext context = new DataContext())
            {
                return context.Set<Cart>().Where(p => p.UserID == userId).ToList();
            }
        }

        public Cart GetCartByUserID(int userId, int productId)
        {
            using (DataContext context = new DataContext())
            {
                return context.Set<Cart>().SingleOrDefault(p => p.UserID == userId && p.ProductID == productId);
            }
        }
        public void update(Cart cart)
        {
            using (DataContext context = new DataContext())
            {
                var updatedEntity = context.Entry(cart);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void ClearCart(List<Cart> carts)
        {
            using(DataContext context = new DataContext())
            {
                foreach(var cart in carts)
                {
                    var deletedEntity = context.Entry(cart);
                    deletedEntity.State = EntityState.Deleted;
                    context.SaveChanges();
                }
            }
        }
    }
}