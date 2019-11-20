
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FanCentral2.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;


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

        [Authorize]
        public ViewResult List() => View(repository.GuestOrders.Where(o => !o.Shipped));

        [HttpPost]
        [Authorize]
        public IActionResult MarkShipped(int guestOrderID)
        {
            GuestOrder guestOrder = repository.GuestOrders
                .FirstOrDefault(o => o.GuestOrderID == guestOrderID);
            if (guestOrder != null)
            {
                guestOrder.Shipped = true;
                repository.SaveOrder(guestOrder);
            }
            return RedirectToAction(nameof(List));
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