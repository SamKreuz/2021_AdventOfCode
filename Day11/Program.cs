﻿public record point(int x, int y);

class Program
{
    static void Main(string[] args)
    {
        string path = "E:/INTERAKTION/CSHARP/2021_AdventOfCode/Day11/testinput.txt";
        var data = File.ReadAllLines(path);

        var array = data.Select(line => line.ToArray().Select(element => int.Parse(element.ToString())).ToArray()).ToArray();
        var arrayLength = array[0].Length;

        int flashes = 0;

        Dictionary<(int, int), (int, bool)> keyValues = new();

        //keyValues.Add((5,6),(5, true));

        for (int x = 0; x < arrayLength; x++)
        {
            for (int y = 0; y < arrayLength; y++)
            {
                keyValues.Add((x, y), (array[x][y], false));
            }
        }



        //foreach (var keyvalpair in keyValues)
        //{
        //    Console.WriteLine(keyvalpair.Value.Item1);

        //}
        //Console.WriteLine("---------------------");

        for (int x = 1; x <= 1; x++)
        {
            printArray(keyValues);
            foreach (var key in keyValues)
            {
                if (key.Value.Item1 == 9)
                {
                    keyValues[key.Key] = (0, true);
                }
                else
                {
                    var currentNumPlus = key.Value.Item1 + 1;
                    keyValues[key.Key] = (currentNumPlus, false);
                }
            }

            printArray(keyValues);

            while (keyValues.Any(x => x.Value.Item1 == 0 && x.Value.Item2 == true)) //repeat until all zeroes are false
            {
                foreach (var key in keyValues)
                {
                    if (key.Value.Item1 == 0 && key.Value.Item2 == true)
                    {
                        Console.WriteLine("Zero Keys: " + key.Key + ", " + key.Value);
                        Flash((key.Key), (key.Value.Item1, key.Value.Item2));
                        keyValues[key.Key] = (0, false);
                        printArray(keyValues);

                    }
                }
            }

            printArray(keyValues);



            //foreach (var key in keyValues)
            //{
            //    Console.WriteLine(keyValues[key.Key]);
            //}
            //Console.WriteLine("------------------");

        }



        //Flash((9, 9), keyValues[(9, 9)]);

        void Flash((int, int) key, (int, bool) value)
        {
            //Console.WriteLine("Flash called for " + key);
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    var newX = key.Item1 + x;
                    var newY = key.Item2 + y;

                    if (newX != -1 && newX != 10 && newY != -1 && newY != 10)
                    {
                        if (keyValues[(newX, newY)].Item2 == false && keyValues[(newX, newY)].Item1 != 0)
                        {
                            if (keyValues[(newX, newY)].Item1 == 9)
                            {
                                keyValues[(newX, newY)] = (0, false);
                            }
                            else
                            {
                                var currentNumPlus = keyValues[(newX, newY)].Item1 + 1;
                                keyValues[(newX, newY)] = (currentNumPlus, false);
                            }
                        }
                    }
                }
            }
        }
        //Console.WriteLine(keyValues[(0, 0)]);

        //foreach (var keyvalpair in keyValues)
        //{
        //    Console.WriteLine(keyvalpair.Value.Item1);
        //}


        void printArray(Dictionary<(int, int), (int, bool)> dict)
        {
            int elemNum = dict.Count;
            int elementLength = (int)Math.Sqrt(elemNum);

            var elem = dict.Select(a => a.Value.Item1).ToArray();

            for (int i = 0; i < elementLength; i++)
            {
                for (int j = 0; j < elementLength; j++)
                {
                    Console.Write(dict[(i, j)] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
