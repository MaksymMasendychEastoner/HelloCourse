using lesson_2_block_7_solid_soi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_2_block_7_solid_soi.Services.Pricing
{
    public class WeekendSurchargePricing : IRoomPricingStrategy
    {
        private readonly decimal _pricePerNight;
        private readonly string _currency;

        public string StrategyName => "Weekend Surcharge Pricing (+20% on Fri/Sat)";

        public WeekendSurchargePricing(decimal pricePerNight, string currency = "USD")
        {
            _pricePerNight = pricePerNight;
            _currency = currency;
        }

        public Money CalculatePrice(BookingRequest request)
        {
            int nights = request.CheckOut.DayNumber - request.CheckIn.DayNumber;
            decimal totalPrice = _pricePerNight * nights;

            // Перевіряємо день тижня для заїзду
            DayOfWeek checkInDay = request.CheckIn.DayOfWeek;
            if (checkInDay == DayOfWeek.Friday || checkInDay == DayOfWeek.Saturday)
            {
                totalPrice *= 1.20m; // додаємо 20%
            }

            return new Money(totalPrice, _currency);
        }
    }
}
