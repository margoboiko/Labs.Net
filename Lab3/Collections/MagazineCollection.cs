using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace lr3
{
    internal class MagazineCollection
    {
        public List<Magazine> Magazines { get; set; }
      
        /*public MagazineCollection() : this(new List<Magazine>())
        {          
        }

        public MagazineCollection(List<Magazine> _magazines)
        {
            Magazines = _magazines;
        }*/

        //метод void AddDefaults(), за допомогою якого в список List<Magazine> можна додати 
        //деяке число елементів типу Magazine для ініціалізації колекції за замовчуванням
        public void AddDefaults()
        {
            Magazines = new List<Magazine>();
            Magazine fullMagazine = new Magazine(new Edition("name33", DateTime.Now, 123), "name1", Frequency.Montly, DateTime.Now, 10, 
                new List<Person>
                {
                    new Person(), new Person()
                }, 
                new List<Article>
                {
                    new Article(new Person(), "1", 50 ), new Article(new Person(), "2", 80 )
                });
            Magazines.Add(fullMagazine);
            Magazines.Add(new Magazine());            
            Magazines.Add(fullMagazine);
        }

        //метод void AddMagazines(params Magazine[]) для додавання елементів в список List<Magazine>
        public void AddMagazines(params Magazine[] magazines)
        {
            Magazines = new List<Magazine>();
            foreach (var magazine in magazines)
            {
                Magazines.Add(magazine);
            }
        }

        //властивість типу double (тільки для читання), що повертає максимальне значення середнього рейтингу статей для елементів списку List<Magazine>;
        //якщо в колекції немає елементів, властивість повертає деяке значення за замовчуванням; для пошуку максимального значення середнього рейтингу статей
        //потрібно використати метод Max класу System.Linq.Enumerable;
        public double GetMaxAverageRate()
        {           
            return Magazines.Count != 0 ? Magazines.Select(x => x.AverageRate).Max() : 0;
        }

        //властивість типу IEnumerable<Magazine> (тільки для читання), яке повертає підмножину елементів 
        //списку List<Magazine> з періодичністю виходу журналу Frequency.Monthly;
        //для формуванння підмножини використати метод Where класу System.Linq.Enumerable;
        public IEnumerable<Magazine> GetMontlyMagazines()
        {
            return Magazines.Where(x => x.Period == Frequency.Montly);
        }

        //метод List<Magazine> RatingGroup(double value), що повертає список, який містить елементи Magazine з List<Magazine> з середнім рейтингом статей;
        //який для формування списку використати методи Group та ToList класу System.Linq.Enumerable.
        public List<Magazine> GetRatingGroup(double value)
        {
            return Magazines.Where(x => x.AverageRate >= value).ToList();
        }

        //сортування по назві видання з використанням інтерфейсу IComparable, реалізованого в класі Edition
        public void SotrByEditName()
        {
            Magazines.Sort();
        }

        //сортування по даті виходу видання з викристанням інтерфейсу IComparer<Edition>, реалізованого в класі Edition
        public void SortByEdDate()
        {
           Magazines.Sort(new Edition().Compare);
        }

        //сортування по тиражу видання з використанням інтерфейсу IComparer<Edition>, реалізованого в допоміжному класі
        public void SortByEdit()
        {
            Magazines.Sort(new EditionCompare().Compare);  
        }
        
        //перезавантажену версію віртуального метода string ToString() для формування рядка з інформацією про всі
        //елементи списку List<Magazine>, в тому числі значення всіх полів, список редакторів журналу та список статей 
        //в журналі для кожного елементу Magazine

        public override string ToString()
        {
            string magazineData = "";
            foreach (Magazine magazine in Magazines)
            {
                magazineData += magazine.ToString() + "\n";
            }
            return magazineData;
        }

        //віртуальний метод string ToShortList(), який формує рядок з інформацією про всі елементи списку List<Magazine>, 
        //який містить значення всіх полів, середній рейтинг статей, число редакторів журналу та число статей для кожного елементу Magazine,
        //але без списку редакторів та статей
        public virtual string ToShortString()
        {
            string data = "";
            foreach (Magazine magazine in Magazines)
            {
                data += magazine.ToShortString() + 
                     "Середній рейтинг статей:" + magazine.AverageRate + "\n"
                    +"К-сть учасникiв: " + magazine.PersonsList.Count + "\n"
                    + "К-сть публiкацiй: " + magazine.ArticleList.Count + "\n\n";

            }
            return data;
        }
    }
}