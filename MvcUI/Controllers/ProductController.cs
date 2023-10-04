using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using MvcUI.Models;
using System.Reflection.Metadata.Ecma335;

namespace MvcUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        private IUserService _userService;
        public ProductController(IProductService productService, IUserService userService)
        {
            _productService = productService;
            _userService = userService;
        }


        public IActionResult Index(int category)
        {
            if (_userService.GetCurrentUser() == null)
            {
                return RedirectToAction("Index", controllerName: "Home");
            }
            var model = new ProductListViewModel
            {
                Products = category>0?_productService.GetByCategory(category) : _productService.GetAll()
            };
            return View(model);        
            
        }
        }

    }

