using System;
using Lab4.Collections;

namespace Lab4.DelegateClass
{
    internal class MagazineListHandlerEventArgs: System.EventArgs
    {
        public string CollectionName { get; set; } //публічна автовластивість типу string з назвою колекції, в якій вудбулася подія
        public string CollectionChangeType { get; set; } //публічна автовластивість типу string з інформацією про тип зміни в колекції
        public int ElementNumber { get; set; } //публічна автовластивість типу int з номером елементу, який був змінений

        //конструктори для ініціалізації класу
        public MagazineListHandlerEventArgs() : this(null, null, 0)
        {          
        }
                
        public MagazineListHandlerEventArgs(string collectionName, string collectionChangeType, int elementNumber)
        {
            CollectionName = collectionName;
            CollectionChangeType = collectionChangeType;
            ElementNumber = elementNumber;
        }

        //перезавантажена версія метода ToString() для формування рядка з інформацією про всі поля класу
        public override string ToString()
        {
            return string.Format("{0} {1} {2}",
                CollectionName, CollectionChangeType, ElementNumber);
        }
    }
}