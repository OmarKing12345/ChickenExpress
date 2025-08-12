using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenExpress.Domain.Enums
{
    public enum OrderStatus
    {
        Pending = 0,
        Preparing = 1,
        OutForDelivery = 2,
        Completed = 3,
        Canceled = 4
    }

    public enum DeliveryMode
    {
        Pickup = 0,
        Delivery = 1,
        DineIn = 2
    }

    public enum PaymentStatus
    {
        Unpaid = 0,
        Authorized = 1,
        Paid = 2,
        Refunded = 3,
        Failed = 4
    }
}
