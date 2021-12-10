//Pt. 1 2h
//Pt. 2 3h

string path = "E:/INTERAKTION/CSHARP/2021_AdventOfCode/Day09/input.txt";

var array = File.ReadAllLines(path).Select(x => x.ToCharArray()).ToArray();
int xArray = array[0].Length;   //10
int yArray = array.Length;  //5

List<int[]> lowPoints = new List<int[]>();
//Console.WriteLine(array[1][6]);
//Console.WriteLine(yArray);
int finalVal = 0;




for (int i = 0; i < yArray; i++)
{
    for (int j = 0; j < xArray; j++)
    {
        var hasUpper = i == 0 ? false : true;
        var hasLower = i == yArray - 1 ? false : true;
        var hasLeft = j == 0 ? false : true;
        var hasRight = j == xArray - 1 ? false : true;

        int counter = 0;

        bool corner = (!hasUpper && !hasLeft) || (!hasUpper && !hasRight) || (!hasLower && !hasLeft) || (!hasLower && !hasRight);
        bool side = !hasUpper || !hasLower || !hasRight || !hasLeft;

        if (hasUpper)
        {
            if (array[i][j] < array[i - 1][j])
            {
                counter++;
            }
        }
        if (hasLower)
        {
            if (array[i][j] < array[i + 1][j])
            {

                counter++;
            }
        }
        if (hasRight)
        {
            if (array[i][j] < array[i][j + 1])
            {
                //Console.WriteLine("Value " + array[i][j] + " is lower than " + array[i][j + 1] + " (Right)");
                counter++;
            }
        }
        if (hasLeft)
        {
            if (array[i][j] < array[i][j - 1])
            {
                counter++;
            }
        }

        if (side && !corner)
        {
            //side = 3
            if (counter == 3)
            {
                //Console.WriteLine($"Number {array[i][j]} has {counter} smaller values");
                finalVal += int.Parse(array[i][j].ToString()) + 1;
                int[] mychar = new int[] { i, j };
                lowPoints.Add(mychar);
            }

        }
        else if (corner)
        {
            //corner = 2
            if (counter == 2)
            {
                //Console.WriteLine($"Number {array[i][j]} has {counter} smaller values");
                finalVal += int.Parse(array[i][j].ToString()) + 1;
                int[] mychar = new int[] { i, j };
                lowPoints.Add(mychar);
            }
        }
        else
        {
            //middle = 4
            if (counter == 4)
            {
                //Console.WriteLine($"Number {array[i][j]} has {counter} smaller values");
                finalVal += int.Parse(array[i][j].ToString()) + 1;
                int[] mychar = new int[] { i, j };
                lowPoints.Add(mychar);
            }
        }
    }
}

//Console.WriteLine(finalVal);


//--------------------------------


//Console.WriteLine(lowPoints[0][1]);
lowPoints.ForEach(x => { Console.WriteLine(x[0] + ", " + x[1]); });

//var list = new List<int[]>();
//var nums = new int[] { 4, 6 };
List<int> unorderedList = new List<int>();

//0, 1 -> 1
//0, 9 -> 0
//2, 2 -> 5
//4, 6 -> 5

foreach(var koord in lowPoints)
{
    var list = new List<int[]>();
    CheckSurrounding(koord, list);
    unorderedList.Add(list.Count);
    list.ForEach(x => { Console.WriteLine("List: " + x[0] + ", " + x[1]); });
    Console.WriteLine(" ");
}

var orderedList = unorderedList.OrderByDescending(x => x).ToList();
int result = orderedList[0] * orderedList[1] * orderedList[2];


//ordered.ForEach(x => { Console.WriteLine(x); });
//Console.WriteLine(result);


//CheckSurrounding(nums, list);
//Console.WriteLine("Listcount: " + list.Count);
//list.ForEach(x => { Console.WriteLine(x[0] + ", " + x[1]); });

void CheckSurrounding(int[] koord, List<int[]> koordlist)
{
    var existsInList = koordlist.Any(x => x[0] == koord[0] && x[1] == koord[1]);



    if (!existsInList)
    {
        koordlist.Add(koord);

        var hasUpper = koord[0] == 0 ? false : true;
        var hasLower = koord[0] == yArray - 1 ? false : true;
        var hasLeft = koord[1] == 0 ? false : true;
        var hasRight = koord[1] == xArray - 1 ? false : true;

        int counter = 0;

        //Console.WriteLine("Koord: " + koord[0] + ", " + koord[1]);
        //Console.WriteLine("hasUpper: " + hasUpper);
        //Console.WriteLine("hasLower: " + hasLower);
        //Console.WriteLine("hasLeft: " + hasLeft);
        //Console.WriteLine("hasRight: " + hasRight);


        if (hasUpper)
        {
            int upperKoordVal = int.Parse(array[koord[0] - 1][koord[1]].ToString());
            if (upperKoordVal != 9)
            {
                var upperKoord = new int[] { koord[0] - 1, koord[1] };
                CheckSurrounding(upperKoord, koordlist);
                //Console.WriteLine("Called Upper with " + array[koord[0] - 1] + ", " + array[koord[1]]);
            }
        }



        if (hasLower)
        {
            int lowerKoordVal = int.Parse(array[koord[0] + 1][koord[1]].ToString());
            if (lowerKoordVal != 9)
            {
                var lowerKoord = new int[] { koord[0] + 1, koord[1] };
                CheckSurrounding(lowerKoord, koordlist);
                //Console.WriteLine("Called Lower with " + array[koord[0] + 1] + ", " + array[koord[1]]);
            }

        }


        if (hasLeft)
        {
            int leftKoordVal = int.Parse(array[koord[0]][koord[1] - 1].ToString());
            if (leftKoordVal != 9)
            {
                var leftKoord = new int[] { koord[0], koord[1] - 1 };
                CheckSurrounding(leftKoord, koordlist);
                //Console.WriteLine("Called Left with " + array[koord[0]] + ", " + array[koord[1] - 1]);
            }

        }



        if (hasRight)
        {
            int rightKoordVal = int.Parse(array[koord[0]][koord[1] + 1].ToString());
            if (rightKoordVal != 9)
            {
                var rightKoord = new int[] { koord[0], koord[1] + 1 };
                CheckSurrounding(rightKoord, koordlist);
                //Console.WriteLine("Called Right with " + array[koord[0]] + ", " + array[koord[1] + 1]);
            }
        }
    }


}
