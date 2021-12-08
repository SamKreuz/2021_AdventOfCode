//Pt. 1 45min
//Pt. 2 120min

using System.Linq;

//string path = "E:/INTERAKTION/CSHARP/2021_AdventOfCode/Day06/testdata.txt";
string path = "E:/INTERAKTION/CSHARP/2021_AdventOfCode/Day06/input.txt";
var data = File.ReadAllText(path);

//var a = data.Split(',',StringSplitOptions.RemoveEmptyEntries).ToList().ConvertAll(int.Parse);
var intList = data.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList<Int32>();

List<int> list = new List<int>();
//LinkedList<Int64> intList 

//for (int i = 0; i <= 80; i++)
//{
//    //Console.WriteLine(intList.Count + " - " + separate(list));
//    Console.WriteLine(intList.Count);
//    Console.WriteLine("Capacity: " + intList.Capacity);
//    //Console.WriteLine(GC.GetTotalMemory(true) + "B");
//    for (int j = 0; j < intList.Count; j++)
//    {
//        intList[j]--;

//        if (intList[j] == -1)
//        {
//            intList[j] = 6;
//            intList.Add(9);
//        }
//    }

//}

//string separate(List<int> list)
//{
//    string joined = string.Join(",", intList);
//    return joined;
//}


//---------------------------------------

long[] nums = new long[9];

long fishnum = 0;

for (int i = 0; i < intList.Count; i++)
{
    nums[intList[i]]++;
    fishnum++;
}

//Console.WriteLine(string.Join(",",nums));
Console.WriteLine("Fishnum Start: " + fishnum);

for (int i = 0; i < 256; i++)
{
    var zeroFish = nums[0];
    for (int j = 0; j <= 8; j++)
    {
        if (j != 8)
        {
            nums[j] = nums[j + 1];
            if (j == 6)
            {
                nums[j] = nums[j + 1];
                nums[j] += zeroFish; //old fish getting back to 6
            }
        }
        else
        {
            nums[j] = zeroFish;  //new fish
        }
    }
    fishnum += zeroFish;

    Console.WriteLine(fishnum);
}