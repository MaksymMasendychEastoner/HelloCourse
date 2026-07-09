using lesson_2_block_5.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_2_block_5.Strategies
{
    public static class PriceCalculator
    {
        public static decimal CalculateFinalPrice(ProductDto product, IDiscountStrategy discountStrategy)
        {
            return discountStrategy.ApplyDiscount(product.Price);
        }

        public static void PrintReceipt(ProductDto product, IDiscountStrategy discountStrategy)
        {
            decimal finalPrice = CalculateFinalPrice(product, discountStrategy);
            Console.WriteLine($"Product: {product.Name}");
            Console.WriteLine($" - Original Price: ${product.Price}");
            Console.WriteLine($" - Discount Applied: {discountStrategy.Description}");
            Console.WriteLine($" - Final Price: ${finalPrice:F2}");
            Console.WriteLine(new string('-', 30));
        }
    }
}
