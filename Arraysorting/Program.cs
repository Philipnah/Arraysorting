using System;
using System.IO;
using System.Collections.Generic;

namespace Arraysorting {
	class Program {
		static void Main(string[] args) {
			Program UpperClass = new Program();

			string inputFile = @"C:\Users\Philip\OneDrive - TEC\Skole\School Programming\C#\C_drev\FileHandlerFolder\testvector.txt";
			string outputFile = @"C:\Users\Philip\OneDrive - TEC\Skole\School Programming\C#\C_drev\FileHandlerFolder\file.txt";

			string[] nameList = UpperClass.FileLoad(inputFile);
			string[] list = UpperClass.ListSort(nameList);


			foreach (string item in list) {
				Console.WriteLine(item);
			}

			UpperClass.ToFile(list, outputFile);

		}

		// the following function spilts the lines of the file and further splits the elements of the line and appends that to a new array, which is returned.
		public string[] FileLoad(string file) {

			string[] lines = File.ReadAllLines(file);

			List<string> stringInput = new List<String>();

			for (int i = 0; i < lines.GetLength(0); i++) {
				string[] fields = lines[i].Split(new char[] { ',', ';', ':', '\t' });

				stringInput.AddRange(fields);
			}

			string[] endArray = stringInput.ToArray();

			return endArray;
		}


		

		public string[] ListSort(string[] array) {

			// this ensures the order of the alphabet.
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

					// the following code also switches the names depending on the second charater, if the first is the same.
					if (alphabet[array[i].ToLower()[0]] == alphabet[array[i + 1].ToLower()[0]]) {
						if (alphabet[array[i].ToLower()[1]] > alphabet[array[i + 1].ToLower()[1]]) {
							string temp = array[i];
							array[i] = array[i + 1];
							array[i + 1] = temp;
						}
					}


				}
			}
			return array;
		}

		public void ToFile(string[] array, string file) {


			StreamWriter StreamW = new StreamWriter(file);

			foreach (string item in array) {
				StreamW.Write(item + "\n");
			}

			StreamW.Flush();
			StreamW.Close();

			Console.WriteLine("\nArray was written to file.");


		}


	}
}
