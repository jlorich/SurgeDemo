using System;
using System.Collections.Generic;

namespace SurgeConsole
{
    public class Person {
        public Person Father;

        public Person Mother;

        public string Name;

        public string FavoriteIceCreamFlavor;

        public IEnumerable<Person> Ancestors(bool includeSelf = false) {
            return GetAncestors(this, includeSelf);
        }

        public static IEnumerable<Person> GetAncestors(Person person, bool includeSelf = false) {
          if (person == null) {
           yield break;
          }

          var maternalAncestors = GetAncestors(person.Mother, true);
          var paternalAncestors = GetAncestors(person.Father, true);

          foreach (var ancestor in maternalAncestors) {
            yield return ancestor;
          }

          foreach (var ancestor in paternalAncestors) {
            yield return ancestor;
          }

          if (includeSelf) {
            yield return person;
          }
        }
    }
}