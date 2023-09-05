
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
