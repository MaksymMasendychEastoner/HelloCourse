using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_2_block_7_solid_soi.Interfaces
{
    public interface IReminders
    {
        void SendReminder(Guid bookingId);
    }
}
