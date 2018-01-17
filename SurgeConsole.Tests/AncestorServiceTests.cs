using System;
using Xunit;
using SurgeConsole;
using System.Linq;

namespace SurgeConsole.Tests
{
    public class AncestorServiceTests
    {
        private Person BuildPersonWithFamily() {
            var grandma = new Person {
              Name = "leona",
              FavoriteIceCreamFlavor = "chocolate"
            };

            var mom = new Person {
              Name = "kerry",
              Mother = grandma,
              FavoriteIceCreamFlavor = "chocolate"
            };

            var grandpa = new Person {
              Name = "louis",
              FavoriteIceCreamFlavor = "strawberry"
            };

            var dad = new Person() {
              Name = "mike",
              Father = grandpa,
              FavoriteIceCreamFlavor = "strawberry"
            };

            var me = new Person {
              Name = "joey",
              Mother = mom,
              Father = dad,
              FavoriteIceCreamFlavor = "chocolate"
            };

            return me;
        }

        [Fact]
        public void TestGetAncestorNames()
        {
            var service = new AncestorService();
            var person = BuildPersonWithFamily();

            var ancestorNames = service.GetAncestorNames(person);
            
            
            Assert.Equal(4, ancestorNames.Count());
            Assert.Contains("louis", ancestorNames);
            Assert.Contains("leona", ancestorNames);
            Assert.Contains("mike", ancestorNames);
            Assert.Contains("kerry", ancestorNames);

            Assert.DoesNotContain("joey", ancestorNames);
        }

        [Fact]
        public void TestGetMostPopularIceCreamInfamily()
        {
            var service = new AncestorService();
            var person = BuildPersonWithFamily();

            var iceCream = service.GetMostPopularIceCreamInfamily(person);
            
            Assert.Equal("chocolate", iceCream);
        }
    }
}
