//Pt1: 10min
//Pt2: 20min

string path = "E:/INTERAKTION/CSHARP/2021_AdventOfCode/2021_AdventOfCode/Input.txt";
//string path = "E:/INTERAKTION/CSHARP/2021_AdventOfCode/2021_AdventOfCode/Testdata.txt";
var intputData = File.ReadLines(path);
var inputDataList = new List<string>(intputData);

int? previousValue = null;
int counter = 0;

foreach (var line in intputData)
{
    if (previousValue == null)
    {
        previousValue = int.Parse(line);
    }
    else
    {
        if (int.Parse(line) > previousValue)
        {
            counter++;
            previousValue = int.Parse(line);
        }
        else
        {
            previousValue = int.Parse(line);
        }
    }
}

Console.WriteLine("Counter: " + counter);

//---------------------PART-2------------------------

int pairCounter = 0;
int? pairSums = null;

for (int i = 0; i < inputDataList.Count - 2; i++)
{
    int? currentNum = 0;

    for (int j = 0; j < 3; j++)
    {
        currentNum += int.Parse(inputDataList[i + j]);
    }

    if (currentNum > pairSums)
    {
        pairCounter++;
    }
    pairSums = currentNum;
}

Console.WriteLine("Paircounter: " + pairCounter);