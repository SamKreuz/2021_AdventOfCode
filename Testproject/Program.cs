int[] currentNumArr = new int[2];

currentNumArr[0] = 20;
currentNumArr[1] = 23;


int[] currentNumArr2 = new int[2];

currentNumArr2[0] = 20;
currentNumArr2[1] = 23;

var equal = currentNumArr.SequenceEqual(currentNumArr2);
Console.WriteLine(equal);

//if (currentNumArr == currentNumArr2)
//{
//    Console.WriteLine("They are the same");
//}
//else
//{
//    Console.WriteLine("noooO");
//}


