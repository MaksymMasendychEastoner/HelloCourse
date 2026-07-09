using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_2_block_5.Strategies
{
    public sealed class FixedAmountDiscount : IDiscountStrategy
    {
        private readonly decimal _amount;

        public FixedAmountDiscount(decimal amount)
        {
            _amount = amount;
        }

        public decimal ApplyDiscount(decimal originalPrice)
        {
            // Ціна не може стати меншою за 0
            return Math.Max(0, originalPrice - _amount);
        }

        public string Description => $"${_amount} off";
    }
}
