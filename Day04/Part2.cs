//Pt. 1 210min
//Pt. 2 40min
string path = "E:/INTERAKTION/CSHARP/2021_AdventOfCode/Day04/input.txt";
//string path = "E:/INTERAKTION/CSHARP/2021_AdventOfCode/Day04/testdata.txt";

string data = File.ReadAllText(path);

string[] blocks = data.Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
int blocksNum = blocks.Count() - 1;

List<string> blocksOnly = new List<string>();
for (int i = 1; i <= blocks.Count() - 1; i++)
{
    blocksOnly.Add(blocks[i]);
}

var bingoNumsString = blocks[0].Split(',');

var blockLines = blocks[1].Split("\r\n");
int blockLinesNum = blockLines.Count();   //number of lines in a block

var blockLineElements = blockLines[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);
int lineCharNum = blockLineElements.Count();

int[,,] integerArray = new int[blocksNum, blockLinesNum, lineCharNum];
bool[] solvedBlocks = new bool[100];

int winningNum = 0;
int unmarkedSum = 0;
int successfullBingoGames = 0;

int lastSolvedBlock = 0;
int lastBlockSolvedValue;

foreach (var bingoNum in bingoNumsString)
{

    for (int i = 0; i < blocksOnly.Count; i++)
    {
        for (int j = 0; j < blockLinesNum; j++)
        {
            for (int k = 0; k < lineCharNum; k++)
            {
                var currentLines = blocksOnly[i].Split("\r\n");
                var currentElements = currentLines[j].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (bingoNum == currentElements[k])
                {
                    integerArray[i, j, k] = 1;
                    checkForBingo(bingoNum);
                }
            }
        }
    }
}

int finalNum = unmarkedSum * winningNum;
Console.WriteLine("FinalNum: " + finalNum);


int calculalteUnmarkedSum(int blockNum)
{
    int unmarkedSum = 0;
    for (int i = 0; i < blockLinesNum; i++)
    {
        for (var j = 0; j < lineCharNum; j++)
        {
            if (integerArray[blockNum, i, j] == 0)
            {
                unmarkedSum += int.Parse(blocksOnly[blockNum].Split("\r\n")[i].Split(" ", StringSplitOptions.RemoveEmptyEntries)[j]);
            }
        }
    }
    return unmarkedSum;
}

void checkForBingo(string bingonum)
{


    if (successfullBingoGames < 100)
    {
        for (var i = 0; i < blocksOnly.Count; i++)
        {
            for (var j = 0; j < blockLinesNum; j++)
            {
                int horizontalNums = 0;
                for (var k = 0; k < lineCharNum; k++)
                {
                    horizontalNums += integerArray[i, j, k];

                    if (horizontalNums == 5)
                    {
                        if (solvedBlocks[i] == false)
                        {
                            lastSolvedBlock = i;
                            solvedBlocks[i] = true;
                            Console.WriteLine("Winning Element Horizontal: Block " + i + ", Line " + j);
                            //winningNum = int.Parse(blocksOnly[i].Split("\r\n")[j].Split(" ", StringSplitOptions.RemoveEmptyEntries)[k]);
                            successfullBingoGames += 1;
                            break;
                        }
                    }
                }
            }



            for (var j = 0; j < lineCharNum; j++)
            {
                int verticalNums = 0;
                for (var k = 0; k < blockLinesNum; k++)
                {
                    verticalNums += integerArray[i, k, j];

                    if (verticalNums == 5)
                    {
                        if (solvedBlocks[i] == false)
                        {
                            lastSolvedBlock = i;
                            solvedBlocks[i] = true;
                            Console.WriteLine("Winning Element Vertical: " + i + ", " + j);
                            successfullBingoGames += 1;
                            Console.WriteLine("Solved Blocks: " + successfullBingoGames);
                            break;
                        }
                    }
                }
            }
        }
    }
    else
    {
        Console.WriteLine($"Game number 100 is block: {lastSolvedBlock}, Last Bingonum is {bingonum}");
        var finalNum = calculalteUnmarkedSum(lastSolvedBlock) * int.Parse(bingonum);
        Console.WriteLine(finalNum);
    }
}