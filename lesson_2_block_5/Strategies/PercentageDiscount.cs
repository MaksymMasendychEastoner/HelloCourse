using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_2_block_5.Strategies
{
    public sealed class PercentageDiscount : IDiscountStrategy
    {
        private readonly decimal _percent;

        public PercentageDiscount(decimal percent)
        {
            if (percent < 0 || percent > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(percent), "Percentage must be between 0 and 100.");
            }
            _percent = percent;
        }

        public decimal ApplyDiscount(decimal originalPrice)
        {
            return originalPrice - (originalPrice * (_percent / 100));
        }

        public string Description => $"{_percent}% off";
    }
}
