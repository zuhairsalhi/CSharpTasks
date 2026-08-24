using System;

namespace Task08.App
{
    [Flags]
    public enum OrderStatus
    {
        None = 0,
        Pending = 1,
        Paid = 2,
        Shipped = 4,
        Delivered = 8
    }
}