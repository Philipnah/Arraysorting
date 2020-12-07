using System;
using System.IO;
using System.Collections.Generic;

namespace Arraysorting {
	class Program {
		static void Main(string[] args) {
			Program UpperClass = new Program();

			string[] nameList = { "John","Bo","Anton","Keld","Benny","Egon","Yvonne","Børge","Niels","Åge","Allan","Ib","Carsten","Ellen","Alice","Thor","Henrik","Johnny","Lars","Leif","Rene","Ole","Poul","Kamilla","Tove","Winnie","Claus","Klaus","Grit","Jens","Elvis"};
			string filePath = @"C:\Users\Philip\OneDrive - TEC\Skole\School Programming\C#\C_drev\FileHandlerFolder\file.txt";

			string[] list = UpperClass.ListSort(nameList);

			foreach (string item in list) {
				Console.WriteLine(item);
			}

			UpperClass.ToFile(list, filePath);

		}

		public string[] ListSort(string[] array) {

			Dictionary<char, int> alphabet = new Dictionary<char, int>() {
				{ 'a', 1 },
				{ 'b', 2 },
				{ 'c', 3 },
				{ 'd', 4 },
				{ 'e', 5 },
				{ 'f', 6 },
				{ 'g', 7 },
				{ 'h', 8 },
				{ 'i', 9 },
				{ 'j', 10 },
				{ 'k', 11 },
				{ 'l', 12 },
				{ 'm', 13 },
				{ 'n', 14 },
				{ 'o', 15 },
				{ 'p', 16 },
				{ 'q', 17 },
				{ 'r', 18 },
				{ 's', 19 },
				{ 't', 20 },
				{ 'u', 21 },
				{ 'v', 22 },
				{ 'w', 23 },
				{ 'x', 24 },
				{ 'y', 25 },
				{ 'z', 26 },
				{ 'æ', 27 },
				{ 'ø', 28 },
				{ 'å', 29 },
			};


			// the following would return 24
			// Console.WriteLine(alphabet['x']);
			for (int j = 0; j < array.Length - 1; j++) {
				for (int i = 0; i < array.Length - 1; i++) {
					if (alphabet[array[i].ToLower()[0]] > alphabet[array[i + 1].ToLower()[0]]) {

						string temp = array[i];
						array[i] = array[i + 1];
						array[i + 1] = temp;

					}
				}
			}
			return array;
		}

		public void ToFile(string[] array, string file) {


			StreamWriter StreamW = new StreamWriter(file);

			StreamW.Write(array);

			StreamW.Flush();
			StreamW.Close();


		}

		public static void write(string file, string[] arrayInput) {
			StreamWriter Stream = new StreamWriter(file, append: true);

			for (int i = 0; i < arrayInput.Length; i++) {
				if (i < arrayInput.Length - 1) {
					Stream.Write(arrayInput[i] + ",");
				}
				else {
					Stream.Write(arrayInput[i]);
				}
			}
			// We demand that the built up cache is written to memory by asking it to clear the cache, then we close.
			Stream.Flush();
			Stream.Close();

			Console.WriteLine($"Names written: {arrayInput.Length}");
		}


	}
}
