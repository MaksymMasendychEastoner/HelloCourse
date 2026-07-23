using lesson_2_block_7_solid_soi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_2_block_7_solid_soi.Services.Pricing
{
    public class LongStayDiscountPricing : IRoomPricingStrategy
    {
        private readonly decimal _pricePerNight;
        private readonly string _currency;

        public string StrategyName => "Long Stay Discount Pricing (10% off for 7+ nights)";

        public LongStayDiscountPricing(decimal pricePerNight, string currency = "USD")
        {
            _pricePerNight = pricePerNight;
            _currency = currency;
        }

        public Money CalculatePrice(BookingRequest request)
        {
            int nights = request.CheckOut.DayNumber - request.CheckIn.DayNumber;
            decimal totalPrice = _pricePerNight * nights;

            // Знижка 10% за тривале проживання
            if (nights >= 7)
            {
                totalPrice *= 0.90m; // віднімаємо 10%
            }

            return new Money(totalPrice, _currency);
        }
    }
}
