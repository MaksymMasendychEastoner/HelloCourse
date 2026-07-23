using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_2_block_7_solid_soi.Models
{
    // class: має ідентичність, змінюється протягом life-cycle
    public class Booking
    {
        public Guid Id { get; init; }
        public BookingRequest Request { get; init; } = null!;
        public BookingStatus Status { get; private set; } = BookingStatus.Pending;

        public void Confirm()
        {
            Status = BookingStatus.Confirmed;
        }

        public void Cancel()
        {
            Status = BookingStatus.Cancelled;
        }
    }
}
