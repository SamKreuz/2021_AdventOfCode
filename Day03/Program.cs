//Pt. 1 = 48min
//Pt. 2 = 90min?

using System.Text;

string path = "E:/INTERAKTION/CSHARP/2021_AdventOfCode/Day03/input.txt";
//string path = "E:/INTERAKTION/CSHARP/2021_AdventOfCode/Day03/testdata.txt";

var inputData = File.ReadAllLines(path);


StringBuilder sb = new StringBuilder();
StringBuilder sbInverted = new StringBuilder();
double finalNum = 0;

for (int i = 0; i < inputData[0].Length; i++)
{
    int ones = 0;
    foreach (var line in inputData)
    {
        ones += (int)Char.GetNumericValue(line[i]);
    }
    if (ones > inputData.Length / 2)
    {
        sb.Append("1");
        sbInverted.Append("0");
    }
    else
    {
        sb.Append('0');
        sbInverted.Append("1");
    }
}

finalNum = BinToDec(sb.ToString()) * BinToDec(sbInverted.ToString());
//Console.WriteLine(finalNum);

double BinToDec(string binary)
{
    double decNum = 0;
    for (int i = binary.Length - 1; i >= 0; i--)
    {
        int index = Math.Abs(i - binary.Length);

        if (binary[i] == '1')
        {
            decNum += Math.Pow(2, index - 1);
        }
    }
    return decNum;
}

//-----------------------------------------------------------


var oxygeninputList = new List<string>(inputData);
double decimalOxygenRating = 0;

for (int i = 0; i < oxygeninputList[0].Length; i++) //binanzahl von links nach rechts durchlaufen
{
    int ones = 0;

    List<int> onesList = new List<int>();
    List<int> zeroesList = new List<int>();

    Console.WriteLine("Listlänge davor ist " + oxygeninputList.Count);

    for(int j = 0; j < oxygeninputList.Count; j++)
    {
        if(oxygeninputList[j][i] == '1')
        {
            onesList.Add(j);
        }
        else
        {
            zeroesList.Add(j);
        }
    }


    if (onesList.Count > zeroesList.Count)
    {
        foreach (int index in zeroesList.OrderByDescending(x => x))
        {
            oxygeninputList.RemoveAt(index);
        }
    }
    else if(onesList.Count < zeroesList.Count)
    {
        foreach (int index in onesList.OrderByDescending(x => x))
        {
            oxygeninputList.RemoveAt(index);
        }
    }
    else
    {
        foreach (int index in zeroesList.OrderByDescending(x => x))
        {
            oxygeninputList.RemoveAt(index);
        }
    }

    if(oxygeninputList.Count == 1)
    {
        decimalOxygenRating = BinToDec(oxygeninputList[0]);
    }
}

var scrubberinputList = new List<string>(inputData);
int bits = scrubberinputList[0].Length;
double decimalScrubberRating = 0;

for (int i = 0; i < bits; i++) //binanzahl von links nach rechts durchlaufen
{
    int ones = 0;

    List<int> onesList = new List<int>();
    List<int> zeroesList = new List<int>();

    Console.WriteLine("Listlänge davor ist " + scrubberinputList.Count);

    for (int j = 0; j < scrubberinputList.Count; j++)
    {
        if (scrubberinputList[j][i] == '1')
        {
            onesList.Add(j);
        }
        else
        {
            zeroesList.Add(j);
        }
    }


    if (onesList.Count < zeroesList.Count)
    {
        foreach (int index in zeroesList.OrderByDescending(x => x))
        {
            scrubberinputList.RemoveAt(index);
        }
    }
    else if (onesList.Count > zeroesList.Count)
    {
        foreach (int index in onesList.OrderByDescending(x => x))
        {
            scrubberinputList.RemoveAt(index);
        }
    }
    else
    {
        foreach (int index in onesList.OrderByDescending(x => x))
        {
            scrubberinputList.RemoveAt(index);
        }
    }

    if (scrubberinputList.Count == 1)
    {
        decimalScrubberRating = BinToDec(scrubberinputList[0]);
    }
}

double finalValue = decimalOxygenRating * decimalScrubberRating;

Console.WriteLine(finalValue);