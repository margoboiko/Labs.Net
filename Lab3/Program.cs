  using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace lr3
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            //створення об'єкту типу MagazineCollection, додання в колекцію декілька елементів типу Magazine з різними значеннями полів
            MagazineCollection magazineCollection = new MagazineCollection();
            magazineCollection.AddMagazines(
                    TestCollections.GetMegazine(3),
                    TestCollections.GetMegazine(5),
                    TestCollections.GetMegazine(1),
                    TestCollections.GetMegazine(4),
                    TestCollections.GetMegazine(2)
                );
            
            Console.WriteLine("magazineCollection default: \n {0}\n", string.Join(" ; ", magazineCollection.Magazines.Select(x => x._NameTitle).ToArray()) );
           
            //сортування за назвою
            magazineCollection.SotrByEditName();
            Console.WriteLine("Sorted by Name: \n {0}\n", string.Join(" ; ", magazineCollection.Magazines.Select(x => x._NameTitle).ToArray()) );
            
            //сортування за датою
            magazineCollection.SortByEdDate();
            Console.WriteLine("Sorted by Date: \n {0}\n", string.Join(" ; ", magazineCollection.Magazines.Select(x => x._NameTitle).ToArray()) );
            
            //сортування за тиражом
            magazineCollection.SortByEdit();
            
            Console.WriteLine("Sorted by Edit: \n {0}\n", string.Join(" ; ", magazineCollection.Magazines.Select(x => x._NameTitle).ToArray()) );
            
            //обчислення максимального значення середнього рейтингу статей для елементів списку
            Console.WriteLine("Maximum average rate: {0}\n", magazineCollection.GetMaxAverageRate());
            
            //фільтрація списку для відбору журналів з періодичністю виходу Frequency.Monthly
            Console.WriteLine("Magazines with Frequency = Monthly:\n {0}\n",
                string.Join(" ; ", magazineCollection.GetMontlyMagazines().Select(x => x.NameTitle).ToArray()));

            //групування елементів списку за значенням середнього рейтингу статей
                double value = 4         ;
            Console.WriteLine("Edition with average score more than {0}:\n {1}\n", value,
                string.Join(" ; ", magazineCollection.GetRatingGroup(value).Select(x => x.NameTitle).ToArray()));
            
            //об'єкт типу TestCollections
            TestCollections test = new TestCollections(10);
            Console.WriteLine("Searching time:");
            test.MeasureTime();
            Console.ReadKey();
        }
    }
}