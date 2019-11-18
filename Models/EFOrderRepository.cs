using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using FanCentral2.Data;

namespace FanCentral2.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private ApplicationDBContext _context;
        public EFOrderRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public IEnumerable<GuestOrder> GuestOrders => _context.GuestOrders
                                                        .Include(o => o.Lines)
                                                        .ThenInclude(l => l.Product);
        public void SaveOrder(GuestOrder guestOrder)
        {
            _context.AttachRange(guestOrder.Lines.Select(l => l.Product));
            if (guestOrder.GuestOrderID == 0)
            {
                _context.GuestOrders.Add(guestOrder);
            }
            _context.SaveChanges();
        }
    }
}