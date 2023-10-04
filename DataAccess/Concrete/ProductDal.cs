using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class ProductDal : IProductDal
    {

        public void Add(Product product)
        {
            using (DataContext context = new DataContext())
            {
                var addedEntity = context.Entry(product);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Product product)
        {
            using (DataContext context = new DataContext())
            {
                var deletedEntity = context.Entry(product);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Product Get(int productId)
        {
            using (DataContext context = new DataContext())
            {
                return context.Set<Product>().SingleOrDefault(p => p.ProductId == productId);

            }
        }

        public List<Product> GetList(Expression<Func<Product, bool>> filter = null)
        {
            using (DataContext context = new DataContext())
            {
                return filter == null ?
                context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();
            }
        }

    }
}