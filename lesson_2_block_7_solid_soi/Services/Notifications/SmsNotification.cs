using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_2_block_7_solid_soi.Services.Notifications
{
    public class SmsNotification : NotificationBase, INotificationChannel
    {
        private readonly string _phoneNumber;

        public SmsNotification(string phoneNumber)
        {
            _phoneNumber = phoneNumber;
        }

        public override void Send(string message)
        {
            string formattedMessage = FormatMessage(message);
            Console.WriteLine($"[SMS -> {_phoneNumber}]: {formattedMessage}");
        }
    }
}
