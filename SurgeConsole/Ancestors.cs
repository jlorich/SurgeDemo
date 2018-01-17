using System;
using System.Collections.Generic;
using System.Linq;

namespace SurgeConsole {
    public static class Ancestors {
        public static List<String> GetAncestorNames(Person person) {
            return person.Ancestors().Select(a=> a.Name).ToList();
        }

        public static string GetMostPopularIceCreamInfamily(Person person) {
            var ancestors = person.Ancestors(true);

            var popularIceCream = new Dictionary<string, int>();

            var mostPopular = ancestors.Aggregate("", (popular, currentPerson) => {
                var flavor = currentPerson.FavoriteIceCreamFlavor;
                
                popularIceCream.TryGetValue(flavor, out int count);
                popularIceCream[currentPerson.FavoriteIceCreamFlavor] = count + 1;
                return popular != "" && popularIceCream[popular] > count + 1 ? popular : flavor; 
            });

            return mostPopular;
        }
    }
}