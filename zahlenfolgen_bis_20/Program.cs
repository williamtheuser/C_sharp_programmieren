int[] naturalNubers = new int[20];
int[] evenNumbers = new int[20];
int[] squareNumbers = new int[20];





for (int i = 0; i < 20; i++)
{
    naturalNubers[i] = i;

}


int counter = 0;
int indexCounter = 0;
while (true)
{
    if (counter % 2 == 0)
    {
        evenNumbers[indexCounter] = counter;
        indexCounter++;
    }
    counter++;
    if (evenNumbers[evenNumbers.Length-1] !=0)
    {
        break;
    }
}


for (int k = 0; k < 20; k++)
{
    squareNumbers[k] = k * k;
}

Console.WriteLine(string.Join(",", naturalNubers));
Console.WriteLine(string.Join(",", evenNumbers));
Console.WriteLine(string.Join(",", squareNumbers));
        