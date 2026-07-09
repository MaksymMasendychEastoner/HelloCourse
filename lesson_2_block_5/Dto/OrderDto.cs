using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_2_block_5.Dto
{
    public sealed class OrderDto
    {
        public int OrderId { get; init; }
        public string CustomerName { get; init; } = "Unknown";
        public IReadOnlyList<int> ProductIds { get; init; } = Array.Empty<int>();
        public OrderStatus Status { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}
