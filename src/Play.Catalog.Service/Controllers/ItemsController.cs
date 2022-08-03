using Microsoft.AspNetCore.Mvc;
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

    [HttpGet]
    public IEnumerable<ItemDto> Get()
    {
        return items;
    }

    [HttpGet("{id}")]
    public ItemDto GetById(Guid id)
    {
        var item = items
                    .Where(item => item.Id == id)
                    .SingleOrDefault();

        return item;
    }

    // POST /items

    [HttpPost]
    public ActionResult<ItemDto> Post(CreateItemDto createItemDto)
    {
        var item = new ItemDto(
                    Guid.NewGuid(),
                    createItemDto.Name,
                    createItemDto.Description,
                    createItemDto.Price,
                    DateTimeOffset.UtcNow
            );

        items.Add(item);

        return CreatedAtAction(nameof(GetById), new {id = item.Id}, item);
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, UpdateItemDto updateItemDto)
    {
        var existingItem = items
                            .Where(item => item.Id == id)
                            .SingleOrDefault();

        var updatedItem = existingItem with {
            Name = updateItemDto.Name,
            Description = updateItemDto.Description,
            Price = updateItemDto.Price
        };

        var index = items.FindIndex(existingItem => existingItem.Id == id);
        items[index] = updatedItem;

        return NoContent();
    }
}