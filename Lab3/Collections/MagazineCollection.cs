using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace lr3
{
    internal class MagazineCollection
    {
        public List<Magazine> Magazines { get; set; }
      
        /*public MagazineCollection() : this(new List<Magazine>())
        {          
        }

        public MagazineCollection(List<Magazine> _magazines)
        {
            Magazines = _magazines;
        }*/

        //����� void AddDefaults(), �� ��������� ����� � ������ List<Magazine> ����� ������ 
        //����� ����� �������� ���� Magazine ��� ����������� �������� �� �������������
        public void AddDefaults()
        {
            Magazines = new List<Magazine>();
            Magazine fullMagazine = new Magazine(new Edition("name33", DateTime.Now, 123), "name1", Frequency.Montly, DateTime.Now, 10, 
                new List<Person>
                {
                    new Person(), new Person()
                }, 
                new List<Article>
                {
                    new Article(new Person(), "1", 50 ), new Article(new Person(), "2", 80 )
                });
            Magazines.Add(fullMagazine);
            Magazines.Add(new Magazine());            
            Magazines.Add(fullMagazine);
        }

        //����� void AddMagazines(params Magazine[]) ��� ��������� �������� � ������ List<Magazine>
        public void AddMagazines(params Magazine[] magazines)
        {
            Magazines = new List<Magazine>();
            foreach (var magazine in magazines)
            {
                Magazines.Add(magazine);
            }
        }

        //���������� ���� double (����� ��� �������), �� ������� ����������� �������� ���������� �������� ������ ��� �������� ������ List<Magazine>;
        //���� � �������� ���� ��������, ���������� ������� ����� �������� �� �������������; ��� ������ ������������� �������� ���������� �������� ������
        //������� ����������� ����� Max ����� System.Linq.Enumerable;
        public double GetMaxAverageRate()
        {           
            return Magazines.Count != 0 ? Magazines.Select(x => x.AverageRate).Max() : 0;
        }

        //���������� ���� IEnumerable<Magazine> (����� ��� �������), ��� ������� ��������� �������� 
        //������ List<Magazine> � ����������� ������ ������� Frequency.Monthly;
        //��� ����������� ��������� ����������� ����� Where ����� System.Linq.Enumerable;
        public IEnumerable<Magazine> GetMontlyMagazines()
        {
            return Magazines.Where(x => x.Period == Frequency.Montly);
        }

        //����� List<Magazine> RatingGroup(double value), �� ������� ������, ���� ������ �������� Magazine � List<Magazine> � ������� ��������� ������;
        //���� ��� ���������� ������ ����������� ������ Group �� ToList ����� System.Linq.Enumerable.
        public List<Magazine> GetRatingGroup(double value)
        {
            return Magazines.Where(x => x.AverageRate >= value).ToList();
        }

        //���������� �� ���� ������� � ������������� ���������� IComparable, ������������ � ���� Edition
        public void SotrByEditName()
        {
            Magazines.Sort();
        }

        //���������� �� ��� ������ ������� � ������������ ���������� IComparer<Edition>, ������������ � ���� Edition
        public void SortByEdDate()
        {
           Magazines.Sort(new Edition().Compare);
        }

        //���������� �� ������ ������� � ������������� ���������� IComparer<Edition>, ������������ � ���������� ����
        public void SortByEdit()
        {
            Magazines.Sort(new EditionCompare().Compare);  
        }
        
        //��������������� ����� ����������� ������ string ToString() ��� ���������� ����� � ����������� ��� ��
        //�������� ������ List<Magazine>, � ���� ���� �������� ��� ����, ������ ��������� ������� �� ������ ������ 
        //� ������ ��� ������� �������� Magazine

        public override string ToString()
        {
            string magazineData = "";
            foreach (Magazine magazine in Magazines)
            {
                magazineData += magazine.ToString() + "\n";
            }
            return magazineData;
        }

        //���������� ����� string ToShortList(), ���� ����� ����� � ����������� ��� �� �������� ������ List<Magazine>, 
        //���� ������ �������� ��� ����, ������� ������� ������, ����� ��������� ������� �� ����� ������ ��� ������� �������� Magazine,
        //��� ��� ������ ��������� �� ������
        public virtual string ToShortString()
        {
            string data = "";
            foreach (Magazine magazine in Magazines)
            {
                data += magazine.ToShortString() + 
                     "������� ������� ������:" + magazine.AverageRate + "\n"
                    +"�-��� �������i�: " + magazine.PersonsList.Count + "\n"
                    + "�-��� ����i���i�: " + magazine.ArticleList.Count + "\n\n";

            }
            return data;
        }
    }
}