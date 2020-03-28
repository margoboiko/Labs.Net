using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr2
{
    class Person
    {
        private string _Name;
        private string _Surname;
        private System.DateTime _DataBirth;

        public Person(string name, string surname, DateTime dataBirth)
        {
            _Name = name;
            _Surname = surname;
            _DataBirth = dataBirth;
        }

        public Person() { }

        public string Name
        {
            get
            { return _Name; }
            set
            { _Name = value; }
        }

        public string Surname
        {
            get
            { return _Surname; }
            set
            { _Surname = value; }
        }

        public DateTime DataBirth
        {
            get
            { return _DataBirth; }
            set
            { _DataBirth = value; }
        }

        public int Birth
        {
            get
            { return _DataBirth.Year; }
            set
            { _DataBirth = new DateTime(value, _DataBirth.Month, _DataBirth.Day); }
        }

        public override string ToString()
        {
            return _Name + " " + _Surname + "\n" + _DataBirth;
        }

        public virtual string ToShortString()
        {
            return _Name + " " + _Surname;
        }

        //перевизначенний вітуальний метод bool Equals(object obj)
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Person person = obj as Person;
            return person._Name == _Name
                && person._Surname == _Surname
                && person._DataBirth == _DataBirth;
        }

        //перевизначити операцію ==
        public static bool operator == (Person p1, Person p2)
        {
            return p1._Name == p2._Name
                && p1._Surname == p2._Surname
                && p1._DataBirth == p2._DataBirth;
        }

        //перевизначити операцію !=
        public static bool operator !=(Person p1, Person p2)
        {
            return p1._Name != p2._Name
                && p1._Surname != p2._Surname
                && p1._DataBirth != p2._DataBirth; ;
        }

        //перевизначити віртуальний метод int GetHashCode();
        public override int GetHashCode()
        {
            return HashCode.Combine(_Name, _Surname, _DataBirth);
        }

        //визначити віртуальний метод object DeepCopy()
        public object DeepCopy()
        {
            Person _Copy = new Person(_Name, _Surname, _DataBirth);
            return _Copy as object;
        }
    }
}