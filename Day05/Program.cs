//Pt. 1 120min
//Pt. 2 120min

// See https://aka.ms/new-console-template for more information
using System.Text;

Console.WriteLine("Hello, World!");
string path = "E:/INTERAKTION/CSHARP/2021_AdventOfCode/Day05/input.txt";
//string path = "E:/INTERAKTION/CSHARP/2021_AdventOfCode/Day05/testdata.txt";

var data = File.ReadAllLines(path);

List<string> firstVals = new List<string>();
List<string> secondVals = new List<string>();
List<int[]> allVals = new List<int[]>();
int doubleCoordinate = 0;
List<int[]> overLapping = new List<int[]>();

foreach (string line in data)
{
    var splitString = line.Split("->", StringSplitOptions.RemoveEmptyEntries);
    firstVals.Add(splitString[0]);
    secondVals.Add(splitString[1]);
}

for (int i = 0; i < data.Length; i++)
{
    var firstValsStrings = firstVals[i].Split(',', StringSplitOptions.TrimEntries);
    var secondValsStrings = secondVals[i].Split(',', StringSplitOptions.TrimEntries);
    int zerofirst = int.Parse(firstValsStrings[0]);
    int onefirst = int.Parse(firstValsStrings[1]);
    int zerosecond = int.Parse(secondValsStrings[0]);
    int onesecond = int.Parse(secondValsStrings[1]);   

    if (zerofirst == zerosecond)
    {
        //Console.WriteLine(firstVals[i] + ", " + secondVals[i]);
        if(onefirst  < onesecond) {
            //Console.WriteLine("onefirst is smaller");
            var currentNum = onefirst;
            while(currentNum <= onesecond)
            {
                int[] currentNumArr = new int[2];
                currentNumArr[0] = zerofirst;
                currentNumArr[1] = currentNum;

                //Console.WriteLine("Arr: " + currentNumArr[0] + ", " + firstValsStrings[0]);
                if (allVals.Any(p => p.SequenceEqual(currentNumArr)))
                {
                    if (!overLapping.Any(p => p.SequenceEqual(currentNumArr)))
                    {
                        overLapping.Add(currentNumArr);
                    }
                }
                else
                {
                    allVals.Add(currentNumArr);
                }
                currentNum++;
            }
        }
        else
        {
            var currentNum = onefirst;
            while (currentNum >= onesecond)
            {
                int[] currentNumArr = new int[2];
                currentNumArr[0] = zerofirst;
                currentNumArr[1] = currentNum;

                if (allVals.Any(p => p.SequenceEqual(currentNumArr)))
                {
                    if(!overLapping.Any(p => p.SequenceEqual(currentNumArr)))
                    {
                        overLapping.Add(currentNumArr);
                    }
                }
                else
                {
                    allVals.Add(currentNumArr);
                }
                currentNum--;
            }
        }
    }else if(onefirst == onesecond) {
        
        if (zerofirst < zerosecond)
        {
            var currentNum = zerofirst;
            
            while (currentNum <= zerosecond)
            {
                int[] currentNumArr = new int[2];
                currentNumArr[0] = currentNum;
                currentNumArr[1] = onefirst;
                //Console.WriteLine("Arr: " + currentNumArr[0] + ", " + currentNumArr[1]);
                if (allVals.Any(p => p.SequenceEqual(currentNumArr)))
                {
                    //Console.WriteLine("Contains yes");
                    if (!overLapping.Any(p => p.SequenceEqual(currentNumArr)))
                    {
                        overLapping.Add(currentNumArr);
                    }
                }
                else
                {
                    //Console.WriteLine("Contains no");
                    allVals.Add(currentNumArr);
                }

                
                currentNum++;
            }
        }
        else
        {
            var currentNum = zerofirst;
            while (currentNum >= zerosecond)
            {
                int[] currentNumArr = new int[2];
                currentNumArr[0] = currentNum;
                currentNumArr[1] = onefirst;

                if (allVals.Any(p => p.SequenceEqual(currentNumArr)))
                {
                    if (!overLapping.Any(p => p.SequenceEqual(currentNumArr)))
                    {
                        overLapping.Add(currentNumArr);
                    }
                }
                else
                {
                    allVals.Add(currentNumArr);
                }
                currentNum--;
            }
        }
    }
    else //weder horizontal noch vertikal
    {
        int steps = Math.Abs(zerosecond - zerofirst);
        //Console.WriteLine("Steps: " + steps + "; " + zerosecond + ", " + zerofirst);
        int zeroincrement = zerofirst < zerosecond ? 1 : -1;
        int oneincrement = onefirst < onesecond ? 1 : -1;

        int[]storeData = new int[2] { zerofirst, onefirst };

        for (int j = 0; j <= steps; j++)
        {
            //Console.WriteLine("increment new: " + currentNumArr[0] + ", " + currentNumArr[1]);

            int[] currentNumArr = new int[2];
            if(j != 0)
            {
                currentNumArr[0] = storeData[0] + zeroincrement;
                currentNumArr[1] = storeData[1] + oneincrement;
                storeData = currentNumArr;
            }
            else
            {
                currentNumArr = storeData;
            }


            if (allVals.Any(p => p.SequenceEqual(currentNumArr)))   //if already in list of all...
            {
                if (!overLapping.Any(p => p.SequenceEqual(currentNumArr)))  //...and not in list of doubles...
                {
                    overLapping.Add(currentNumArr); //..write it to list of doubles
                    //Console.WriteLine("allVlas:" + currentNumArr[0] + ", " + currentNumArr[1]);
                }
            }
            else
            {
                allVals.Add(currentNumArr);
                Console.WriteLine("addendnum:" + currentNumArr[0] + ", " + currentNumArr[1]);
            }


        }
    }
}


foreach(var intPair in overLapping)
{
    Console.WriteLine("OV: " + intPair[0] + ", " + intPair[1] + "\r\n");
}

Console.WriteLine(overLapping.Count);