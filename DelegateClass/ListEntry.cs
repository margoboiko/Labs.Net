using System;

namespace Lab4.DelegateClass
{
    internal class ListEntry
    {
        public string CollectionName { get; set; } //публічна автовластивість типу string з назвою колекції, в якій вудбулася подія
        public string CollectionChangeType { get; set; } //публічна автовластивість типу string з інформацією про те, яка подія відбулась в колекції
        public int ElementNumber { get; set; } //номер доданого або зміненого елемента
        
        //конструктори для ініціалізації полів класу
        public ListEntry() : this(null, null, 0)
        {          
        }
                
        public ListEntry(string collectionName, string collectionChangeType, int elementNumber)
        {
            CollectionName = collectionName;
            CollectionChangeType = collectionChangeType;
            ElementNumber = elementNumber;          
        }

        //перезавантажена версія методу string ToString()
        public override string ToString()
        {
            return string.Format("{0} {1} {2}",
                CollectionName, CollectionChangeType, ElementNumber);
        }
    }
}