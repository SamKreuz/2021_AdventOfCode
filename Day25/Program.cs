string path = "E:/INTERAKTION/CSHARP/2021_AdventOfCode/Day25/input.txt";

var data = File.ReadAllLines(path).Select(x => x.ToCharArray()).ToArray();

int height = data.Count();
int width = data[0].Length;

Dictionary<(int, int), bool> southElements = new Dictionary<(int, int), bool>();
Dictionary<(int, int), bool> eastElements = new Dictionary<(int, int), bool>();

bool stillTrueElements = true;

//List<(int, int, bool)> south = new List<(int, int, bool)>();
//List<(int, int, bool)> east = new List<(int, int, bool)>();

//south.Add((1, 1, false));


for (int i = 0; i < height; i++) //für jede zeile
{
    for (int j = 0; j < width; j++)  //jedes element
    {
        if (data[i][j] == 'v')
        {
            southElements.Add((i, j), false);
        }
        else if (data[i][j] == '>')
        {
            eastElements.Add((i, j), false);
        }
    }
}

int count = 1;

while(stillTrueElements)
{
    UpdateMovables();
    //visualizeResult();
    eastElements = moveElements(eastElements, "east");
    UpdateMovables();
    southElements = moveElements(southElements, "south");
    UpdateMovables();
    count++;
    stillTrueElements = canStillMove();
    
}

visualizeResult();
//UpdateMovables();

Console.WriteLine(count);




void visualizeResult()
{
    char[,] finalArray = new char[height, width];

    for (int x = 0; x < height; x++)
    {
        for (int y = 0; y < width; y++)
        {
            if (southElements.ContainsKey((x, y)))
            {
                finalArray[x, y] = 'v';
            }
            else if (eastElements.ContainsKey((x, y)))
            {
                finalArray[x, y] = '>';
            }
            else
            {
                finalArray[x, y] = '.';
            }
            //finalArray[x, y] = 'x';
            Console.Write(finalArray[x, y]);
        }
        Console.WriteLine();
    }
    Console.WriteLine();

}

//eastElements = moveElements(eastElements);
//UpdateMovables();
//southElements = moveElements(southElements);
//UpdateMovables();



Dictionary<(int, int), bool> moveElements(Dictionary<(int, int), bool> dict, string dir)
{
    Dictionary<(int, int), bool> tempDict = new Dictionary<(int, int), bool>();
    bool southTrue = false;
    bool eastTrue = false;

    if (dir == "south")
    {
        foreach (var elem in southElements)
        {
            if (elem.Value == true)
            {
                southTrue = true;
                var nextIndex = elem.Key.Item1 < height - 1 ? elem.Key.Item1 + 1 : 0;
                tempDict.Add((nextIndex, elem.Key.Item2), false);
                //southElements.Remove((elem.Key.Item1, elem.Key.Item2));
            }
            else
            {
                tempDict.Add((elem.Key.Item1, elem.Key.Item2), elem.Value);
            }
        }
    }
    else if (dir == "east")
    {
        foreach (var elem in eastElements)
        {
            if (elem.Value == true)
            {
                eastTrue = true;
                var nextIndex = elem.Key.Item2 < width - 1 ? elem.Key.Item2 + 1 : 0;
                tempDict.Add((elem.Key.Item1, nextIndex), false);
                //southElements.Remove((elem.Key.Item1, elem.Key.Item2));
            }
            else
            {
                tempDict.Add((elem.Key.Item1, elem.Key.Item2), elem.Value);
            }
        }
    }

    Console.WriteLine(southTrue + ", " + eastTrue);

    if(!southTrue && !eastTrue)
    {
        stillTrueElements = false;
    }
    else
    {
        stillTrueElements = true;
    }


    return tempDict;
}

bool canStillMove()
{
    foreach (var elem in southElements)
    {
        if (elem.Value == true)
        {
            return true;
            break;
        }
    }

    foreach (var elem in eastElements)
    {
        if (elem.Value == true)
        {
            return true;
            break;
        }
    }

    return false;


    //bool southIsEmpty = southElements.Where(x => x.Value == true).Any();
    //bool eastIsEmpty = eastElements.Where(x => x.Value == true).Any();
    //if(southIsEmpty && eastIsEmpty)
    //{
    //    return false;
    //}
    //else
    //{
    //    return true;
    //}

}

bool checkIfMovable(int zeile, int spalte, string movingdir)
{
    if (movingdir == "south")
    {
        int? currentRow = zeile;
        int nextElement = currentRow + 1 < height ? zeile + 1 : 0;
        if (southElements.ContainsKey((nextElement, spalte)) || eastElements.ContainsKey((nextElement, spalte)))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    else if (movingdir == "east")
    {
        int? currentColumn = spalte;
        int nextElement = currentColumn + 1 < width ? spalte + 1 : 0;
        if (southElements.ContainsKey((zeile, nextElement)) || eastElements.ContainsKey((zeile, nextElement)))
        {
            return false;
        }
        else
        {
            return true;
        }

    }
    else
    {
        Console.WriteLine("checkIfMovable returns wrong value");
        return false;
    }
}

void UpdateMovables()
{
    for (int i = 0; i < height; i++) //für jede zeile
    {
        for (int j = 0; j < width; j++)  //jedes element
        {
            //if (data[i][j] == 'v')
            //{
            //    bool movable = checkIfMovable(i, j, "south");
            //    southElements[(i, j)] = movable;
            //}
            //else if (data[i][j] == '>')
            //{
            //    bool movable = checkIfMovable(i, j, "east");
            //    eastElements[(i, j)] = movable;
            //}
            if (southElements.ContainsKey((i, j)))
            {
                bool movable = checkIfMovable(i, j, "south");
                southElements[(i, j)] = movable;
            }
            else if (eastElements.ContainsKey((i, j)))
            {
                bool movable = checkIfMovable(i, j, "east");
                eastElements[(i, j)] = movable;
            }
        }
    }
}