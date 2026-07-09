using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_2_block_5.Dto
{
    public sealed class ProductDto
    {
        public int Id { get; init; }
        public string Name { get; init; } = "Unknown";
        public string Category { get; init; } = "Unknown";
        public decimal Price { get; init; }
        public int StockCount { get; init; }
        public bool IsAvailable { get; init; }
    }
}
