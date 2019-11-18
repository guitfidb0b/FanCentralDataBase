using System.Collections.Generic;

namespace FanCentral2.Models
{
    public interface IOrderRepository
    {
         IEnumerable<GuestOrder> GuestOrders { get; }
         void SaveOrder(GuestOrder guestOrder);
    }
}