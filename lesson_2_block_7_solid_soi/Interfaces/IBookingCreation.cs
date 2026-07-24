using lesson_2_block_7_solid_soi.Models;
using lesson_2_block_7_solid_soi.Services.Notifications;
using lesson_2_block_7_solid_soi.Services.Pricing;
using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_2_block_7_solid_soi.Interfaces
{
    public interface IBookingCreation
    {
        Booking CreateBooking(BookingRequest request, IRoomPricingStrategy pricingStrategy, INotificationChannel notificationChannel);
    }
}
