//List<int> possibleDiceOutcomes = new List<int>();
Dictionary<int, int> movesAndMultipliers = new Dictionary<int, int>(); //moves, multiplier
Dictionary<(int, int), int> winningList = new Dictionary<(int, int), int>();   //posPlayer1, posPlayer2, winner

for (int x = 1; x <= 3; x++)
{
    for (int y = 1; y <= 3; y++)
    {
        for (int z = 1; z <= 3; z++)
        {
            if (movesAndMultipliers.ContainsKey(x + y + z)){
                movesAndMultipliers[x + y + z] += 1;
            }
            else
            {
                movesAndMultipliers[(x + y + z)] = 1;
            }
        }
    }
}

long playerOneWon = 0;
long playerTwoWon = 0;

int playerOneStartingPos = 4;
int playerTwoStartingPos = 8;

throwDice(10, 3, 0, 0, 1, true);

void throwDice(int playerOnePos, int playerTwoPos, int playerOneScore, int playerTwoScore, long occurences, bool playerOneMoves)
{
    //Console.WriteLine("ThrowDIce");
    //int throwDiceCallNumber = 0;
    foreach (int fieldsToMove in movesAndMultipliers.Keys)
    {
        long newOccurences = occurences * movesAndMultipliers[fieldsToMove];

        if (playerOneMoves)
        {
            var newPlayerOnePos = movePawn(playerOnePos, fieldsToMove);
            var newPlayerOneScore = playerOneScore + newPlayerOnePos;
            if (newPlayerOneScore >= 21)
            {
                playerOneWon += newOccurences;
            }
            else
            {
                throwDice(newPlayerOnePos, playerTwoPos, newPlayerOneScore, playerTwoScore, newOccurences, false);
            }
        }
        else
        {
            var newPlayerTwoPos = movePawn(playerTwoPos, fieldsToMove);
            var newPlayerTwoScore = playerTwoScore + newPlayerTwoPos;
            if (newPlayerTwoScore >= 21)
            {
                playerTwoWon += newOccurences; ;
            }
            else
            {
                throwDice(playerOnePos, newPlayerTwoPos, playerOneScore, newPlayerTwoScore, newOccurences, true);
                //throwDiceCallNumber++;
            }

        }

    }
}

Console.WriteLine(playerOneWon + ",  " + playerOneWon);

if(playerOneWon > playerTwoWon)
{
    Console.WriteLine(playerOneWon);
}
else
{
    Console.WriteLine(playerTwoWon);
}

int movePawn(int currentPos, int fieldsToMove)
{
    var finalPos = (currentPos + fieldsToMove) % 10;
    if (finalPos == 0) { finalPos = 10; }
    return finalPos;
}

void addScore(int? player)
{
    if (player == 1)
    {
        playerOneWon++;
    }
    else if (player == 2)
    {
        playerTwoWon++;
    }
    else if (player == null)
    {
        Console.WriteLine("Player was Null");
    }
}