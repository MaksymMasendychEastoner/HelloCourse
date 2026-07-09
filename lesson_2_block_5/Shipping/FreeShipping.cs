using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_2_block_5.Shipping
{
    public sealed class FreeShipping : IShippingMethod
    {
        public decimal Cost => 0m;
        public int EstimatedDays => 7;
        public string Name => "Free Shipping";
    }
}
