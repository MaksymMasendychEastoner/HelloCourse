using lesson_2_block_7_solid_soi.Models;
using lesson_2_block_7_solid_soi.Services.Notifications;
using lesson_2_block_7_solid_soi.Services.Pricing;
using lesson_2_block_7_solid_soi.Services.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_2_block_7_solid_soi.Services
{
    public class BookingService
    {
        private readonly BookingValidator _validator;
        private readonly BookingRepository _repository;

        public BookingService(BookingValidator validator, BookingRepository repository)
        {
            _validator = validator;
            _repository = repository;
        }

        public Booking CreateBooking(BookingRequest request, IRoomPricingStrategy pricingStrategy, INotificationChannel notificationChannel)
        {
            // Валідація
            _validator.Validate(request);

            // Розрахунок ціни через підставлену стратегію (поліморфізм)
            Money totalPrice = pricingStrategy.CalculatePrice(request);

            // Створення та збереження об'єкта бронювання
            var booking = new Booking
            {
                Id = Guid.NewGuid(),
                Request = request
            };

            booking.Confirm();
            _repository.Save(booking);

            // Сповіщення
            notificationChannel.Send($"Your booking for room {request.RoomId} is confirmed. Total: {totalPrice.Amount} {totalPrice.Currency}");

            return booking;
        }
    }
}
