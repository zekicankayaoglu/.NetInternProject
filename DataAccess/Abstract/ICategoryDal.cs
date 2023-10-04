
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICategoryDal 
    {
        List<Category> GetList(Expression<Func<Category, bool>> filter = null);
        Category Get(Expression<Func<Category, bool>> filter);
        void Add(Category category);
        void Delete(Category category);
    }
}
