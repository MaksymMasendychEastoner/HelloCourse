using lesson_2_block_7_solid_soi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_2_block_7_solid_soi.Services.Validation
{
    public class BookingRepository
    {
        private readonly List<Booking> _bookings = new();

        public void Save(Booking booking)
        {
            _bookings.Add(booking);
            Console.WriteLine($"[Repository] Booking saved with ID: {booking.Id}");
        }

        public List<Booking> GetAll()
        {
            return _bookings;
        }
    }
}
