using System;
using System.Collections.Generic;
using System.Text;

namespace lr2
{
    class Article: IRateAndCopy
    {
        public Person _Author;
        public string _Title;
        public double _Rating;

        public Article(Person author, string title, double rating)
        {
            _Author = author;
            _Title = title;
            _Rating = rating;
        }

        public Article() { }

        public Person Author
        {
            get
            { return _Author; }
            set
            { _Author = value; }
        }

        public string Title
        {
            get
            { return _Title; }
            set
            { _Title = value; }
        }

        public double Rating
        {
            get
            { return _Rating; }
            set
            { _Rating = value; }
        }

        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override string ToString()
        {
            return _Author + " " + _Title + "\n" + _Rating;
        }

        //визначити віртуальний метод object DeepCopy()
        public object DeepCopy()
        {
            Article _artCopy = new Article(_Author, _Title, _Rating);
            return _artCopy as object;
        }
    }
}
