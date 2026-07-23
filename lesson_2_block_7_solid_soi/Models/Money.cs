using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_2_block_7_solid_soi.Models
{
    public readonly struct Money
    {
        public decimal Amount { get; }
        public string Currency { get; }

        public Money(decimal amount, string currency)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount can't be negative");
            }

            Amount = amount;
            Currency = currency;
        }

        public Money Add(Money other)
        {
            if (Currency != other.Currency)
            {
                throw new InvalidOperationException("Currencies do not match");
            }

            return new Money(Amount + other.Amount, Currency);
        }
    }
}
