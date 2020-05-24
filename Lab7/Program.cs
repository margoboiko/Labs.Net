using System;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

namespace Lab7
{
    internal class Program
    {
        static long GetDirectorySize(DirectoryInfo dinfo)
        {
            long dsize = 0;

            foreach (var fileInfo in dinfo.GetFiles())
                Interlocked.Add(ref dsize, fileInfo.Length);

            Parallel.ForEach(dinfo.GetDirectories(), (subDirectory) =>
                   Interlocked.Add(ref dsize, GetDirectorySize(subDirectory)));

            return dsize;
        }

        public static void Main(string[] args)
        {
            Console.Write("Enter directory: ");
            string link = Console.ReadLine();
            DirectoryInfo directory = new DirectoryInfo(link);
            if (!directory.Exists)
            {
                Console.WriteLine("Directory doesn't exists");
                return;
            }

            long size = GetDirectorySize(directory);
            Console.WriteLine($"Size of directory: {(float)size / 1000000}mb");
        }
    }
}