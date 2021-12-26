//18:40 - 20:00

using System.Text;

public class Program1
{
    public void Main()
    {

        string path = "E:/INTERAKTION/CSHARP/2021_AdventOfCode/Day14/testinput.txt";
        var data = File.ReadAllLines(path);
        var pairChars = data.Where(x => x.Contains("->")).Select(x => x.Split("->", StringSplitOptions.TrimEntries));
        var inputString = data[0];

        IDictionary<(char, char), char> pairs = new Dictionary<(char, char), char>();
        IDictionary<char, int> charAppearance = new Dictionary<char, int>();

        foreach (var line in pairChars)
        {
            var charArr = line[0].ToCharArray();
            char inbetweeen = line[1].ToCharArray().First();
            pairs.Add((charArr[0], charArr[1]), inbetweeen);
        }

        //Console.WriteLine(pairChars[new Tuple<char, char>('N', 'N')]); 

        //pairs.Add(('C', 'H'), 'B');

        string currentString = inputString;
        for (int i = 0; i < 40; i++)
        {
            Console.WriteLine("STEP: " + i);
            currentString = Insertion(currentString);
            //Console.WriteLine(currentString);
        }

        //countChars(currentString);


        void countChars(string charString)
        {
            foreach (var character in charString)
            {
                if (!charAppearance.ContainsKey(character))
                {
                    charAppearance.Add(character, 1);
                }
                else
                {
                    var currentVal = charAppearance[character];
                    charAppearance[character] = currentVal + 1;
                }
            }

            var ordered = from entry in charAppearance orderby entry.Value ascending select entry;
            var leastCommon = ordered.First().Value;
            var mostCommon = ordered.Last().Value;
            var result = mostCommon - leastCommon;

            //Console.WriteLine("First: " + leastCommon);
            //Console.WriteLine("Last: " + mostCommon);
            //Console.WriteLine("Result: " + result);
        }



        //var sortedDict = from entry in myDict orderby entry.Value ascending select entry;

        string Insertion(string input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(input.First());

            for (int i = 0; i < input.Length - 1; i++)
            {
                var first = input[i];
                var third = input[i + 1];
                var second = pairs[(first, third)];


                sb.Append(second);
                sb.Append(third);
            }
            return sb.ToString();
        }

        //-----------------Part 2---------------------

        IDictionary<(char, char), long> charCalls = new Dictionary<(char, char), long>();

        foreach (var line in pairChars)
        {
            var charArr = line[0].ToCharArray();
            charCalls.Add((charArr[0], charArr[1]), 0);
        }

        //string InsertionPartTwo(string input)
        //{
        //    for (int i = 0; i < 1; i++)
        //    {
        //        var first = input[i];
        //        var third = input[i + 1];
        //        var second = pairs[(first, third)];

        //        for (int steps = 0; steps < 10; steps++)
        //        {

        //        }

        //        return sb.ToString();
        //    }
        //}


        void looper(string charPair, int depth)
        {
            //for loop

            //get new two elements from charPair

            //r
        }
    }
}