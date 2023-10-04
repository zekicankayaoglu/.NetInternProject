using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CartManager : ICartService
    {
        private ICartDal _cartDal;
        public CartManager(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }
        public void add(Cart cart)
        {
            _cartDal.add(cart);
        }

        public void delete(Cart cart)
        {
            _cartDal.delete(cart);
        }

        public List<Cart> getUserCart(int userId)
        {
            return _cartDal.getUserCart(userId);
        }

        public Cart getCartByUserID(int userId, int productId)
        {
            return _cartDal.GetCartByUserID(userId, productId);
        }
        public void update(Cart cart)
        {
            _cartDal.update(cart);
        }
        public void ClearCart(List<Cart> carts)
        {
            _cartDal.ClearCart(carts);
        }
    }
}
