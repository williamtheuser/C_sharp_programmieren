//B1

//string userInput = Console.ReadLine();

//if (userInput == "42")
//{
//    Console.WriteLine("42: The answer to the ultimate question of life, the universe and everything!");
//}

//else if (Convert.ToInt32(userInput) >=0 && userInput !="42" && userInput !="0")
//{
//    Console.WriteLine("+");
//}

//else if (userInput == "0")
//{
//    Console.WriteLine("Null");
//}

//else if (Convert.ToInt32(userInput) <= 0)
//{
//    Console.WriteLine("-");
//}

//B2


//B3

//Aufgaben C [Kein code notwendig]

//Aufgaben D 

//D1-1 ----------------------------------------------------------------------


for (int i = 10; i < 20; i++)
{
    Console.WriteLine(i.ToString());

}

int counter = 10;

while (counter < 20)
{
    Console.WriteLine(counter.ToString());
    counter++;

}

//D1-2 -----------------------------------------------------------------

for (int j = 2; j < 20; j++)
{
    if (j%2 == 0)
        {
            Console.WriteLine(j.ToString());
        }
}


int counter2 = 2;
while (counter2 < 20)
{
    if (counter2 % 2 == 0)
    {
        Console.WriteLine(counter2.ToString());
    }
    counter2++;

}

//D1-3 ----------------------------------------------------------------------------


for (int k = -1; k < -10; k--)
{
    Console.WriteLine(k);
}


static void Main()
{
    
    int[] primeNumbers = GeneratePrimeNumbers(20);

    int[] fibonacciNumbers = GenerateFibonacciNumbers(20);

    Console.WriteLine("Die ersten 20 Primzahlen sind:");
    PrintArray(primeNumbers);

    Console.WriteLine("\nDie ersten 20 Fibonacci-Zahlen sind:");
    PrintArray(fibonacciNumbers);
}


static int[] GeneratePrimeNumbers(int n)
{
    int[] primes = new int[n];
    int count = 0;
    int number = 2;

    while (count < n)
    {
        if (IsPrime(number))
        {
            primes[count] = number;
            count++;
        }
        number++;
    }

    return primes;
}


static bool IsPrime(int num)
{
    if (num <= 1)
        return false;

    for (int i = 2; i * i <= num; i++)
    {
        if (num % i == 0)
            return false;
    }

    return true;
}


static int[] GenerateFibonacciNumbers(int n)
{
    int[] fibonacci = new int[n];
    fibonacci[0] = 1;
    fibonacci[1] = 1;

    for (int i = 2; i < n; i++)
    {
        fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
    }

    return fibonacci;
}

//array printer weil C# zu "dumm" dafür ist, es direkt zu tun.
static void PrintArray(int[] arr)
{
    foreach (int num in arr)
    {
        Console.Write(num + " ");
    }
    Console.WriteLine();
}



//Aufgaben E
//E1


Console.WriteLine(GenerateFibonacciNumbers(20));

//E2-1

string userIn = Console.ReadLine();

userIn = Convert.ToInt32(userIn);
Console.WriteLine(IsPrime(userIn));

//E2-2
string userIn2 = Console.ReadLine();
userIn2 = Convert.ToInt32(userIn2);
Console.WriteLine(GeneratePrimeNumbers(userIn2));



//E3

    static int EuclideanAlgorithm(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Euklidischer Algorithmus zur Berechnung des ggT");
        Console.Write("Geben Sie die erste Zahl ein: ");
        if (int.TryParse(Console.ReadLine(), out int num1))
        {
            Console.Write("Geben Sie die zweite Zahl ein: ");
            if (int.TryParse(Console.ReadLine(), out int num2))
            {
                int gcd = EuclideanAlgorithm(num1, num2);
                Console.WriteLine($"Der ggT von {num1} und {num2} ist {gcd}");
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe für die zweite Zahl.");
            }
        }
        else
        {
            Console.WriteLine("Ungültige Eingabe für die erste Zahl.");
        }
    }


//F1

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
    if (evenNumbers[evenNumbers.Length - 1] != 0)
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

//F2 

Console.WriteLine(GenerateFibonacciNumbers(20));

//F3

string userIn3 = Console.ReadLine("calculate fibonacci numbers up to:");
Console.WriteLine(GenerateFibonacciNumbers(userIn3));









