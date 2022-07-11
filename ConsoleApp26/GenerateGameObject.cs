using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp26
{
    static class GenerateGameObject
    {
        static private Random random = new Random();
        static private Dictionary<int, string> uniqueCellsForField = new Dictionary<int, string>();

        static public PlayerPerson GeneratePlayer()
        {
            return new PlayerPerson("Roman", '!', new int[] { 0, 0 }, '.');
        }

        static public List<Coin> GenerateCoins(int SizeMap)
        {
            GetUniqueCellsForField(SizeMap);

            List<Coin> coins = new List<Coin>();

            int CountCoins = (int)Math.Log2(Math.Exp(2 * SizeMap));

            for (int i = 0; i < CountCoins; ++i)
            {
                coins.Add(new Coin('0', GetUniqueCoordsForCoin(i))); // Добавить генерация уникальных координат для монет

            }

            return coins;


            Random rng = new Random();
            int a = coins.Count;
            while (a > 1)
            {
                a--;
                int j = rng.Next(a + 1);
                Coin value = coins[j];
                coins[j] = coins[a];
                coins[a] = value;
            }


        }

        //static public int?[,] Test()
        //{
        //    // table dimension (assumes a square)
        //    var dim = 3;
        //    var table = new int?[dim, dim];

        //    // 100 integers: 0..99
        //    var queue = new Queue(Enumerable.Range(0, dim * dim).ToList<int>());
        //    var rng = new Random();


        //    int x = dim / 2, y = dim / 2;

        //    // Acceptable shuffle? As long as the queue has anything in it, try to place the next number
        //    while (queue.Count > 0)
        //    {
        //        x = rng.Next(dim);  // still using random, not great! :(
        //        y = rng.Next(dim);

        //        if (table[x, y] == null)
        //            table[x, y] = (int)queue.Dequeue();
        //    }

        //    // print output so I know I'm not crazy
        //    /*for (var i = 0; i < dim; i++)
        //    {
        //        Console.Write("Row {0}: [", i);
        //        for (var j = 0; j < dim; j++)
        //        {
        //            Console.Write("{0,4}", table[i, j]);
        //        }
        //        Console.WriteLine("]");
        //    }*/
        //    return table;
        //}

        static private Dictionary<int, string> GetUniqueCellsForField(int SizeMap)
        {
            int z = -1;
            for (int i = 0; i < SizeMap; ++i)
            {
                for (int j = 0; j < SizeMap; ++j)
                {
                    uniqueCellsForField.Add(z++, $"{i}, {j}"); // z - порядковый номер для строки координат (x, y)
                }
            }

            uniqueCellsForField.Remove(-1);

            return uniqueCellsForField;
        }

        static private int[] GetUniqueCoordsForCoin(int randomCell)
        {
            string[] newUniqueCoordsStr = uniqueCellsForField[randomCell].Split(',');
            int[] newUniqueCoordsInt = { Convert.ToInt32(newUniqueCoordsStr[0]), Convert.ToInt32(newUniqueCoordsStr[1]) };

            return newUniqueCoordsInt;
        }

        /*static void shuffle() 
        {
             
            int[,] arr = {};
            var list = new List<Coin>(arr.GetLength(0) * arr.GetLength(1));
            foreach (var i in arr)
                //list.Add(i);
            shuffleArray(arr);
            for (int i = 0; i < arr.GetLength(0); i++) 
            {
                for (int j = 0; j < arr.GetLength(1); j++) 
                {
                    Console.WriteLine(arr[i,j]);
                }
                Console.WriteLine(" ");
            }
            Console.ReadLine();
        }
        public static void shuffleArray(int[,] a) 
        {
            int n = a.GetLength(0);
            int m = a.GetLength(1);

            Random rand = new Random();
            for (int i = 0; i < n; i++) 
            {
                for (int j = 0; j < m; j++) 
                {
                    swap(a, i + rand.Next(n - i), j + rand.Next(m - j), i, j);
                }
            }
        }
        public static void swap(int[,] arr, int changeR, int changeC, int a, int b) 
        {
            int temp = arr[a, b];
            arr[a, b] = arr[changeR, changeC];
            arr[changeR, changeC] = temp;
        }
    }*/
    }
}
