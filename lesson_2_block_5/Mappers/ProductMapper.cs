using System;
using System.Collections.Generic;
using lesson_2_block_5.Models;
using lesson_2_block_5.Dto;

namespace lesson_2_block_5.Mappers;

public static class ProductMapper
{
    public static ProductDto ToDto(RawProduct raw)
    {
        return new ProductDto
        {
            Id = raw.Id,
            Name = raw.Name ?? "Unknown",
            Category = raw.CategoryName ?? "Unknown",
            Price = (decimal)raw.PriceUsd, // Перетворення double в decimal
            StockCount = raw.StockCount,
            // Доступний тільки якщо активний І кількість на складі більше 0
            IsAvailable = raw.IsActive && raw.StockCount > 0
        };
    }

    public static List<ProductDto> ToDtoList(List<RawProduct> raws)
    {
        var result = new List<ProductDto>();
        foreach (var raw in raws)
        {
            result.Add(ToDto(raw));
        }
        return result;
    }
}