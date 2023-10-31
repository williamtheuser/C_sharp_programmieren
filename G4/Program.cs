

using System.Diagnostics.Metrics;
using System.Xml;

static int strlen(string x)
{
	int counter = 0;
	while (true)
	{	
		try 
		{
			char a = x[counter];
			counter++;
        }
		catch
		{
			break;
		}
	 }
	return counter;
}


string hello = "Hello world";

Console.WriteLine(strlen(hello));

static int frequency(string input, string charToFind)
{
	int count = 0;
	foreach (char a in input)
	{
		if (a.ToString() == charToFind)
		{
            count++;
        }
		
	}

	return count;
}


Console.WriteLine(frequency(hello, "l"));




static string PositionOfChar(string inputStr, string charToFindPos)
{
	int counter = 0;
    string output = "";
    foreach (char current in inputStr)
	{
		if (current.ToString() == charToFindPos)
		{
			output = output + counter.ToString() + ",";
		}

		counter++;
	}

	return output;

}

Console.WriteLine(PositionOfChar(hello, "l"));

static string[] Wslice(string input, string splitchar)
{

	int counter = 0;

    string[] arr = new string[frequency(input, splitchar.ToString())+1];
	input = input + " ";
	string inputCopy = input;
	int foundCounter = 0;

    foreach (char current in input)
    {
        if (current.ToString() == splitchar)
        {
			string currentElement = input.Substring(0, counter);
			Console.WriteLine(currentElement);
			int before = strlen(input);

			Console.WriteLine(input);
			input = input.Substring(input.IndexOf(currentElement.Last())+1);
            Console.WriteLine(input);
            int after = strlen(input);
			counter = counter - (before - after);

            arr[foundCounter] = currentElement;
			foundCounter++;

			
        }
        else if (frequency(input, splitchar) == 0)
		{
			arr[foundCounter + 1] = input;
		}
        counter++;
    }
	return arr;
}

Console.WriteLine(string.Join("," , Wslice("das ist ein satz", " ")));


