using lesson_2_block_7_solid_soi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_2_block_7_solid_soi.Services.Pricing
{
    public interface IRoomPricingStrategy
    {
        Money CalculatePrice(BookingRequest request);
        string StrategyName { get; }
    }
}
