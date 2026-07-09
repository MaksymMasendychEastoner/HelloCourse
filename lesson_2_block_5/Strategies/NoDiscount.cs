using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_2_block_5.Strategies
{
    public sealed class NoDiscount : IDiscountStrategy
    {
        public decimal ApplyDiscount(decimal originalPrice)
        {
            return originalPrice;
        }

        public string Description => "No discount";
    }
}
