//Pt. 1 3h
//Pt. 2 40min


string path = "E:/INTERAKTION/CSHARP/2021_AdventOfCode/Day10/input.txt";

var data = File.ReadAllLines(path).ToList();

char[] round = new char[] { '(', ')', };
char[] curly = new char[] { '{', '}' };
char[] square = new char[] { '[', ']' };
char[] angle = new char[] { '<', '>' };

List<char> opening = new List<char> { '(', '{', '[', '<' };
List<char> closing = new List<char> { ')', '}', ']', '>' };

List<string> remainingChars = new List<string>();
Dictionary<char, int> illegalChars = new Dictionary<char, int>();
illegalChars.Add(')', 0);
illegalChars.Add('}', 0);
illegalChars.Add(']', 0);
illegalChars.Add('>', 0);


for (int line = 0; line < data.Count; line++)
{
    //Console.WriteLine("Linestart: " + data[line]);

    int i = 0;
    bool corrupt = false;
    bool reachedBound = false;

    while (!reachedBound && !corrupt)    //runs through each line multiple times
    {
        //Console.WriteLine("index: " + i + ", Länge: " + data[line].Length);
        if (i + 1 < data[line].Length) //to not get out of bounds
        {
            if (opening.Contains(data[line][i]) && closing.Contains(data[line][i + 1])) //any opening and closing after
            {
                //Console.WriteLine("Opening and Closing: " + data[line][i] + ", " + data[line][i + 1]);

                var index = opening.IndexOf(data[line][i]);
                if (data[line][i + 1] == closing[index])    //if from the same type, delete
                {
                    data[line] = data[line].Remove(i, 2);
                    i = -1;
                    //Console.WriteLine(data[line]);
                }
                else //corrupt, stop all
                {
                    corrupt = true;
                    //Console.WriteLine($"Corrupt letters are {data[line][i]} and {data[line][i + 1]}");
                    illegalChars[data[line][i + 1]] += 1;
                }
            }
            i++;
        }
        else //reached boundary
        {
            reachedBound = true;
            //Console.WriteLine("Boundary was reached: " + data[line]);
            char[] normalstring = data[line].ToCharArray();
            Array.Reverse(normalstring);
            string reversedString = new string(normalstring);
            string replacedString = reversedString.Replace('(', ')').Replace('[', ']').Replace('{', '}').Replace('<', '>');
            remainingChars.Add(replacedString);
        }

    }

}


double finalVal = 0;


finalVal += illegalChars[')'] * 3;
finalVal += illegalChars[']'] * 57;
finalVal += illegalChars['}'] * 1197;
finalVal += illegalChars['>'] * 25137;

//Console.WriteLine(finalVal);

//--------------------------------------

List<long> allVals = new List<long>();

foreach (var elem in remainingChars)
{
    long totalScore = 0;
    foreach (char c in elem)
    {
        totalScore *= 5;

        switch (c)
        {
            case ')':
                totalScore += 1;
                break;
            case ']':
                totalScore += 2;
                break;
            case '}':
                totalScore += 3;
                break;
            case '>':
                totalScore += 4;
                break;

        }
    }
    allVals.Add(totalScore);
}

allVals.Sort();
int finalIndex = allVals.Count / 2;
long finalFinalVal = allVals[finalIndex];

Console.WriteLine(finalFinalVal);