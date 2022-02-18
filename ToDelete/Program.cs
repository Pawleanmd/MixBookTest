using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDelete
{
    class Program
    {
        #region MyRegion
        //Test1
        //static void Main(string[] args)
        //{
        //    Dictionary<char, string> response = new Dictionary<char, string>();
        //    var input = "aabbaaccb";
        //    foreach(var i in input)
        //    {
        //        if (!response.ContainsKey(i))
        //        {
        //            response.Add(i, "");
        //        }
        //    }
        //    var responseString = "";
        //    foreach(var kv in response)
        //    {
        //        responseString += kv.Key;
        //    }
        //    Console.WriteLine(responseString);

        //    Console.WriteLine("Hello World!");
        //}

        //Test2
        //static void Main(string[] args)
        //{
        //    var inputSrtings = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
        //    List<string> sortedStrings = new List<string>();

        //    var response = new Dictionary<string, List<string>>();

        //    foreach (var input in inputSrtings)
        //    {
        //        var sorted = String.Concat(input.OrderBy(c => c));
        //        sortedStrings.Add(sorted);
        //    }

        //    for(int i = 0; i < sortedStrings.Count; i ++)
        //    {
        //        var key = sortedStrings[i];
        //        if (response.ContainsKey(key))
        //        {
        //            response[key].Add(inputSrtings[i]);
        //        }
        //        else
        //        {
        //            response.Add(key, new List<string>() { inputSrtings[i] });
        //        }
        //    }

        //    foreach(var kv in response)
        //    {
        //        Console.WriteLine(String.Join(',',kv.Value));
        //    }

        //    Console.WriteLine("Hello World!");
        //}


        //Test3
        //static void Main(string[] args)
        //{

        //    var response = Calc(new int[] { 1, 2, 4, 2, 3, 2, 5, 2 });

        //    Console.WriteLine($"Volume: {response.Volume}, first index: {response.First}, second index: {response.Second}"); ;
        //    Console.WriteLine("Hello World!");
        //}

        //public static Response Calc(int[] heights)
        //{
        //    int response = 0;
        //    int firstIndex = 0;
        //    int secondIndex = 0;
        //    for (int i = 0; i < heights.Length; i++)
        //    {
        //        for(int j = 0; j < heights.Length; j++)
        //        {
        //            if(i == j)
        //            {
        //                continue;
        //            }
        //            var height = i+1 < j+1 ? i+1 : j+1;
        //            var width = Math.Abs(i-j);
        //            var result = width * height;
        //            if (result > response)
        //            {
        //                response = result;
        //                firstIndex = i;
        //                secondIndex = j;
        //            }
        //        }
        //    }
        //    return new Response() {Volume = response, First = firstIndex, Second = secondIndex };
        //}

        //public class Response
        //{
        //    public int Volume { get; set; }
        //    public int First { get; set; }
        //    public int Second { get; set; }
        //}
        #endregion


        static void Main(string[] args)
        {
            var req = new int[5, 5] { { 1, 0, 0, 0, 1 }, { 0, 0, 0, 0, 0 }, { 0, 0, 1, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 } };
            Search(req);
        }

        public static void Search(int[,] matrix)
        {
            List<Cords> people = new List<Cords>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] == 1)
                    {
                        people.Add(new Cords() { I = i, J = j });
                    }
                }
            }

            Cords response = null;
            int minDistance = int.MaxValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int sumDistance = 0;
                    foreach (var man in people)
                    {
                        var distance = Math.Abs(man.I - i) + Math.Abs(man.J - j);
                        sumDistance += distance;
                    }
                    if (sumDistance < minDistance)
                    {
                        response = new Cords() { I = i, J = j };
                        minDistance = sumDistance;
                    }
                }
            }
            Console.WriteLine($"{response.I + 1}, {response.J + 1}");

        }

        public class Cords
        {
            public int I { get; set; }
            public int J { get; set; }
        }
    }
}
