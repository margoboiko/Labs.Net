﻿using System;
using System.Collections;
using System.Text;

namespace lr2
{
    class Magazine : Edition, IRateAndCopy
    {
        private Frequency _Period; //інформація про періодичність виходу журналу
        public ArrayList Editors { get; set; } //список редакторів журналу
        public ArrayList Articles { get; set; } //список статей в журналі


        //конструктор з параметрами типу string, Frequency, DataTime, int для ініціалізації всіх полів 
        public Magazine(string mName, Frequency period, DateTime mDate, int mEdit, ArrayList personsList, ArrayList articleList) : base(mName, mDate, mEdit)
        {
            _Period = period;
            Editors = personsList;
            Articles = articleList;
        }

        //конструктор без параметрів для ініціалізації по замовчуванню
        public Magazine()
        {
            Editors = new ArrayList();
            Articles = new ArrayList();
        }

        public Frequency Periodicity
        {
            get { return _Period; }
            set { _Period = value; }
        }

        public bool this[Frequency period]
        {
            get
            {
                return _Period == period;
            }
        }

        //властивість типу double (тільки для читання), в якому обчислюється 
        //середнє арифметичне рейтингу статей в журналі
        public double AverageRate
        {
            get
            {
                double allRanges = 0;
                foreach (Article article in Articles)
                {
                    allRanges += article.Rating;
                }
                return allRanges / Articles.Count;
            }
        }

        //метод void AddArticles ( params Article[] ) для додання елементів в список статей журналу
        public void AddArticles(params Article[] articles)
        {
            Articles.AddRange(articles);
        }

        //метод void AddEditors(params Person[] ) для додання редакторів в список
        public void AddEditors(params Person[] persons)
        {
            Editors.AddRange(persons);
        }

        //перезавантажений метод ToString(); для формування рядка з значеннями всіх полів
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Persons:");
            foreach (var person in Editors)
                stringBuilder.AppendLine(person.ToString());

            foreach (var article in Articles)
                stringBuilder.AppendLine(article.ToString());

            return string.Format(" MagazineName: {0},\n Period: {1},\n MagazineDate: {2},\n Article: {3},\n AverageRate: {4}\n", _NameTitle, _Period, _DateEdition, stringBuilder, AverageRate);
        }

        // віртуальний метод для формування рядка із значень всіх полів без поля зі списком статей та списку редакторів, але зі значенням середнього рейтингу
        public virtual string ToShortString()
        {
            return string.Format(" MagazineName: {0},\n Period: {1},\n MagazineDate: {2},\n AverageRate: {3}\n", _NameTitle, _Period, _DateEdition, AverageRate);
        }

        //визначити перезавантажену версію виртуального методу object DeepCopy().
        public new object DeepCopy()
        {
            Magazine _magazineCopy = new Magazine(_NameTitle, _Period, _DateEdition, _Edit, Editors, Articles);
            _magazineCopy.Editors = new ArrayList();
            _magazineCopy.Articles = new ArrayList();
            return _magazineCopy as object;
        }

        //властивість типу Edition; мeтод get повертає об'єкт типу Edition, дані якого співпадають з даними підоб'єкту базового класу,
        //метод set присвоює значення полям з базового класу
        public Edition Edition
        {
            get
            { return new Edition(_NameTitle, _DateEdition, _Edit); }

            set
            {
                _NameTitle = value.NameTitle;
                _DateEdition = value.DateEdition;
                _Edit = value.Edit;
            }
        }

        public double Rating => AverageRate;

        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        //ітератор з параметром типу double для перебору статей з рейтингом більше деякого значення
        public IEnumerable GetArticlesMoreThan(double lowValue)
        {
            foreach (Article article in Articles)
                if (article.Rating > lowValue)
                    yield return article;
        }

        //ітератор з параметром типу string для перебору статей, в назві яких є вказаний рядок
        public IEnumerable GetArticlesWithText(string text)
        {
            foreach (Article article in Articles)
                if (article.Title.Contains(text))
                    yield return article;
        }
    }
}
