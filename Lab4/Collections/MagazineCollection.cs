using System;
using System.Collections.Generic;
using System.Linq;
using Lab4.DelegateClass;

namespace Lab4.Collections
{
    internal class MagazineCollection
    {
        public delegate void MagazineListHandler(object source, MagazineListHandlerEventArgs args);

        public event MagazineListHandler MagazineAdded; //генерується при додаванні елементу в колекцію
        public event MagazineListHandler MagazineReplaced; //генерується, коли одному з посилань присвоюється нове значення
        
        public List<Magazine> Magazines { get; set; }
        public string CollectionName { get; set; } //публічна автовластивість типу string з назвою колекції

        public MagazineCollection()
        {
            Magazines = new List<Magazine>();
            CollectionName = "NoName";
        }

        //метод bool Replace(int j, Magazine magazine) для заміни елемента з номером j зі списку List<Magazine> на елемент magazine
        //якщо в списку немає елементу з номером j, метод повертає значення false
        public bool Replace(int j, Magazine magazine)
        {
            if (Magazines.Count > j)
            {
                Magazines[j] = magazine;
                if (MagazineReplaced != null)
                    MagazineReplaced(this, new MagazineListHandlerEventArgs(CollectionName, "Element was replaced by Replace", j));
                return true;
            }
            return false;
        }
        
        public void AddDefaults()
        {
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
            if (MagazineAdded != null)
                MagazineAdded(this, new MagazineListHandlerEventArgs(CollectionName,"Element was added by AddDEfaults",Magazines.Count - 1));
            Magazines.Add(new Magazine());
            if (MagazineAdded != null)
                MagazineAdded(this, new MagazineListHandlerEventArgs(CollectionName,"Element was added by AddDEfaults",Magazines.Count - 1));
            Magazines.Add(fullMagazine);
            if (MagazineAdded != null)
                MagazineAdded(this, new MagazineListHandlerEventArgs(CollectionName,"Element was added by AddDEfaults",Magazines.Count - 1));
        }

        public void AddMagazines(params Magazine[] magazines)
        {
            foreach (var magazine in magazines)
            {
                Magazines.Add(magazine);
                if (MagazineAdded != null)
                    MagazineAdded(this, new MagazineListHandlerEventArgs(
                        CollectionName,
                        "Element was added by AddMagazines",
                        Magazines.Count - 1));
            }
        }

        public double GetMaxAverageRate()
        {
            return Magazines.Count != 0 ? Magazines.Select(x => x.AverageRate).Max() : 0;
        }

        public IEnumerable<Magazine> GetMontlyMagazines()
        {
            return Magazines.Where(x => x.Period == Frequency.Montly);
        }

        public List<Magazine> GetRatingGroup(double value)
        {
            return Magazines.Where(x => x.AverageRate >= value).ToList();
        }

        public void SortByEditName()
        {
            Magazines.Sort();
        }

        public void SortByEdDate()
        {
           Magazines.Sort(new Edition().Compare);
        }

        public void SortByEdit()
        {
            Magazines.Sort(new EditionCompare().Compare);  
        }

        //індексатор типу Magazine з цілочисельним індексом для доступу до елементу з заданим номером
        public Magazine this[int index]
        {
            get { return Magazines[index]; }
            set
            {
                Magazines[index] = value;
                if (MagazineReplaced != null)
                    MagazineReplaced(this,
                        new MagazineListHandlerEventArgs(CollectionName, "Element was replaced by indexator", index));
            }
        }

        public override string ToString()
        {
            string magazineData = "";
            foreach (Magazine magazine in Magazines)
            {
                magazineData += magazine.ToString() + "\n";
            }
            return magazineData;
        }

        public virtual string ToShortString()
        {
            string data = "";
            foreach (Magazine magazine in Magazines)
            {
                data += magazine.ToShortString() +
                     "Середній рейтинг статей:" + magazine.AverageRate + "\n"
                    + "К-сть учасникiв: " + magazine.PersonsList.Count + "\n"
                    + "К-сть публiкацiй: " + magazine.ArticleList.Count + "\n\n";

            }
            return data;
        }

    }
}