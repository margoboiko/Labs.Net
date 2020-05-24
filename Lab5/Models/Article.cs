
using System;
using Lab5.Interfaces;

namespace Lab5.Models
{
    [Serializable]
    internal class Article : IRateAndCopy
    {
        public Person _Author { get; set; }
        public string _Title { get; set; }
        public double _Rating { get; set; }

        public string Raiting { get; set; }

        public Article() : this(new Person(), "New Article", 0)
        {
        }

        public Article(Person author, string title, double rating)
        {
            _Author = author;
            _Title = title;
            _Rating = rating;
        }

        public override string ToString()
        {
            return string.Format("Author: \n {0},\n  Title: {1},\n  Rating: {2}", _Author, _Title, _Rating);
        }

        public virtual object DeepCopy()
        {
            return MemberwiseClone();
        }

        protected bool Equals(Article other)
        {
            return Equals(_Author, other._Author) && string.Equals(_Title, other._Title) && _Rating.Equals(other._Rating);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Article)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_Author != null ? _Author.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_Title != null ? _Title.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ _Rating.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(Article left, Article right)
        {
            return ReferenceEquals(left, right);
        }

        public static bool operator !=(Article left, Article right)
        {
            return !ReferenceEquals(left, right);
        }
    }
}