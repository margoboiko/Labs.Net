using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class Human : IHasName, IEnumerable
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public Human() { }

        public Human(string name)
        {
            Name = name;
        }

        private static bool Female(Human human)
        {
            return human is Student || human is Botan;
        }

        private static bool Male(Human human)
        {
            return human is Girl || human is SmartGirl || human is PrettyGirl;
        }

        public static void ValidateCouple(Human human1, Human human2)
        {
            if (Male(human1) && Male(human2) || Female(human1) && Female(human2))
                throw new CoupleException("Persons have the same sexes!");
        }

        public int GetRandomProbability()
        {
            Random random = new Random();
            return random.Next(0, 100);
        }

        public IHasName Couple(Human human1, Human human2)
        {
            bool secondPerson = false;
            bool firstPerson = false;
            Couple firstCase = new Couple();
            foreach (Couple attribute in human1)
            {
                firstCase = attribute;
                if (attribute.Pair == human2.GetType().Name)
                {
                    var randValue = GetRandomProbability();
                    if (randValue <= attribute.Probability)
                    {
                        secondPerson = true;
                        Console.WriteLine(human1.GetType().Name + " LIKE " + human2.GetType().Name);
                        break;
                    }
                    else
                    {
                        Console.WriteLine(human1.GetType().Name + " UNLIKE " + human2.GetType().Name);
                    }
                }
            }
            foreach (Couple attribute in human2)
            {
                if (attribute.Pair == human1.GetType().Name)
                {
                    var randValue = GetRandomProbability();
                    if (randValue <= attribute.Probability)
                    {
                        firstPerson = true;
                        Console.WriteLine(human2.GetType().Name + " LIKE " + human1.GetType().Name + "\n");
                        break;
                    }
                    else
                    {
                        Console.WriteLine(human2.GetType().Name + " UNLIKE " + human1.GetType().Name + "\n");
                    }
                }
            }

            object result = new object();
            object child = new object();
            if (firstPerson && secondPerson)
            {
                foreach (MethodInfo method in human2.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance))
                {
                    if (method.ReturnType == typeof(System.String))
                    {
                        try
                        {
                            result = method.Invoke(human2, null);
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                }

                Type type = Type.GetType(GetType().Namespace + '.' + firstCase.ChildType);
                if (type != null)
                {
                    child = Activator.CreateInstance(type);
                    PropertyInfo nameProperty = child.GetType().GetProperty("Name");
                    PropertyInfo surnameProperty = child.GetType().GetProperty("Surname");

                    if (nameProperty != null && surnameProperty != null)
                    {
                        nameProperty.SetValue(child, result);

                        if (nameProperty.GetValue(child, null).ToString() == "Student" ||
                            nameProperty.GetValue(child, null).ToString() == "Botan")
                        {
                            surnameProperty.SetValue(child, surnameProperty.GetValue(child, null));
                        }
                        else
                        {
                            surnameProperty.SetValue(child, surnameProperty.GetValue(child, null));
                        }
                    }
                }
            }
            else
            {
                return this;
            }

            return (IHasName)child;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Couple> GetEnumerator()
        {
            Attribute[] attrs = Attribute.GetCustomAttributes(GetType());
            foreach (var attr in attrs)
            {
                if (attr is Couple c)
                {
                    yield return c;
                }
            }
        }
    }
}