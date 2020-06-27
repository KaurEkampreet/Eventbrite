using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using EventCatalog.Data;
using EventCatalog.Domain;
using EventCatalog.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EventCatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventContext _context;
        private readonly IConfiguration _config;

        public EventController(EventContext context, IConfiguration config )
        {
            _context = context;
            _config = config;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Items(
           [FromQuery]int pageIndex = 0,
           [FromQuery]int pageSize = 6)
        {
            var itemsCount = await _context.EventsCatalogs.LongCountAsync();
            var items = await _context.EventsCatalogs
                 .OrderBy(c => c.Name)
                 .Skip(pageIndex * pageSize)
                 .Take(pageSize)
                 .ToListAsync();

            items = ChangePictureUrl(items);

            var model = new PaginatedItemsViewModel<EventsCatalog>
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Count = itemsCount,
                Data = items,

            };
            return Ok(items);
        }

        private List<EventsCatalog> ChangePictureUrl(List<EventsCatalog> items)
        {
            items.ForEach(item =>
            item.PictureUrl = item.PictureUrl.Replace("http://externalcatalogbaseurltobereplaced", _config["ExternalCatalogBaseUrl"]));
            return items;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EventTypes()
        {
            var types = await _context.EventTypes.ToListAsync();
            return Ok(types);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EventCategories()
        {
            var categories = await _context.EventCategories.ToListAsync();
            return Ok(categories);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EventLocations()
        {
            var locations = await _context.EventLocations.ToListAsync();
            return Ok(locations);
        }

        [HttpGet("[action]/type/{eventTypeId}/category{eventCategoryId}/location{eventlocationId}")]
        public async Task<IActionResult> Items(
            int? eventTypeId,
            int? eventCategoryId,
            int? eventLocationId,
            [FromQuery]int pageIndex = 0,
            [FromQuery]int pageSize = 6
            )
        {
            var query = (IQueryable<EventsCatalog>)_context.EventsCatalogs;

            if (eventTypeId.HasValue)
            {
                query = query.Where(c => c.EventTypeId == eventTypeId);
            }

            if (eventCategoryId.HasValue)
            {
                query = query.Where(c => c.EventCategoryId == eventCategoryId);
            }
            if (eventLocationId.HasValue)
            {
                query = query.Where(c => c.EventLocationId == eventLocationId);
            }

            var itemsCount = query.LongCountAsync();

            var items = await query
                .OrderBy(c => c.Name)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();
            items = ChangePictureUrl(items);

            var model = new PaginatedItemsViewModel<EventsCatalog>
            {
                PageIndex = pageIndex,
                PageSize = items.Count,
                Count = itemsCount.Result,
                Data = items
            };
            return Ok(model);

        }
    }
}
