using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_2_block_7_solid_soi.Services.Notifications
{
    public abstract class NotificationBase
    {
        public abstract void Send(string message);

        // Спільна логіка форматування повідомлення для всіх нотифікацій
        protected string FormatMessage(string message) => $"[Booking] {message}";
    }
}
