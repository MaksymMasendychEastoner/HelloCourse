using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_2_block_5.Strategies
{
    public interface IDiscountStrategy
    {
        decimal ApplyDiscount(decimal originalPrice);
        string Description { get; }
    }
}
