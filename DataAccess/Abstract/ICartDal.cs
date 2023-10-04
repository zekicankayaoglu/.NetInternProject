using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICartDal
    {
        List<Cart> getUserCart(int userId);
        void add(Cart cart);
        void delete(Cart cart);
        void update(Cart cart);
        Cart GetCartByUserID(int userId, int productId);
        void ClearCart(List<Cart> carts);
    }
}
