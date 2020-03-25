using System;
using System.Collections.Generic;
using System.Text;

namespace lr1
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
        { get
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
    }
}
