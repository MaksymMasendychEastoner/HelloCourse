using lesson_2_block_7_solid_soi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_2_block_7_solid_soi.Services.Pricing
{
    public class StandardPricing : IRoomPricingStrategy
    {
        private readonly decimal _pricePerNight;
        private readonly string _currency;

        public string StrategyName => "Standard Pricing";

        public StandardPricing(decimal pricePerNight, string currency = "USD")
        {
            _pricePerNight = pricePerNight;
            _currency = currency;
        }

        public Money CalculatePrice(BookingRequest request)
        {
            // Рахуємо кількість ночей через DayNumber
            int nights = request.CheckOut.DayNumber - request.CheckIn.DayNumber;
            decimal totalPrice = _pricePerNight * nights;

            return new Money(totalPrice, _currency);
        }
    }
}
