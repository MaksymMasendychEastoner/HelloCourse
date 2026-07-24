using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_2_block_7_solid_soi.Models
{
    public record BookingRequest
    {
        public Guid RoomId { get; }
        public DateOnly CheckIn { get; }
        public DateOnly CheckOut { get; }
        public int GuestsCount { get; }

        public BookingRequest(Guid roomId, DateOnly checkIn, DateOnly checkOut, int guestsCount)
        {
            // Валідація згідно із завданням:
            // Checkout має бути пізніше за CheckIn
            if (checkOut <= checkIn)
            {
                throw new ArgumentException("CheckOut date must be later than CheckIn date.");
            }

            // GuestsCount > 0
            if (guestsCount <= 0)
            {
                throw new ArgumentException("Guests count must be greater than zero.");
            }

            RoomId = roomId;
            CheckIn = checkIn;
            CheckOut = checkOut;
            GuestsCount = guestsCount;
        }
    }

    public record SuiteBookingRequest : BookingRequest
    {
        public bool HasButlerService { get; }

        public SuiteBookingRequest(Guid roomId, DateOnly checkIn, DateOnly checkOut, int guestsCount, bool hasButlerService)
            : base(roomId, checkIn, checkOut, guestsCount)
        {
            HasButlerService = hasButlerService;
        }
    }
}
