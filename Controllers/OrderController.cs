using Microsoft.AspNetCore.Mvc;
using FanCentral2.Models;

namespace FanCentral2.Controllers
{
    public class OrderController : Controller
    {
        public ViewResult Checkout() => View(new GuestOrder());
    }
}