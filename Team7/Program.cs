using System;
using System.Collections;

namespace Team7
{
    class MainClass
    {
        static ArrayList teamMembers = new ArrayList(){"Rajeswari", "Meng Guan",
            "Guo Rui","Xin Ying","Zin Ko","Nhat Ton","Xiaowen","Chun Ket"};
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.Write("Input number of answers: ");
            int amountOfAnswers = Int32.Parse(Console.ReadLine());
            Console.Write("Input number of persons per answer: ");
            int maxPersons = Int32.Parse(Console.ReadLine());
            PrintList(amountOfAnswers, maxPersons);
        }

        public static void PrintList(int amountOfAnswers, int maxPersons){
            Random r = new Random();

            int[] counts;

            String[] result;

            do
            {
                counts = new int[]{ 0, 0, 0, 0, 0, 0, 0, 0 };
                result = new string[amountOfAnswers];

                for (int i = 0; i < amountOfAnswers; i++)
                {
                    String names = "";

                    int numberOfPerson = r.Next(1, maxPersons + 1);

                    int[] chosenNumbers = { 0, 0, 0, 0, 0, 0, 0, 0 };

                    for (int j = 1; j <= numberOfPerson; j++)
                    {
                        int position = r.Next(1, 8);
                        while (chosenNumbers[position - 1] == position)
                        {
                            position = r.Next(1, 8);
                        }
                        chosenNumbers[position - 1] = position;
                        counts[position - 1]++;

                        if (j > 1) names = names + ", ";

                        names = names + teamMembers[position];
                    }

                    result[i] = names;

                }
            }
            while (!CheckFairness(counts));

            for (int i = 1; i <= amountOfAnswers; i++){
                Console.WriteLine("Answer {0}: {1}", i, result[i-1]);
			}

        }

        public static bool CheckFairness(int[] counts){
            for (int i = 0; i < counts.Length - 2; i++)
            {
                if (counts[i] != counts[i + 1])
                    return false;
            }
            return true;
        }
    }
}
