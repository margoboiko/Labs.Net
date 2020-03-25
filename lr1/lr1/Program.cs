using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr1
{
	class Program
	{
		static void Main(string[] args)
		{
			Person margoBoiko = new Person("Marharyta", "Boiko", new DateTime(2000, 03, 23));
			Person xeniaDolgan = new Person("Xenia", "Dolgan", new DateTime(1999, 11, 26));
			Article article1 = new Article(margoBoiko, "Forbes", 4.7);
			Article article2 = new Article(xeniaDolgan, "Viva", 3.8);
			Magazine magazine1 = new Magazine("Viva", Frequency.Monthly, new DateTime(2020, 12, 26), 345679);

			Console.WriteLine( magazine1.ToShortString() + "\n");
			Console.WriteLine( Frequency.Weekly + " " + Frequency.Monthly + " " + Frequency.Yearly + "\n ");
			Console.WriteLine( magazine1 + "\n");
			magazine1.AddArticles(article1, article2);
			Console.WriteLine( magazine1.ToString() + "\n");
			Console.WriteLine();
			string inputText = Console.ReadLine();

			int nRows = int.Parse(inputText.Split(' ')[0]);
			int mColumns = int.Parse(inputText.Split(' ')[1]);

			int sum = 0;
			int size = 0;
			while (sum < nRows * mColumns)
			{
				sum += ++size;
			}

			Article[] oneDimension = new Article[nRows * mColumns];
			Article[,] twoDimension = new Article[nRows, mColumns];
			Article[][] cogged = new Article[size][];

			var timeStart = Environment.TickCount;
			for (int i = 0; i < nRows * mColumns; i++)
			{
				oneDimension[i] = article1;
			}
			var timeEnd = Environment.TickCount;
			Console.WriteLine("\nOne dimension is: " + (timeEnd - timeStart));

			timeStart = Environment.TickCount;
			for (int i = 0; i < nRows; i++)
			{
				for (int j = 0; j < mColumns; j++)
				{
					twoDimension[i, j] = article1;
				}
			}
			timeEnd = Environment.TickCount;
			Console.WriteLine("\nTwo dimension is: " + (timeEnd - timeStart));

			for (int i = 0; i < size; i++)
			{
				if (i == size - 1)
				{
					cogged[i] = new Article[nRows * mColumns - (sum - size)];
					break;
				}
				cogged[i] = new Article[i + 1];
			}

			timeStart = Environment.TickCount;
			foreach (var lineArray in cogged)
			{
				for (var j = 0; j < lineArray.Length; j++)
				{
					lineArray[j] = article1;
				}
			}
			timeEnd = Environment.TickCount;
			Console.WriteLine("\nTwo dimension2 is: " + (timeEnd - timeStart));

		}
	}
}