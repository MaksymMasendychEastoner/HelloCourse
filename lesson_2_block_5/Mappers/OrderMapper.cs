using System;
using System.Collections.Generic;
using lesson_2_block_5.Models;
using lesson_2_block_5.Dto;

namespace lesson_2_block_5.Mappers;

public static class OrderMapper
{
    public static OrderDto ToDto(RawOrder raw)
    {
        // Конвертація рядка статусу в надійний Enum
        OrderStatus mappedStatus = raw.Status?.ToLower() switch
        {
            "pending" => OrderStatus.Pending,
            "shipped" => OrderStatus.Shipped,
            "cancelled" => OrderStatus.Cancelled,
            _ => OrderStatus.Pending // Значення за замовчуванням
        };

        return new OrderDto
        {
            OrderId = raw.OrderId,
            CustomerName = raw.CustomerName ?? "Unknown",
            // Загортаємо список у ReadOnly, захищаючи від null
            ProductIds = raw.ProductIds != null ? raw.ProductIds.AsReadOnly() : new List<int>().AsReadOnly(),
            Status = mappedStatus,
            CreatedAt = raw.CreatedAt
        };
    }

    public static List<OrderDto> ToDtoList(List<RawOrder> raws)
    {
        var result = new List<OrderDto>();
        foreach (var raw in raws)
        {
            result.Add(ToDto(raw));
        }
        return result;
    }
}