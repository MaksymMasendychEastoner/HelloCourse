using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_2_block_5.Shipping
{
    public sealed class StandardShipping : IShippingMethod
    {
        public decimal Cost => 5m;
        public int EstimatedDays => 5;
        public string Name => "Standard Shipping";
    }
}
