using System;
using System.Collections.Generic;
using Lab5.Interfaces;

namespace Lab5.Models
{
    [Serializable]
    internal class Edition : IRateAndCopy, IComparable, IComparer<Edition>
    {
        public string _NameTitle { get; set; }
        public DateTime _DateEdit { get; set; }
        private int _Circulation;
        public int Circulation
        {
            get { return _Circulation; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Circulation must be more then 0");
                }

                _Circulation = value;
            }
        }

        public string Raiting { get; set; }

        public Edition() : this("Edition name", DateTime.Today, 1) { }

        public Edition(string nameTitle, DateTime dateEdit, int circulation)
        {
            _NameTitle = nameTitle;
            _DateEdit = dateEdit;
            Circulation = circulation;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Edition otherEdition = obj as Edition;
            if (otherEdition != null)
                return String.Compare(_NameTitle, otherEdition._NameTitle, StringComparison.Ordinal);
            throw new ArgumentException("Object is not a Edition");
        }

        public int Compare(Edition x, Edition y)
        {
            if (x._DateEdit.CompareTo(y._DateEdit) != 0)
            {
                return x._DateEdit.CompareTo(y._DateEdit);
            }

            return 0;
        }

        public override string ToString()
        {
            return string.Format("NameTitle: {0}, DateEdit: {1}, Circulation: {2}", _NameTitle, _DateEdit.ToShortDateString(), Circulation);
        }

        public virtual object DeepCopy()
        {
            return MemberwiseClone();
        }

        protected bool Equals(Edition other)
        {
            return string.Equals(_NameTitle, other._NameTitle) && _DateEdit.Equals(other._DateEdit) && Circulation == other.Circulation;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Edition)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_NameTitle != null ? _NameTitle.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ _DateEdit.GetHashCode();
                hashCode = (hashCode * 397) ^ Circulation;
                return hashCode;
            }
        }

        public static bool operator ==(Edition left, Edition right)
        {
            return ReferenceEquals(left, right);
        }

        public static bool operator !=(Edition left, Edition right)
        {
            return !ReferenceEquals(left, right);
        }
    }
}