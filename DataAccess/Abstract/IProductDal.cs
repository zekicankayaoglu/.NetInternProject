using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal
    {
        List<Product> GetList(Expression<Func<Product, bool>> filter = null);
        Product Get(int productId);
        void Add(Product product);
        void Delete(Product product);
    }
}
