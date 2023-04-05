using System;
using System.Linq;
using System.Collections.Generic;

namespace ironblood.Domain.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public List<OrderItem>? Items { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal TotalPrice => Items.Sum(i => i.Price);
    }
}