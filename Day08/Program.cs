// Pt. 1 30min



using System.Linq;

string path = "E:/INTERAKTION/CSHARP/2021_AdventOfCode/Day08/input.txt";
var data = File.ReadAllLines(path);

List<string> signalPatterns = new List<string>();
List<string> outputValues = new List<string>();

int counter = 0;



foreach (var item in data)
{
    var split = item.Split('|',StringSplitOptions.RemoveEmptyEntries).ToArray();
    signalPatterns.Add(split[0]);
    outputValues.Add(split[1]);
}

foreach (var chars in signalPatterns)
{
    var charSplit = chars.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
    foreach(var i in charSplit)
    {
        if(i.Length == 2 || i.Length == 3 || i.Length == 4 || i.Length == 7)
        {
            //Console.WriteLine(i);
            counter++;
        }
    }
}

//var threelist = signalPatterns[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => x.Length == 3 ? x : null).ToList();

//Console.WriteLine(counter);


//write each line to one list & sort alphabetically     var product = Db.tablename.Where(s => s.colum == DropDownList2.SelectedValue).OrderBy(s => s.Name).ToList();
//index 0-13

//write outcome to another list

//from list with all entries, get all 1, 4, 7, 8 values

//create dict with int & char array

//if length is 5 or 6 -> unknown

// 3 = if 5 char contains 1
// 6 = if 6 char not contains 3
// 9 = if 6 char constains 3
// 2 = if 5 contains (allchrs - 9)
// 5 = if 5 contains (4 - 1) 





//new[] { "a", "b", "c" }.Any(c => s.Contains(c));

//var values = new[] { "abc", "def", "ghj" };
//var str = "abcedasdkljre";
//values.Any(str.Contains);


var stringlist = signalPatterns[0].Split(' ').OrderBy(a => a.Length).ToList();

var one = stringlist.Where(a => a.Length == 2).FirstOrDefault().ToCharArray();
var seven = stringlist.Where(a => a.Length == 3).FirstOrDefault();
var four = stringlist.Where(a => a.Length == 4).FirstOrDefault();
var eight = stringlist.Where(a => a.Length == 7).FirstOrDefault();
var three = stringlist.Where(a => a.Length == 5 && a.Contains(one[0]) && a.Contains(one[1])).FirstOrDefault().ToCharArray();
var nine = stringlist.Where(a => a.Length == 6 && three.Except(a).Count() == 0).First().ToCharArray();
var zero = stringlist.Where(a => a.Length == 6 && a.Except(one).Count() == 4).First().ToCharArray();
var six = stringlist.Where(a => a.Length == 6 && a != new string(nine) && a != new string(zero)).First().ToCharArray();
var five = stringlist.Where(a => a.Length == 5 && nine.Except(a).Count() == 1).First().ToCharArray();
var two = stringlist.Where(a => a.Length == 5 && a != new string(five) && a != new string(three)).First().ToCharArray();

//Dictionary<int, string> map = new Dictionary<int, string>();
//map.Add(0, new string(zero));
//map.Add(1, new string(one));
//map.Add(2, new string(two));
//map.Add(3, new string(three));
//map.Add(4, new string(four));
//map.Add(5, new string(five));
//map.Add(6, new string(six));
//map.Add(7, new string(seven));
//map.Add(8, new string(eight));
//map.Add(9, new string(nine));

List<string> list = new List<string>();
list.Add(new string(zero));
list.Add(new string(one));
list.Add(new string(two));
list.Add(new string(three));
list.Add(new string(four));
list.Add(new string(five));
list.Add(new string(six));
list.Add(new string(seven));
list.Add(new string(eight));
list.Add(new string(nine));

char[] arr = { 'f' };
var outputlist = outputValues[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).OrderBy(a => a.Length).ToList();
//var val = list.Where(a => a.Length == outputlist[0].Length && a.Except(outputlist[0]).Count() == 0).FirstOrDefault()

var data = list.IndexOf(list.Where(a => a.Length == outputlist[0].Length && a.Except(outputlist[0]).Count() == 0));


val.ForEach(a => { Console.WriteLine(a); });


//foreach(var val in outputValues)
//{
//    //for(int i = 0; i < list.Count; i++)
//    //{
//    //    if(val.Except(list[i]).Count)
//    //    {

//    //    }
//    //}

//}

//Console.WriteLine(onestr);

    //string smestring = "sme";
    //var arr3 = smestring.ToCharArray();

    char[] arr1 = { 'a', 'b', 'd', 'f', 'g'};
char[] arr2 = { 'a', 'b', 'c', 'd', 'f', 'g' };
var min = arr1.Except(arr2).ToList();

//min.ForEach(a => { Console.WriteLine(a); });


//var fivelist = stringlist.Where(a => a.Length == 5 && ).ToList();
//var five = fivelist.Where(a => a.Contains(one[0]) && a.Contains(one[1])).FirstOrDefault();

//Console.WriteLine(five);

//lala.ForEach(a => { Console.WriteLine(a); });

bool StringDingBing(string s)
{
    return true;

}

var threelists = stringlist.Where(a => a.Length == 5).ToList();

//Console.WriteLine(doesContain(threelists[2],one));

bool doesContain(string biggerNumber, string containingNumber)
{
    foreach(char c in containingNumber)
    {
        if (!biggerNumber.Contains(c))
        {
            return false;
            break;
        }
    }
    return true;
}

//foreach (var c in threelists)
//{
//    if (c.Contains(one[0]) && c.Contains(one[1]))
//    {
//        three = c;
//    }
//}

//char[] chararray = "fkdölaksdg".ToCharArray();
//string text = "cf";
//var vals = new[] { "c", "f" };
//var ret = vals.Any(teststring.Contains);
//var ret2 = vals.Contains(teststring);
//var boolfinder = text.IndexOfAny(chararray) >= 0;




//three.ForEach(a => { Console.WriteLine(a); });
//Console.WriteLine(three);
//stringlist.ForEach(x => { Console.WriteLine(x); });



foreach (var chars in signalPatterns)
{

    var charSplit = chars.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
    foreach (var i in charSplit)
    {
        if (i.Length == 2 || i.Length == 3 || i.Length == 4 || i.Length == 7)
        {
            //Console.WriteLine(i);
            counter++;
        }
    }
}