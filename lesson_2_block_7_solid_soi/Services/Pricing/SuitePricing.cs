using lesson_2_block_7_solid_soi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_2_block_7_solid_soi.Services.Pricing
{
    public class SuitePricing : IRoomPricingStrategy
    {
        private readonly decimal _basePricePerNight;
        private readonly decimal _butlerFeePerNight;
        private readonly string _currency;

        public string StrategyName => "Suite Room Pricing (with optional Butler)";

        public SuitePricing(decimal basePricePerNight, decimal butlerFeePerNight = 50m, string currency = "USD")
        {
            _basePricePerNight = basePricePerNight;
            _butlerFeePerNight = butlerFeePerNight;
            _currency = currency;
        }

        public Money CalculatePrice(BookingRequest request)
        {
            int nights = request.CheckOut.DayNumber - request.CheckIn.DayNumber;
            decimal pricePerNight = _basePricePerNight;

            // Перевіряємо, чи це запит на Suite і чи включений дворецький
            if (request is SuiteBookingRequest suiteRequest && suiteRequest.HasButlerService)
            {
                pricePerNight += _butlerFeePerNight;
            }

            decimal totalPrice = pricePerNight * nights;
            return new Money(totalPrice, _currency);
        }
    }
}
