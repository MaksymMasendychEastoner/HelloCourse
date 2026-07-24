using lesson_2_block_7_solid_soi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_2_block_7_solid_soi.Services.Validation
{
    public class BookingValidator
    {
        public void Validate(BookingRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (request.CheckOut <= request.CheckIn)
            {
                throw new ArgumentException("CheckOut date must be later than CheckIn date.");
            }

            if (request.GuestsCount <= 0)
            {
                throw new ArgumentException("Guests count must be greater than zero.");
            }
        }
    }
}
