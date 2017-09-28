using System;
using System.Collections.Generic;
using System.Linq;
using BeerDrinking.Models;
using Realms;
namespace BeerDrinking.Extensions
{
    public static class RealmExtensions
    {
        const string StoneBrewing = "Stone Brewing";
        const string BallastPoint = "Ballast Point Brewery";

        public static void Seed(this Realm realm)
        {
            var transaction = realm.BeginWrite();
            if (!realm.All<Brewer>().Any())
            {
                realm.Add(new Brewer
                {
                    Name = StoneBrewing,
                    Location = "San Diego, CA",
                    InBusinessSince = new DateTime(1996, 1, 1),
                    About = @"Founded by Greg Koch and Steve Wagner, Stone Brewing has come a long way since opening up in San Diego, California in 1996. We have been listed on the Inc. 500 | 5000 Fastest Growing Private Companies list 11 times, and has been called the “All-time Top Brewery on Planet Earth” by BeerAdvocate magazine twice. Stone Brewing is the ninth-largest craft brewer in the U.S. and with our breweries in Richmond, Virginia & Berlin, Germany, we join artisanal brewers across the world in the quest to show the public that there are more…and better…choices beyond the world of industrial beer.",
                    Logo = "http://www.stonebrewing.com/sites/all/themes/stone_theme/img/age-gate-logo.png",
                });

                realm.Add(new Brewer
                {
                    Name = BallastPoint,
                    Location = "San Diego, CA",
                    InBusinessSince = new DateTime(1996, 1, 1),
                    About = "After developing a taste for beer in college, founder Jack White decided to try making more interesting beer than he could find in the store or at a keg party. Jack, along with his college roommate Pete A’Hearn, began home brewing in their apartment at UCLA and soon realized it wasn’t easy to get access to the various supplies and ingredients he wanted—nor did he have anyone with whom to trade ideas about brewing.\nIn 1992, Jack opened Home Brew Mart, which he filled with the supplies, ingredients, and conversation every brewer needed to make better beer at home. His plan was to one day take this hobby to the pro level and start a brewery. Around the same time, Pete went off to UC Davis to get his master brewer’s certificate – they soon found a collaborator in Yuseff Cherney, a fellow home brewer with a similar passion and a set of home brewing awards to boot. Yuseff became Home Brew Mart’s first employee and was part of the team to open a “back room” brewery behind the shop. In 1996, Ballast Point Brewing was born.",
                    Logo = "https://www.ballastpoint.com/wp-content/themes/ballastpoint/_/images/ballast-point-lg.png",
                });

            }

            if (!realm.All<Beer>().Any())
            {
                var stoneBrewing = realm.All<Brewer>().First(b => b.Name == StoneBrewing);
                realm.Add(new Beer()
                {
                    Name = "STONE IPA",
                    Style = "India Pale Ale",
                    ABV = 6.9,
                    IBUs = 71,
                    Description = @"By definition, an India pale ale is hoppier and higher in alcohol than its little brother, pale ale—and we deliver in spades. One of the most well-respected and best-selling IPAs in the country, this golden beauty explodes with tropical, citrusy, piney hop flavors and aromas, all perfectly balanced by a subtle malt character. This crisp, extra hoppy brew is hugely refreshing on a hot day, but will always deliver no matter when you choose to drink it.",
                    Brewer = stoneBrewing
                });
                realm.Add(new Beer()
                {
                    Name = "STONE DELICIOUS IPA",
                    Style = "India Pale Ale",
                    ABV = 7.7,
                    IBUs = 75,
                    Description = @"While our beers are many and diverse, yet unified by overarching boldness, India pale ales are our undeniable bread and butter. The result is an intensely citrusy, beautifully bitter beer is worthy of the simple-yet-lordly title of Stone Delicious IPA. Lemondrop and El Dorado hops combine to bring on a magnificent lemon candy-like flavor that’s balanced by hop spice. It’s unlike anything we’ve tasted in nearly two decades of IPA experimentation, and another lupulin-laced creation we’re excited to present to hopheads everywhere.",
                    Brewer = stoneBrewing
                });
                realm.Add(new Beer()
                {
                    Name = "STONE RUINATION DOUBLE IPA 2.0",
                    Style = "India Pale Ale",
                    ABV = 8.5,
                    IBUs = 100,
                    Description = @"Stone Ruination IPA was the first full-time brewed and bottled West Coast double IPA on the planet. As craft beer has evolved over the years, so too have techniques for maximizing hop flavors and aromas. For the second incarnation of our groundbreaking India pale ale, we employ dry hopping and hop bursting to squeeze every last drop of piney, citrusy, tropical essence from the hops that give this beer its incredible character. We’ve also updated the name to Stone Ruination Double IPA 2.0 to reflect the imperial-level intensity that’s evident in every sip. Join us in cheering this, the second stanza in our “Liquid Poem to the Glory of the Hop.”",
                    Brewer = stoneBrewing
                });

                var ballastPoint = realm.All<Brewer>().First(b => b.Name == BallastPoint);
                realm.Add(new Beer()
                {
                    Name = "MANTA RAY",
                    Style = "India Pale Ale",
                    ABV = 8.5,
                    IBUs = 70,
                    Description = "We’ve developed many IPA recipes in our R&D program, but right from the tank, our Manta Ray Double IPA was a winner. Aromas of fresh, citrusy tangerine, melon and light pine leap from the beer and linger over a smooth finish. Like its namesake, this brew can sneak up on you – a big beer without a bite.",
                    Brewer = ballastPoint
                });

                realm.Add(new Beer()
                {
                    Name = "SEA ROSE TART",
                    Style = "Wheat Ale",
                    ABV = 4,
                    IBUs = 8,
                    Description = "Our Sea Rose tart cherry wheat ale is a fresh take on fruit beers. Originally conceived during an employee-led R&D brew, it’s one of our most imaginative recipes yet. The American wheat style is light and clean, while fresh cherry juice adds a soft coral color and fruity nose that gives way to a dry, slightly tart finish. It’s approachable, yet unexpected—exactly what we love to brew.",
                    Brewer = ballastPoint
                });
                realm.Add(new Beer()
                {
                    Name = "SCULPIN",
                    Style = "India Pale Ale",
                    ABV = 7,
                    IBUs = 70,
                    Description = "Our Sculpin IPA is a great example of what got us into brewing in the first place. After years of experimenting, we knew hopping an ale at five separate stages would produce something special. The result ended up being this gold-medal winning IPA, whose inspired use of hops creates hints of apricot, peach, mango and lemon flavors, but still packs a bit of a sting, just like a Sculpin fish.",
                    Brewer = ballastPoint
                });
                realm.Add(new Beer()
                {
                    Name = "MOCHA MARLIN",
                    Style = "Porter",
                    ABV = 6,
                    IBUs = 42,
                    Description = "Our Black Marlin Porter is the perfect beer for a mocha mashup. The addition of coffee and cocoa plays perfectly off the roasty, chocolaty flavors of this English porter, while a hint of vanilla smooths it all out. It’s full-bodied, but not too sweet; try it for breakfast…or dessert.",
                    Brewer = ballastPoint
                });
                realm.Add(new Beer()
                {
                    Name = "PEPPERMINT VICTORY AT SEA",
                    Style = "Porter",
                    ABV = 10,
                    IBUs = 60,
                    Description = "This Peppermint Victory at Sea is a festive take on our popular Imperial Porter. We took our trademark robust porter brewed with Caffe Calabria coffee and vanilla and added a dose of refreshing peppermint. The trio of flavors play perfectly on your palate – the brew’s sweet roasting balances nicely with a cool, minty finish.",
                    Brewer = ballastPoint
                });

            }
            transaction.Commit();
        }
    }
}
