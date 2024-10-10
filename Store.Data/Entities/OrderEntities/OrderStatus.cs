using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Entities.OrderEntities
{
    public enum OrderStatus
    {
        Placed,
        Running,
        Delivering,
        Delivered,
        Cancelled

    }
}
