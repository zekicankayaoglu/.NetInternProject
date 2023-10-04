using Entities.Concrete;

namespace MvcUI.Models
{
    public class CartListViewModel
    {
        public Cart Cart { get; set; }
        public List<CartDetail> Carts { get; set; }
        public decimal Total
        {



            get { return Carts.Sum(c => c.Stock * c.Price); }
        }
    }
}
