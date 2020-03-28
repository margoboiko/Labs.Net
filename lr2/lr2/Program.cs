using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr2
{
    class Program
    {
        static void Main(string[] args)
        {

            Edition ed1, ed2;
            ed1 = new Edition("Viva", new DateTime(2020, 11, 26), 124765);
            ed2 = new Edition("Forbs", new DateTime(2019, 01, 10), 187654);
            Console.WriteLine((ed1 == ed2));
            Console.WriteLine((ed1 as object == ed2 as object));
            Console.WriteLine("Hash:" + ed1.GetHashCode().ToString() + " // " + ed2.GetHashCode().ToString());
            Console.WriteLine();

            Console.WriteLine("\n\n");
            try
            {
                ed1.Edit = -1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }



            Console.WriteLine("\n\n");
            Magazine magazine = new Magazine();

            var person = new Person[]
            {
                new Person("Marharyta", "Boiko", new DateTime(2000, 03, 23)),
                new Person("Xenia", "Dolgan", new DateTime(1999, 11, 26)),
            };

            magazine.AddEditors(new Person(), new Person());
            magazine.AddArticles(new Article(), new Article());
            Console.WriteLine(magazine.ToString());

            Console.WriteLine("\n\n");
            Console.WriteLine(magazine.Edition.ToString());

            Console.WriteLine("\n\n");
            Magazine magazine1 = new Magazine();
            magazine1 = magazine.DeepCopy() as Magazine;

            magazine.NameTitle = "Cosmopolitan";

            Console.WriteLine("Magazine1: " + magazine.ToString() + "\n");
            Console.WriteLine("Magazine2: " + magazine1.ToString() + "\n");

            Console.WriteLine("\n\n");
            double moreThan = 10;
            Console.WriteLine("\nArticleRage more than " + moreThan + " : ");
            ((Article)magazine.Articles[0]).Rating = 9;
            foreach (var article in magazine.GetArticlesMoreThan(moreThan))
            {
                Console.WriteLine(article);
            }

            Console.WriteLine("\n\n");
            string searchText = "New";
            Console.WriteLine("\nArticleName with " + searchText + " : ");
            foreach (var article in magazine.GetArticlesWithText(searchText))
            {
                Console.WriteLine(article);
            }

            Console.ReadKey();
            Console.WriteLine("\n\n\n------------\nS U C C E S S\n----------\n\n\n");
        }
    }
}