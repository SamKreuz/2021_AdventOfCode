//Pt. 1 30min
//Pt. 2 30min

string path = "E:/INTERAKTION/CSHARP/2021_AdventOfCode/Day07/input.txt";
var data = File.ReadAllText(path);


var splitdata = data.Split(',',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
var highest = splitdata.Max();
var lowest = splitdata.Min();

splitdata.OrderByDescending(x => x).ToList().ForEach(x => { Console.WriteLine(x); });


//Console.WriteLine("Length: " + splitdata.Length);
int loopnum = 0;
int finalval = 0;
for (int i = 0; i < highest; i++)
{
    int fuel = 0;
    foreach (var sub in splitdata)
    {
        fuel += Math.Abs(i - sub);
    }
    //Console.WriteLine(fuel);
    if (i == 0 || fuel < finalval)
    {
        finalval = fuel;
        loopnum = i;
    }

}

Console.WriteLine("Loopnum: " + loopnum);
Console.WriteLine("Finalval: " + finalval);






//int finalval = 0;
//for (int i = 0; i < highest; i++)
//{
//    int fuel = 0;
//    foreach (var sub in splitdata)
//    {
//        var steps = Math.Abs(i - sub);
//        var fuelCost = 0;
//        for (int j = 1; j <= steps; j++)
//        {
//            fuelCost += j;
//        }
//        fuel += fuelCost;
//        //Console.WriteLine("fc:" + i + ", " + fuelCost);
//    }
//    Console.WriteLine(i + ", " + fuel);
//    if (i == 0 || fuel < finalval)
//    {
//        finalval = fuel;
//    }
//}

//Console.WriteLine("Final: " + finalval);
