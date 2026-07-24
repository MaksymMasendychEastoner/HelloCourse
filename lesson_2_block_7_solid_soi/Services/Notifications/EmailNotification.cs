using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_2_block_7_solid_soi.Services.Notifications
{
    public class EmailNotification : NotificationBase, INotificationChannel
    {
        private readonly string _emailAddress;

        public EmailNotification(string emailAddress)
        {
            _emailAddress = emailAddress;
        }

        public override void Send(string message)
        {
            string formattedMessage = FormatMessage(message);
            Console.WriteLine($"[Email -> {_emailAddress}]: {formattedMessage}");
        }
    }
}
