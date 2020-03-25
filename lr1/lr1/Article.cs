using System;
using System.Collections.Generic;
using System.Text;

namespace lr1
{
    class Article
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

        public override string ToString()
        {
            return _Author + " " + _Title + "\n" + _Rating;
        }
    }
}
