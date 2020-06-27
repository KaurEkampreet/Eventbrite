using EventCatalog.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalog.Data
{
    public class EventSeed
    {
        public static void Seed(EventContext eventContext)
        {
            eventContext.Database.Migrate();
            if (!eventContext.EventCategories.Any())
            {
                eventContext.EventCategories.AddRange(GetEventCategories());
                eventContext.SaveChanges();
            }
            if (!eventContext.EventTypes.Any())
            {
                eventContext.EventTypes.AddRange(GetEventTypes());
                eventContext.SaveChanges();
            }
            if (!eventContext.EventLocations.Any())
            {
                eventContext.EventLocations.AddRange(GetEventLocations());
                eventContext.SaveChanges();
            }
            if (!eventContext.EventsCatalogs.Any())
            {
                eventContext.EventsCatalogs.AddRange(GetEventsCatalogs());
                eventContext.SaveChanges();
            }
        }

        private static IEnumerable<EventCategory> GetEventCategories()
        {
            return new List<EventCategory>
            {
                    new EventCategory
                    {
                        Category = "Family & Education"
                    },
                    new EventCategory
                    {
                        Category = "Science & Technology"
                    },
                    new EventCategory
                    {
                        Category= "Sports & Fitness"
                    }
            };
        }
        private static IEnumerable<EventType> GetEventTypes()
        {
            return new List<EventType>
            {
                    new EventType
                    {
                        Type = "Family & Education"
                    },
                    new EventType
                    {
                        Type = "Science & Technology"
                    },
                    new EventType
                    {
                    Type= "Sports & Fitness"
                    }
            };
        }

        private static IEnumerable<EventLocation> GetEventLocations()
        {
            return new List<EventLocation>()
            {
               new EventLocation(){UserId=1,VenueName="Venue 1", Address="156th ave ne",City="Auburn",State="Washington",PostalCode=98198},
               new EventLocation(){UserId=1,VenueName="Venue 2",Address="166th ave se",City="Bellevue",State="Nevada",PostalCode=98001},
               new EventLocation(){UserId=1,VenueName="Venue 3",Address="253th ave ne",City="Kirkland",State="Washington",PostalCode=98056},
               new EventLocation(){UserId=1,VenueName="Venue 4",Address="26th ave ne",City="vegas",State="LasVegas",PostalCode=98023},
               new EventLocation(){UserId=2,VenueName="Venue 5",Address="12th ave se",City="Renton",State="California",PostalCode=98033},
               new EventLocation(){UserId=2,VenueName="Venue 6",Address="13th ave ne",City="Redmond",State="Texas",PostalCode=98020},
               new EventLocation(){UserId=2,VenueName="Venue 7",Address="118th ave se",City="Kent",State="Washington",PostalCode=98022}
           };
        }
        private static IEnumerable<EventsCatalog> GetEventsCatalogs()
        {
            return new List<EventsCatalog>()
            {
                new EventsCatalog { EventTypeId = 1, EventCategoryId = 1, Name = "BE About IT", Description = "Be About It: Unpacking White Privilege, Bias, and Anti-Racist Instruction", EventLocationId = 1, StartDate=Convert.ToDateTime("06/20/2020"),EndDate=Convert.ToDateTime("10/2/2020"), Price = 60, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1" },
                new EventsCatalog { EventTypeId = 1, EventCategoryId = 2, Name= "Webinar Statistika", Description = "Webinar Statistika #3 | Statistical Methods (ANOVA and MANOVA)", EventLocationId = 1, StartDate=Convert.ToDateTime("09/2/2022"),EndDate=Convert.ToDateTime("10/2/2020"), Price = 55, PictureUrl= "http://externalcatalogbaseurltobereplaced/api/pic/2" },
                new EventsCatalog { EventTypeId = 3, EventCategoryId = 2, Name= "ProductCon Online", Description = "ProductCon Online: The Product Management Conference", EventLocationId = 5, StartDate=Convert.ToDateTime("06/4/2020"),EndDate=Convert.ToDateTime("10/2/2020"), Price = 150, PictureUrl= "http://externalcatalogbaseurltobereplaced/api/pic/3" },
                new EventsCatalog { EventTypeId = 2, EventCategoryId = 3, Name = "2020 NJCAAE", Description = "2020 NJCAAE Convention Day 1", EventLocationId = 3, StartDate=Convert.ToDateTime("09/20/2020"),EndDate=Convert.ToDateTime("10/2/2020"), Price = 0, PictureUrl= "http://externalcatalogbaseurltobereplaced/api/pic/4"  },
                new EventsCatalog { EventTypeId = 1, EventCategoryId = 2, Name = "Biomarkers", Description = "Use of Biomarkers to Establish the Presence and Severity of Impairment", EventLocationId = 2, StartDate=Convert.ToDateTime("09/2/2020"),EndDate=Convert.ToDateTime("10/2/2020"), Price = 30, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/5"},
                new EventsCatalog { EventTypeId = 2, EventCategoryId = 1, Name = "PSCC 2020", Description = "XXI Power Systems Computation Conference", EventLocationId = 4, StartDate=Convert.ToDateTime("09/20/2020"),EndDate=Convert.ToDateTime("10/2/2020"), Price = 100, PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/6"},
                new EventsCatalog { EventTypeId = 3, EventCategoryId = 1, Name = "RELIT!", Description = "RELIT! 2020: Bring. Your. Brave.", EventLocationId = 5, StartDate=Convert.ToDateTime("09/23/2020"),EndDate=Convert.ToDateTime("10/2/2020"), Price = 50, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/7"},
                new EventsCatalog { EventTypeId = 1, EventCategoryId = 3, Name = "The Coronavirus Advice", Description = "Webinar: The Coronavirus Advice Your Fitness Business Needs to Hear", EventLocationId = 3, StartDate=Convert.ToDateTime("07/20/2020"),EndDate=Convert.ToDateTime("10/2/2020"), Price = 60, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/8"},
                new EventsCatalog { EventTypeId = 3, EventCategoryId = 3, Name = "SportBite", Description = "Introduction to Elite Performance Conference - SportBite", EventLocationId = 4, StartDate=Convert.ToDateTime("09/25/2020"),EndDate=Convert.ToDateTime("10/2/2020"), Price = 10, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/9"},
                new EventsCatalog { EventTypeId = 2, EventCategoryId = 2, Name = "Miami 2020", Description = "Mining Disrupt Conference LIVE | Bitcoin Blockchain Cryptocurrency Mining", EventLocationId = 4, StartDate=Convert.ToDateTime("07/20/2020"),EndDate=Convert.ToDateTime("10/2/2020"), Price = 100, PictureUrl= "http://externalcatalogbaseurltobereplaced/api/pic/10"},
                new EventsCatalog { EventTypeId = 1, EventCategoryId = 1, Name = "NABME", Description = "A Conversation to Foster Anti-Racist Practices in Schools", EventLocationId = 5, StartDate=Convert.ToDateTime("09/24/2020"),EndDate=Convert.ToDateTime("10/2/2020"), Price = 5, PictureUrl= "http://externalcatalogbaseurltobereplaced/api/pic/11" },
                new EventsCatalog { EventTypeId = 3, EventCategoryId = 1, Name = "The 2020 9th Annual", Description = "2020 9th Annual Liberated Minds Black Homeschool", EventLocationId = 3, StartDate=Convert.ToDateTime("07/2/2020"),EndDate=Convert.ToDateTime("10/2/2020"), Price = 25, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/12"},
                new EventsCatalog { EventTypeId = 2, EventCategoryId = 2, Name = "HHL Expert Talk", Description = "HHL Expert Talk - How to become a great negotiator? Research and practice", EventLocationId = 3, StartDate=Convert.ToDateTime("06/27/2020"),EndDate=Convert.ToDateTime("10/2/2020"), Price = 30, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/13" },
                new EventsCatalog { EventTypeId = 1, EventCategoryId = 1, Name = "Back to School", Description = "Webinar: Business and Engineering in the USA", EventLocationId = 2, StartDate=Convert.ToDateTime("09/11/2020"),EndDate=Convert.ToDateTime("10/2/2020"), Price = 0, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/14"},
                new EventsCatalog { EventTypeId = 3, EventCategoryId = 2, Name = "New Era", Description = "A New Era for Food and Climate", EventLocationId = 2, StartDate=Convert.ToDateTime("08/11/202"),EndDate=Convert.ToDateTime("10/2/2020"), Price = 45, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/15" },

            };
        }
    }
}
