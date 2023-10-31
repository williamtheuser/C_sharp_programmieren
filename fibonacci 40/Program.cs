


int[] fibonacci = new int[10];



fibonacci[0] = 1;
fibonacci[1] = 1;
fibonacci[2] = 2;
for (int i = 2; i < fibonacci.Length; i++)
{
    if (i==9)
    {
        break;
    }
    fibonacci[i+1] = fibonacci[i] + fibonacci[i-1];
}



foreach (int i in fibonacci)
{
    Console.WriteLine(i);
}

