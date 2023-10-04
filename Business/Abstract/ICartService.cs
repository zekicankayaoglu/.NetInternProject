using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICartService
    {
        void add(Cart cart);
        void delete(Cart cart);
        void update(Cart cart);
        void ClearCart(List<Cart> carts);
        List<Cart> getUserCart(int userId);
        Cart getCartByUserID(int userId, int productId);
    }
}
