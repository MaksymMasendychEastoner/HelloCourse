using System;
using System.Collections.Generic;
using System.Text;

namespace group_tasks.Block5_Solid
{
    // Клас User відповідає тільки за збереження даних користувача
    public class User
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

    // Клас UserRepository відповідає лише за збереження/роботу з базою даних
    public class UserRepository
    {
        public void Save(User user)
        {
            Console.WriteLine($"Збереження користувача {user.Name} у базу даних...");
        }
    }

    // Клас EmailService відповідає лише за відправку email-повідомлень
    public class EmailService
    {
        public void SendWelcomeEmail(User user)
        {
            Console.WriteLine($"Надсилання вітального листа на email: {user.Email}");
        }
    }
}
