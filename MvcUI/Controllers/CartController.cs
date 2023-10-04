using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MvcUI.Helpers;
using MvcUI.Models;
using System.Reflection.Metadata.Ecma335;

namespace MvcUI.Controllers
{
    public class CartController : Controller
    {
        private ICartService _cartService;
        private ICartSessionHelper _cartSessionHelper;
        private IProductService _productService;
        private IUserService _userService;
        public CartController(ICartService cartService, ICartSessionHelper cartSessionHelper, IProductService productService, IUserService userService)
        {
            _cartService = cartService;
            _cartSessionHelper = cartSessionHelper;
            _productService = productService;
            _userService = userService;
        }

        public IActionResult AddToCart(int productId, int userId)
        {
            Product product = _productService.GetById(productId);
            Cart checkUser =  _cartService.getCartByUserID(_userService.GetCurrentUser().UserID, productId);
            if (checkUser != null)
            {
                checkUser.Quantity++;
                _cartService.update(checkUser);
            }
            else
            {
                Cart cart = new Cart
                {
                    UserID = _userService.GetCurrentUser().UserID,
                    ProductID = productId,
                    Quantity = 1,
                    CartID = 0
                };
                _cartService.add(cart);
            }
            TempData.Add("message", product.ProductName + " Added to cart!");
            return RedirectToAction("Index", controllerName: "Product");
        }
        public IActionResult RemoveFromCart(int productId)
        {
            Product product = _productService.GetById(productId);
            Cart checkUser = _cartService.getCartByUserID(_userService.GetCurrentUser().UserID, productId);
            if (checkUser != null)
            {
                checkUser.Quantity--;
                _cartService.update(checkUser);
            }
            
            TempData.Add("message", product.ProductName + " Added to cart!");
            return RedirectToAction("Index", controllerName: "Cart");
        }

        public IActionResult Index()
        {
            
            List<Cart> carts = _cartService.getUserCart(_userService.GetCurrentUser().UserID);
            List<CartDetail> cartDetails = new List<CartDetail>();
            int i = 0;
            foreach (var cart in carts)
            {
                if (cart.ProductID != 1 && cart.Quantity > 0)
                {
                    CartDetail cartss = new CartDetail
                    {
                        Id = cart.ProductID,
                        productName = _productService.GetById(cart.ProductID).ProductName,
                        Stock = cart.Quantity,
                        Price = _productService.GetById(cart.ProductID).UnitPrice * cart.Quantity
                    };
                    cartDetails.Add(cartss);
                }
            }
            var model = new CartListViewModel
            {
                Carts = cartDetails
            };
            return View(model);
        }
        
        public IActionResult Complete()
        {
            
            TempData.Add("message", "Your order was successful!");
            _cartService.ClearCart((_cartService.getUserCart(_userService.GetCurrentUser().UserID)));
            return RedirectToAction("Index", controllerName: "Cart");

        }
        public IActionResult SignUp()
        {
            var model = new RegisterDtoModel
            {
                RegisterDto = new RegisterDto()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterDto RegisterDto)
        {
            var userExists = await _userService.GetByMail(RegisterDto.Email);

            if (userExists != null)
            {
                return BadRequest("Kullanıcı zaten var!");
            }
            User user = new User
            {
                UserID = 0,
                Email = RegisterDto.Email,
                FirstName = RegisterDto.FirstName,
                LastName = RegisterDto.LastName,
                Password = RegisterDto.Password,
                
            };
            _userService.Add(user);

            TempData.Add("message", "You signed up!");

            return RedirectToAction("Index", controllerName: "");

        }
        public IActionResult LogIn()
        {
            var model = new LoggingDetailsViewModel
            {
                LoggingDetails = new LoggingDetail()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoggingDetail LoggingDetails)
        {
            var userExists = await _userService.GetByMail(LoggingDetails.Email);

            if (userExists == null)
            {
                return BadRequest("Kullanıcı yok!");
            }
            if (userExists.Email != LoggingDetails.Email)
            {
                return BadRequest("Mail yanlış");

            }
            if (userExists.Password != LoggingDetails.Password)
            {
                return BadRequest("şifre yanlış");
            }

            userExists.Status = true;
            _userService.LogIn(userExists);
            TempData.Add("message", "You logged in!");
            return RedirectToAction("Index", controllerName: "Product");
        }
        public IActionResult LogOut()
        {
            User loggedUser = _userService.GetCurrentUser();
            loggedUser.Status = false;
            _userService.LogOut(loggedUser);
            return RedirectToAction("Index",controllerName: "Home");
        }
    }
}
