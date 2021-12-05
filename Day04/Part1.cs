////Pt. 1 3,5h

//string path = "E:/INTERAKTION/CSHARP/2021_AdventOfCode/Day04/input.txt";
////string path = "E:/INTERAKTION/CSHARP/2021_AdventOfCode/Day04/testdata.txt";

//string data = File.ReadAllText(path);

//string[] blocks = data.Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
//int blocksNum = blocks.Count() - 1;

//List<string> blocksOnly = new List<string>();
//for (int i = 1; i <= blocks.Count() - 1; i++)
//{
//    blocksOnly.Add(blocks[i]);
//}

//var bingoNumsString = blocks[0].Split(',');

//var blockLines = blocks[1].Split("\r\n");
//int blockLinesNum = blockLines.Count();   //number of lines in a block

//var blockLineElements = blockLines[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);
//int lineCharNum = blockLineElements.Count();

//int[,,] integerArray = new int[blocksNum, blockLinesNum, lineCharNum];

//bool bingo = false;
//int winningNum = 0;
//int unmarkedSum = 0;

//foreach (var bingoNum in bingoNumsString)
//{
//    if(bingo == false)
//    {
//        for (int i = 0; i < blocksOnly.Count; i++)
//        {
//            for (int j = 0; j < blockLinesNum; j++)
//            {
//                for (int k = 0; k < lineCharNum; k++)
//                {
//                    var currentLines = blocksOnly[i].Split("\r\n");
//                    var currentElements = currentLines[j].Split(" ", StringSplitOptions.RemoveEmptyEntries);

//                    if (bingoNum == currentElements[k] && bingo == false)
//                    {
//                        integerArray[i, j, k] = 1;
//                        checkForBingo();

//                        if (bingo)
//                        {
//                            winningNum = int.Parse(bingoNum);
//                            Console.WriteLine("Winning num " + winningNum);

//                            unmarkedSum = calculalteUnmarkedSum(i);
//                            Console.WriteLine("Unmakred Sum: " + unmarkedSum);
//                            break;
//                        }
//                    }
//                }
//            }
//        }
//    }
//}

//int finalNum = unmarkedSum * winningNum;
//Console.WriteLine("FinalNum: " + finalNum);


//int calculalteUnmarkedSum(int blockNum)
//{
//    int unmarkedSum = 0;
//    for(int i = 0; i< blockLinesNum; i++)
//    {
//        for(var j = 0;j < lineCharNum; j++)
//        {
//            if(integerArray[blockNum,i,j] == 0)
//            {
//                unmarkedSum += int.Parse(blocksOnly[blockNum].Split("\r\n")[i].Split(" ", StringSplitOptions.RemoveEmptyEntries)[j]);
//            }
//        }
//    }
//    return unmarkedSum;
//}

//void checkForBingo()
//{
//    if(bingo == false)
//    {
//        for (var i = 0; i < blocksOnly.Count; i++)
//        {
//            for (var j = 0; j < blockLinesNum; j++)
//            {
//                int horizontalNums = 0;
//                for (var k = 0; k < lineCharNum; k++)
//                {
//                    horizontalNums += integerArray[i, j, k];

//                    if (horizontalNums == 5)
//                    {
//                        Console.WriteLine("Winning Element Horizontal: Block " + i + ", Line " + j);
//                        //winningNum = int.Parse(blocksOnly[i].Split("\r\n")[j].Split(" ", StringSplitOptions.RemoveEmptyEntries)[k]);
//                        bingo = true;
//                        break;
//                    }
//                }
//            }



//            for (var j = 0; j < lineCharNum; j++)
//            {
//                int verticalNums = 0;
//                for (var k = 0; k < blockLinesNum; k++)
//                {
//                    verticalNums += integerArray[i, k, j];

//                    if (verticalNums == 5)
//                    {
//                        Console.WriteLine("Winning Element Vertical: " + i + ", " + j);
//                        //winningNum = int.Parse(blocksOnly[i].Split("\r\n")[k].Split(" ", StringSplitOptions.RemoveEmptyEntries)[j]);
//                        bingo = true;
//                        break;
//                    }
//                }
//            }
//        }
//    }

//}



////Console.WriteLine("WinningNum: " + winningNum);
////Console.WriteLine("Intarray: " + integerArray[2, 1, 4]);
////Console.WriteLine("ElementFinder: " + blocksOnly[2].Split("\r\n")[0].Split(" ", StringSplitOptions.RemoveEmptyEntries)[4]);