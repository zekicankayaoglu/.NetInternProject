using Entities.Concrete;

namespace MvcUI.Helpers
{
    public interface ICartSessionHelper
    {
        Cart GetCart(string key);
        void SetCart(string key,Cart cart);
        void Clear();
    }
}
