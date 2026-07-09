using lesson_2_block_5.Dto;
using lesson_2_block_5.Shipping;
using lesson_2_block_5.Strategies;
using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_2_block_5.Orders
{
    public sealed class Order
    {
        public required ProductDto Product { get; init; }
        public required IDiscountStrategy Discount { get; init; }
        public required IShippingMethod Shipping { get; init; }

        public decimal GetTotal()
        {
            // Ціна товару зі знижкою + вартість доставки
            decimal discountedPrice = Discount.ApplyDiscount(Product.Price);
            return discountedPrice + Shipping.Cost;
        }
    }
}
