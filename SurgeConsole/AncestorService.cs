using System;
using System.Collections.Generic;
using System.Linq;

namespace SurgeConsole
{
    public class AncestorService
    {

        // Iterates over all ancestors for a person.  Can also optionally include that person.
        // ---
        // Building an iterator to go through the family history should be performant and is reusable between
        // both the names and ice cream problems
        public IEnumerable<Person> GetAncestors(Person person, bool includeSelf = false)
        {
            if (person == null)
            {
                yield break;
            }

            var maternalAncestors = GetAncestors(person.Mother, true);
            var paternalAncestors = GetAncestors(person.Father, true);

            foreach (var ancestor in maternalAncestors)
            {
                yield return ancestor;
            }

            foreach (var ancestor in paternalAncestors)
            {
                yield return ancestor;
            }

            if (includeSelf)
            {
                yield return person;
            }
        }

        public List<String> GetAncestorNames(Person person)
        {
            return GetAncestors(person).Select(a => a.Name).ToList();
        }

        public string GetMostPopularIceCreamInfamily(Person person)
        {
            var ancestors = GetAncestors(person, true);

            var popularIceCream = new Dictionary<string, int>();
            string mostPopular = null;
            int mostPopularCount = 0;

            foreach(var currentPerson in ancestors) {
                var flavor = currentPerson.FavoriteIceCreamFlavor;

                popularIceCream.TryGetValue(flavor, out int count);
                popularIceCream[currentPerson.FavoriteIceCreamFlavor] = count + 1;

                if (count + 1 > mostPopularCount) {
                    mostPopular = flavor;
                    mostPopularCount = count + 1;
                }
            }

            return mostPopular;
        }
    }
}