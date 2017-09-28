using System;
using Realms;

namespace BeerDrinking.Models
{
    public class Beer : RealmObject
    {
        public string Name { get; set; }

        public double ABV { get; set; }

        public string Style { get; set; }

        public int IBUs { get; set; }

        public string Description { get; set; }

        public Brewer Brewer { get; set; }
    }
}
