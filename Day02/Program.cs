//Pt. 1 = 17min
//Pt. 2 = 22min

string path = "E:/INTERAKTION/CSHARP/2021_AdventOfCode/Day02/input.txt";
//string path = "E:/INTERAKTION/CSHARP/2021_AdventOfCode/Day02/testData.txt";

var inputData = File.ReadAllLines(path);

double horizontal = 0;
double vertical = 0;

foreach (var line in inputData)
{
    if (line.StartsWith("forward"))
    {
        horizontal += Char.GetNumericValue(line.Last<char>());
    }
    else if (line.StartsWith("up"))
    {
        vertical += Char.GetNumericValue(line.Last<char>());
    }
    else
    {
        vertical -= Char.GetNumericValue(line.Last<char>());
    }
}

Console.WriteLine("Part 1: " + horizontal * Math.Abs(vertical));


//-------------------Part-2-------------------------

double verticalSec = 0;
double horizontalSec = 0;
double aim = 0;

foreach (var line in inputData)
{
    if (line.StartsWith("forward"))
    {
        horizontalSec += Char.GetNumericValue(line.Last<char>());
        verticalSec += aim * Char.GetNumericValue(line.Last<char>());
    }
    else if (line.StartsWith("up"))
    {
        aim -= Char.GetNumericValue(line.Last<char>());
    }
    else
    {
        aim += Char.GetNumericValue(line.Last<char>());
    }
}
Console.WriteLine("Part 2: " + horizontalSec * Math.Abs(verticalSec));