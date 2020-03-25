using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr1
{
    class Magazine
    {
        private string _MName;
        private Frequency _Period;
        private DateTime _MDate;
        private int _Circle;
        private Article[] _articles=new Article[20];

        public Magazine(string mName, Frequency period, DateTime mDate, int circle)
        {
            _MName = mName;
            _Period = period;
            _MDate = mDate;
            _Circle = circle;
        }

        public Magazine() { }

        public string MName
        {
            get
            { return _MName;}
            set
            { _MName = value; }
        }

        public Frequency Period
        {
            get
            { return _Period; }
            set
            { _Period = value; }
        }

        public DateTime MDate
        {
            get
            { return _MDate; }
            set
            { _MDate = value; }
        }

        public Article[] Articles
        {
            get
            { return _articles; }
            set
            { _articles = value; }
        }

        public bool this[Frequency period]
        {
            get
            {
                return _Period == period;
            }
        }

        public void AddArticles(params Article[] _articles)
        {
            _articles.CopyTo(_articles, 0);
        }

        public override string ToString()
        {
            return _MName + " " + _Period + " " + _MDate + " " + _Circle + "\n" + string.Join(", ", _articles.Where(o => o != null).Select(o => o.ToString()).ToArray()) + " "; ;
        }

        public virtual string ToShortString()
        {
            return _MName + " " + _Period + " " + _MDate + " " + _Circle + "\n";
        }


    }
}
