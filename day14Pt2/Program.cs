using System.Text;

string path = "D:/KSA/Delete/ConsoleAppAoC/Day14/testinput.txt";

var data = File.ReadAllLines(path);

string inputString = data[0].Trim();
var list = data.Where(x => x.Contains("->")).Select(x => x.Split("->", StringSplitOptions.TrimEntries));
Dictionary<string, char> map = new Dictionary<string, char>();
Dictionary<char, long> charCounter = new Dictionary<char, long>();

StringBuilder globalSb = new StringBuilder();

foreach (var item in list)
{
    map.Add(item[0], item[1].First());
}


calcChars(inputString, 4);

foreach (var item in charCounter)
{
    Console.WriteLine("Char: " + item.Key + ", " + "Number: " + item.Value);
}


void calcChars(string startString, int depth)
{
    for (int j = 0; j < startString.Length - 1; j++)
    {
        Console.WriteLine($"Run {j}/{startString.Length - 1}");
        var charOne = startString[j];
        var charTwo = startString[j + 1];

        StringBuilder charPairString = new StringBuilder();
        charPairString.Append(charOne);
        charPairString.Append(charTwo);

        if (j == 0)
        {
            charCounter.Add(charOne, 1);
        }
        addToCharCounter(charTwo, 1);

        Dictionary<string, int> elementsDict = new Dictionary<string, int>();
        elementsDict.Add(charPairString.ToString(), 1);

        //depth
        for (int i = 0; i < depth; i++)
        {
            Console.WriteLine($"Subrun {i}/{depth - 1}");
            Dictionary<string, int> newElementsDict = new Dictionary<string, int>();

            foreach (var element in elementsDict)
            {
                var newElements = createNewLevelChars(element.Key);

                if (newElementsDict.ContainsKey(newElements.Item1))
                {
                    newElementsDict[newElements.Item1] = newElementsDict[newElements.Item1] + element.Value;
                }
                else
                {
                    newElementsDict.Add(newElements.Item1, 1);
                }


                if (newElementsDict.ContainsKey(newElements.Item2))
                {
                    newElementsDict[newElements.Item2] = newElementsDict[newElements.Item2] + element.Value;
                }
                else
                {
                    newElementsDict.Add(newElements.Item2, 1);
                }

                //Console.WriteLine("Element: " + element);
                //Console.WriteLine("Returned: " + newElements.Item1 + ", " + newElements.Item2 + ", " + newElements.Item3);

                addToCharCounter(newElements.Item3, element.Value);
            }

            elementsDict = newElementsDict;
        }
    }

}


void addToCharCounter(char key, int numberOfTimes)
{
    if (charCounter.ContainsKey(key))
    {
        charCounter[key] = charCounter[key] + numberOfTimes;
    }
    else
    {
        charCounter.Add(key, 1);
    }
}

Tuple<string, string, char> createNewLevelChars(string chars)
{
    var insertionChar = map[chars];

    StringBuilder stringOneBuilder = new StringBuilder();
    stringOneBuilder.Append(chars[0]);
    stringOneBuilder.Append(insertionChar);

    StringBuilder stringTwoBuilder = new StringBuilder();
    stringTwoBuilder.Append(insertionChar);
    stringTwoBuilder.Append(chars[1]);

    var newStringOne = stringOneBuilder.ToString();
    var newStringTwo = stringTwoBuilder.ToString();

    return new Tuple<string, string, char>(newStringOne, newStringTwo, insertionChar);
}