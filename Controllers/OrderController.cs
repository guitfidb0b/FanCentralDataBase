
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FanCentral2.Models;
using System.Linq;


namespace FanCentral2.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository repository;
        private Cart cart;
        public OrderController(IOrderRepository repoService, Cart cartService)
        {
            repository = repoService;
            cart = cartService;
        }
        public ViewResult Checkout() => View(new GuestOrder());

        [HttpPost]
        public IActionResult Checkout(GuestOrder guestOrder)
        {
            if(cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                guestOrder.Lines = cart.Lines.ToArray();
                repository.SaveOrder(guestOrder);
                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(guestOrder);
            }
        }
        public ViewResult Completed()
        {
            cart.Clear();
            return View();
        }
    }
}