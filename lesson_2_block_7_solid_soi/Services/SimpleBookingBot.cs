using lesson_2_block_7_solid_soi.Interfaces;
using lesson_2_block_7_solid_soi.Services.Notifications;
using lesson_2_block_7_solid_soi.Services.Pricing;
using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_2_block_7_solid_soi.Models
{
    public class SimpleBookingBot : IBookingCreation, IBookingCancellation, IInvoicing, IReminders
    {
        private readonly BookingService _bookingService;

        public SimpleBookingBot(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public Booking CreateBooking(BookingRequest request, IRoomPricingStrategy pricingStrategy, INotificationChannel notificationChannel)
        {
            Console.WriteLine("[Bot] Processing booking creation...");
            return _bookingService.CreateBooking(request, pricingStrategy, notificationChannel);
        }

        public bool CancelBooking(Guid bookingId)
        {
            Console.WriteLine($"[Bot] Cancelling booking {bookingId}...");
            // Симуляція скасування
            return true;
        }

        public string GenerateInvoice(Booking booking)
        {
            Console.WriteLine($"[Bot] Generating invoice for booking {booking.Id}...");
            return $"INVOICE for Booking {booking.Id} | Status: {booking.Status}";
        }

        public void SendReminder(Guid bookingId)
        {
            Console.WriteLine($"[Bot] Sending reminder for booking {booking.Id}...");
        }
    }
}
