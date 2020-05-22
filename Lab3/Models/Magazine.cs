using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lr3
{
    internal class Magazine: Edition
    {
        private string _nameTitle;
        private Frequency _Period;
        private DateTime _DateEdition;
        private int _Edit;
        private List<Person> _personsList;
        private List<Article> _articleList;

        //���������� ���� double (����� ��� �������), � ����� ������������ 
        //������ ����������� �������� ������ � ������
        public double AverageRate
        {
            get
            {
                double allRanges = 0;
                foreach (Article article in ArticleList)
                {
                    allRanges += article._Rating;
                }
                return allRanges / ArticleList.Count ;
            }
        }
        
        //���������� ���� Edition; �e��� get ������� ��'��� ���� Edition, ��� ����� ���������� � ������ ����'���� �������� �����,
        //����� set �������� �������� ����� � �������� �����
        public Edition Edition
        {
            get { return new Edition(_NameTitle, _DateEdit, Circulation);}
            set
            {
                _NameTitle = value._NameTitle;
                _DateEdition = value._DateEdit;
                Circulation = value.Circulation;
            }
        }
        
        //������������ � ����������� ���� string, Frequency, DataTime, int ��� ����������� ��� ���� 
        public string NameTitle
        {
            get { return _nameTitle; }
            set { _nameTitle = value; }
        }

        public Frequency Period
        {
            get { return _Period; }
            set { _Period = value; }
        }

        public DateTime DateEdition
        {
            get { return _DateEdition; }
            set { _DateEdition = value; }
        }
        
        public int Edit
        {
            get { return _Edit; }
            set { _Edit = value; }
        }

        public List<Person> PersonsList
        {
            get { return _personsList; }
            set { _personsList = value; }
        }

        public List<Article> ArticleList
        {
            get { return _articleList; }
            set { _articleList = value; }
        }
        
        public bool this[Frequency frequency]
        {
            get { return _Period == frequency; }
        }
        
        //����������� ��� ��������� ��� ����������� �� ������������
        public Magazine() : this(new Edition(), "default name", Frequency.Weekly, new DateTime(), 0,
            new List<Person> {new Person()}, new List<Article> {new Article()})
        {    
        }

        public Magazine(Edition edition, string nameTitle, Frequency period, DateTime DateEdition,
            int Edit, List<Person> personsList, List<Article> articleList) 
            : base(edition._NameTitle, edition._DateEdit, edition.Circulation)
        {
            _nameTitle = nameTitle;
            _Period = period;
            _DateEdition = DateEdition;
            _Edit = Edit;
            _personsList = personsList;
            _articleList = articleList;
        }        
  
        //����� void AddArticles ( params Article[] ) ��� ������� �������� � ������ ������ �������
        public void AddArticles(params Article[] article)
        {
            if (article != null)
            {
                ArticleList.AddRange(article);
            }            
        }

         //����� void AddEditors(params Person[] ) ��� ������� ��������� � ������
        public void AddEditors(params Person[] person)
        {
            if (person != null)
            {
                PersonsList.AddRange(person);
            }
        }
        
        //�������� � ���������� ���� double ��� �������� ������ � ��������� ����� ������� ��������
        public IEnumerable GetArticlesMoreThan(double lowValue)
        {
            foreach (Article article in ArticleList)
            {
                if (article._Rating > lowValue)
                {
                    yield return article;
                }
            }
        }
        
         //�������� � ���������� ���� string ��� �������� ������, � ���� ���� � �������� �����
        public IEnumerable GetArticlesWithText(string text)
        {
            foreach (Article article in ArticleList)
            {
                if (article._Title.Contains(text))
                {
                    yield return article;
                }
            }
        }
        
         //���������������� ����� ToString(); ��� ���������� ����� � ���������� ��� ����
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            
            foreach (var article in ArticleList)
            {
                stringBuilder.AppendLine(article.ToString());
            }
            stringBuilder.AppendLine("Persons:");
            foreach (var person in PersonsList)
            {
                stringBuilder.AppendLine(person.ToString());
            }
            return string.Format(
                " NameTitle: {0},\n Period: {1},\n DateEdition: {2},\n Article: {3},\n AverageRate: {4}\n",
                NameTitle, Period, DateEdition.ToShortDateString(), stringBuilder, AverageRate);
        }

        // ���������� ����� ��� ���������� ����� �� ������� ��� ���� ��� ���� � ������� ������ �� ������ ���������, ��� � ��������� ���������� ��������
        public virtual string ToShortString()
        {
            return string.Format(" NameTitle: {0},\n Period: {1},\n DateEdition: {2},\n AverageRate: {3}\n",
                NameTitle, Period, DateEdition.ToShortDateString(), AverageRate);
        }
        
        //��������� ��������������� ����� ������������ ������ object DeepCopy().
        public override object DeepCopy()
        {
            Magazine other = (Magazine) MemberwiseClone();
            other.PersonsList = new List<Person>();
            other.ArticleList = new List<Article>();
            foreach (Person person in PersonsList)
                other.PersonsList.Add((Person) person.DeepCopy());
            foreach (Article article in ArticleList)
                other.ArticleList.Add((Article) article.DeepCopy());
            return other;
        }

        protected bool Equals(Magazine other)
        {
            return string.Equals(_nameTitle, other._nameTitle) && _Period == other._Period &&
                   _DateEdition.Equals(other._DateEdition) && _Edit == other._Edit &&
                   _articleList.SequenceEqual(other._articleList) && _personsList.SequenceEqual(other._personsList);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Magazine) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_nameTitle != null ? _nameTitle.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int) _Period;
                hashCode = (hashCode * 397) ^ _DateEdition.GetHashCode();
                hashCode = (hashCode * 397) ^ _Edit;
                hashCode = (hashCode * 397) ^ (_articleList != null ? _articleList.GetHashCode() : 0);
                return hashCode;
            }
        } 

        public static bool operator ==(Magazine left, Magazine right)
        {
            return ReferenceEquals(left, right);
        }

        public static bool operator !=(Magazine left, Magazine right)
        {
            return !ReferenceEquals(left, right);
        }
    }
}