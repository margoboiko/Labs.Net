using System;

namespace Lab5.Models
{
    [Serializable]
    internal class Person
    {
        private string _Name;
        private string _Surname;
        private DateTime _DataBirth;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string Surname
        {
            get { return _Surname; }
            set { _Surname = value; }
        }

        public DateTime DataBirthday
        {
            get { return _DataBirth; }
            set { _DataBirth = value; }
        }

        public int DataBirthdayYear
        {
            get { return _DataBirth.Year; }
            set { _DataBirth = new DateTime(value, _DataBirth.Month, _DataBirth.Day); }
        }

        public Person() : this("default Name", "default Surname", new DateTime())
        {
        }

        public Person(string name, string surname, DateTime dataBirth)
        {
            _Name = name;
            _Surname = surname;
            _DataBirth = dataBirth;
        }

        public override string ToString()
        {
            return string.Format("  Name: {0},\n   Surname: {1},\n   DataBirthday: {2}", _Name, _Surname, _DataBirth.ToShortDateString());
        }

        public string ToShortString()
        {
            return string.Format("Name: {0}, Surname: {1}", _Name, _Surname);
        }

        public virtual object DeepCopy()
        {
            return MemberwiseClone();
        }

        protected bool Equals(Person other)
        {
            return string.Equals(_Name, other._Name) && string.Equals(_Surname, other._Surname) && _DataBirth.Equals(other._DataBirth);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Person)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_Name != null ? _Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_Surname != null ? _Surname.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ _DataBirth.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(Person left, Person right)
        {
            return ReferenceEquals(left, right);
        }

        public static bool operator !=(Person left, Person right)
        {
            return !ReferenceEquals(left, right);
        }
    }
}