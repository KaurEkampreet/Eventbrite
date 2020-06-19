using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalog.Domain
{
    public class EventsCatalog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EventTypeId { get; set; }
        public EventType EventType { get; set; }
        public int EventCategoryId { get; set; }
        public EventCategory EventCategory { get; set; }
        public int EventLocationId { get; set; }
        public EventLocation EventLocation { get; set; }
    }
}
