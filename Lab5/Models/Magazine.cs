using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Lab5.Enum;

namespace Lab5.Models
{
    [Serializable]
    internal class Magazine: Edition
    {
        private string _nameTitle;
        private Frequency _Period;
        private DateTime _DateEdition;
        private int _Edit;
        private List<Person> _personsList;
        private List<Article> _articleList;

        public double AverageRate
        {
            get
            {
                double allRanges = 0;
                foreach (Article article in ArticleList)
                {
                    allRanges += article._Rating;
                }
                return allRanges / ArticleList.Count;
            }
        }


        public Edition Edition
        {
            get { return new Edition(_NameTitle, _DateEdit, Circulation); }
            set
            {
                _NameTitle = value._NameTitle;
                _DateEdition = value._DateEdit;
                Circulation = value.Circulation;
            }
        }

        public string NameTitle
        {
            get { return _nameTitle; }
            set { _nameTitle = value; }
        }

        public Frequency Period
        {
            get { return _Period; }
            set { _Period = value; }
        }

        public DateTime DateEdition
        {
            get { return _DateEdition; }
            set { _DateEdition = value; }
        }

        public int Edit
        {
            get { return _Edit; }
            set { _Edit = value; }
        }

        public List<Person> PersonsList
        {
            get { return _personsList; }
            set { _personsList = value; }
        }

        public List<Article> ArticleList
        {
            get { return _articleList; }
            set { _articleList = value; }
        }

        public bool this[Frequency frequency]
        {
            get { return _Period == frequency; }
        }

        public Magazine() : this(new Edition(), "default name", Frequency.Weekly, new DateTime(), 0,
            new List<Person> { new Person() }, new List<Article> { new Article() })
        {
        }

        public Magazine(Edition edition, string nameTitle, Frequency period, DateTime DateEdition,
            int Edit, List<Person> personsList, List<Article> articleList)
            : base(edition._NameTitle, edition._DateEdit, edition.Circulation)
        {
            _nameTitle = nameTitle;
            _Period = period;
            _DateEdition = DateEdition;
            _Edit = Edit;
            _personsList = personsList;
            _articleList = articleList;
        }

        public void AddArticles(params Article[] article)
        {
            if (article != null)
            {
                ArticleList.AddRange(article);
            }
        }

        public void AddEditors(params Person[] person)
        {
            if (person != null)
            {
                PersonsList.AddRange(person);
            }
        }

        public IEnumerable GetArticlesMoreThan(double lowValue)
        {
            foreach (Article article in ArticleList)
            {
                if (article._Rating > lowValue)
                {
                    yield return article;
                }
            }
        }

        public IEnumerable GetArticlesWithText(string text)
        {
            foreach (Article article in ArticleList)
            {
                if (article._Title.Contains(text))
                {
                    yield return article;
                }
            }
        }

        //bool AddFromConsole() для додавання в один зі списків класу нового елементу, дані для якого вводяться з консолі
        public bool AddFromConsole()
        {
            try
            {
                Console.WriteLine("Hello, you can enter here Article in format:\n" +
                                  "Name Surname DataBirthday(dd.mm.yyyy) NameTitle Rating,   " +
                                  "use space as text split");
                string[] input = Console.ReadLine().Split(' ');
             /*   if (input.Length % 5 != 0)
                {
                    throw new Exception("Input Error");
                }*/

                int i = 0;
                while (i < input.Length)
                {
                    string name = input[i++];
                    string surname = input[i++];
                    DateTime dataBirth = DateTime.ParseExact(input[i++], "dd.MM.yyyy", null);
                    string title = input[i++];
                    int rating = Int32.Parse(input[i++]);
                    
                    AddArticles(new Article(new Person(name, surname, dataBirth), title, rating));
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        // bool Save(string filename) для збереження даних об'єкту в файлі за допомогою серіалізації
        //якщо файл з іменем filename існує, він перезаписується, якщо ж його немає, то він має бути створений
        //метод повертає значення true, якщо десеріалізація відбулася успішно та false в протилежному випадку
        public bool Save(string filename)
        {
            try
            {
                using (FileStream stream = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, this);                 
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }                       
        }

        //bool Load(string filename) для ініціалізації об'єкту даними з файлу за допомогою десеріалізації
        //метод повертає значення true, якщо повністю виконати десеріалізацію об'єкту не вдалося, вихідні дані об'єкту
        //повинні залишитися без змін. В цьому випадку повертає значення false
        public bool Load(string filename)
        {

            using (FileStream stream = new FileStream(filename, FileMode.Open))
            {
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    Magazine magazine = (Magazine)formatter.Deserialize(stream);
                    
                    _nameTitle = magazine.NameTitle;
                    _Period = magazine.Period;
                    _DateEdition = magazine.DateEdition;
                    _Edit = magazine.Edit;
                    _articleList = magazine.ArticleList;
                    _personsList = magazine.PersonsList;
                    this.Edition = magazine.Edition;
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
                            
            }
        }

        //static bool Save(string filename, T object) для збереження в файлі за допомогою серіалізації
        public static bool Save(string filename, Magazine obj)
        {
            return obj.Save(filename);
        }

        //static bool Load(string filename, T object) для відновлення об'єкту з файлу за допомогою десеріалізації
        public static bool Load(string filename, Magazine obj)
        {
            return obj.Load(filename);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var article in ArticleList)
            {
                stringBuilder.AppendLine(article.ToString());
            }
            stringBuilder.AppendLine("Persons:");
            foreach (var person in PersonsList)
            {
                stringBuilder.AppendLine(person.ToString());
            }
            return string.Format(
                " NameTitle: {0},\n Period: {1},\n DateEdition: {2},\n Article: {3},\n AverageRate: {4}\n",
                NameTitle, Period, DateEdition.ToShortDateString(), stringBuilder, AverageRate);
        }

        public virtual string ToShortString()
        {
            return string.Format(" NameTitle: {0},\n Period: {1},\n DateEdition: {2},\n AverageRate: {3}\n",
                NameTitle, Period, DateEdition.ToShortDateString(), AverageRate);
        }

        //T DeepCopy() для створення повної копії об'єкту з використанням серіалізації
        //метод повертає відновлений при десеріалізації об'єкт, який представляє собою повну копію об'єкту оригіналу
        public override object DeepCopy()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                if (this.GetType().IsSerializable)
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, this);
                    stream.Position = 0;
                    return formatter.Deserialize(stream);
                }
                return null;
            }
        }

        protected bool Equals(Magazine other)
        {
            return string.Equals(_nameTitle, other._nameTitle) && _Period == other._Period &&
                   _DateEdition.Equals(other._DateEdition) && _Edit == other._Edit &&
                   _articleList.SequenceEqual(other._articleList) && _personsList.SequenceEqual(other._personsList);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Magazine)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_nameTitle != null ? _nameTitle.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)_Period;
                hashCode = (hashCode * 397) ^ _DateEdition.GetHashCode();
                hashCode = (hashCode * 397) ^ _Edit;
                hashCode = (hashCode * 397) ^ (_articleList != null ? _articleList.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(Magazine left, Magazine right)
        {
            return ReferenceEquals(left, right);
        }

        public static bool operator !=(Magazine left, Magazine right)
        {
            return !ReferenceEquals(left, right);
        }
    }
}