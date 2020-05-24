using System;
using System.IO;
using System.Linq;
using Lab5.Models;

namespace Lab5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string fileName = "NewFile";
            Magazine m1 = new Magazine();
            Magazine m2 = (Magazine) m1.DeepCopy();
            
            Console.WriteLine("Original is \n{0} \nCopy is \n {1}", m1, m2);
            
            Console.WriteLine("Please enter file name:");
            fileName = Console.ReadLine();
            
            if (!File.Exists(fileName))
            {
                Console.WriteLine("File not exist. Creating new file...");
                File.Create(fileName);
            }
            else
            {
                m1.Load(fileName);
            }
            
            Console.WriteLine("-------------------------------");
            Console.WriteLine(m1);

            m1.AddFromConsole();
            m1.Save(fileName);
            
            Console.WriteLine("-------------------------------");
            Console.WriteLine(m1);

            Magazine.Load(fileName, m1);
            m1.AddFromConsole();
            Magazine.Save(fileName, m1);

            Console.WriteLine("-------------------------------");
            Console.WriteLine(m1);
        }
    }
}