using System;
using Lab4.Collections;

namespace Lab4.DelegateClass
{
    internal class MagazineListHandlerEventArgs: System.EventArgs
    {
        public string CollectionName { get; set; } //������� �������������� ���� string � ������ ��������, � ��� ��������� ����
        public string CollectionChangeType { get; set; } //������� �������������� ���� string � ����������� ��� ��� ���� � ��������
        public int ElementNumber { get; set; } //������� �������������� ���� int � ������� ��������, ���� ��� �������

        //������������ ��� ����������� �����
        public MagazineListHandlerEventArgs() : this(null, null, 0)
        {          
        }
                
        public MagazineListHandlerEventArgs(string collectionName, string collectionChangeType, int elementNumber)
        {
            CollectionName = collectionName;
            CollectionChangeType = collectionChangeType;
            ElementNumber = elementNumber;
        }

        //��������������� ����� ������ ToString() ��� ���������� ����� � ����������� ��� �� ���� �����
        public override string ToString()
        {
            return string.Format("{0} {1} {2}",
                CollectionName, CollectionChangeType, ElementNumber);
        }
    }
}