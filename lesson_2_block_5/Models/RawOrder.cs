using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_2_block_5.Models
{
    public class RawOrder
    {
        public int OrderId;
        public int CustomerId;
        public string? CustomerName;
        public List<int>? ProductIds;   // список Id продуктів у замовленні
        public string? Status;          // "pending", "shipped", "cancelled"
        public DateTime CreatedAt;
    }
}
