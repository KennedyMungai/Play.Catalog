using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Play.Catalog.Service.Dtos;

namespace Play.Catalog.Service.Controllers;

[ApiController]
[Route("items")]
public class ItemsController : ControllerBase
{
    private static readonly List<ItemDto> items = new()
    {
        new ItemDto(
            Guid.NewGuid(), 
            "Potion", 
            "Restores a small amount of HP", 
            5, 
            DateTimeOffset.UtcNow),

        new ItemDto(
            Guid.NewGuid(),
            "Antidote",
            "Cures poison",
            7,
            DateTimeOffset.UtcNow
        ),

        new ItemDto(
            Guid.NewGuid(),
            "Bronze Sword",
            "Deals a small amount of damage",
            5,
            DateTimeOffset.UtcNow
        )
    };
}