using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_2_block_5.Shipping
{
    public interface IShippingMethod
    {
        decimal Cost { get; }
        int EstimatedDays { get; }
        string Name { get; }
    }
}
