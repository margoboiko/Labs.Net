using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr2
{
    class Edition
    {
        protected string _NameTitle; //назва видання
        protected DateTime _DateEdition; //дата виходу видання
        protected int _Edit; //тираж видання

        //конструктор з параметрами типу string, DataTime, int для ініціалізації відповідних полів класу
        public Edition(string nameTitle, DateTime dateEdition, int edit)
        {
            _NameTitle = nameTitle;
            _DateEdition = dateEdition;
            _Edit = edit;
        }

        //конструктор без параметрів для ініціалізації по замовчуванню
        public Edition() { }

        //властивість з методами get і set для доступу до полів типу
        public string NameTitle
        {
            get
            {  return _NameTitle;  }

            set
            {  _NameTitle = value;  }
        }

        public DateTime DateEdition
        {
            get
            { return _DateEdition; }

            set
            { _DateEdition = value; }
        }

        //визначити віртуальний метод object DeepCopy()
        public object DeepCopy()
        {
            Edition _edCopy = new Edition(_NameTitle, _DateEdition, _Edit);
            return _edCopy;
        }

        //властивість типу int з методами get i set для доступу до поля з тиражом видання; в методі set властивість генерує виключну ситуацію,
        //якщо значення, яке присвоюється, від'ємне. При створенні виключної ситуації використ один із визначених в бібліотеці CLR 
        //класів-виключень, ініціалізувати цей об'єкт за допомогою конструктора з параметром типу string
        public int Edit
        {
            get
            {  return _Edit;  }
            set
            {
                try
                {
                    if (value <= 0)
                        throw new ArgumentOutOfRangeException();
                }
                catch
                {
                    Console.WriteLine("Write positive number!");
                }

                _Edit = value;
            }
        }

        //реалізувати інтерфейс IRateAndCopy


        //віртуальний метод virtual bool Equals(object obj)
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Edition edition = obj as Edition;
            return edition._NameTitle == _NameTitle
                && edition._DateEdition == _DateEdition
                && edition._Edit == _Edit;
        }

        //визначити операцію ==
        public static bool operator == (Edition ed1, Edition ed2)
        {
            return ed1._NameTitle == ed2._NameTitle 
                && ed1._DateEdition == ed2._DateEdition
                && ed1._Edit == ed2._Edit;
        }

        //визначити операцію !=
        public static bool operator != (Edition ed1, Edition ed2)
        {
            return ed1._NameTitle != ed2._NameTitle
                && ed1._DateEdition != ed2._DateEdition
                && ed1._Edit != ed2._Edit;
        }

        //перевизначити віртуальний метод int GetHashCode()
        public override int GetHashCode()
        {
            return HashCode.Combine(_NameTitle, _DateEdition, _Edit);

        }

        //віртуальний метод string ToString() для формування рядка зі значеннями всіх полів класу
        public override string ToString()
        {
            return _NameTitle + " " + _DateEdition + "\n" + _Edit;
        }
    }
}
