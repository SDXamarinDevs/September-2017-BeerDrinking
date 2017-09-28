using System;
using System.Collections.Generic;
using System.Linq;
using Realms;

namespace BeerDrinking.Models
{
    public class Brewer : RealmObject
    {
        public string Name { get; set; }

        public DateTimeOffset? InBusinessSince { get; set; }

        public string Location { get; set; }

        public string About { get; set; }

        public string Logo { get; set; }

        [Backlink(nameof(Beer.Brewer))]
        public IQueryable<Beer> Beers { get; }
    }
}
