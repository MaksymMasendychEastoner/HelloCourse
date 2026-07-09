using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_2_block_5.Shipping
{
    public sealed class ExpressShipping : IShippingMethod
    {
        public decimal Cost => 15m;
        public int EstimatedDays => 1;
        public string Name => "Express Shipping";
    }
}
