using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_2_block_7_solid_soi.Services.Notifications
{
    public interface INotificationChannel
    {
        void Send(string message);
    }
}
