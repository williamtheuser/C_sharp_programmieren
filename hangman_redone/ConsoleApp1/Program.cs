namespace HangMan; // here use name of your project

class Program
{
    // No variable declarations in this area!!
    static void Main(string[] args)
    {
        string abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string secretWord;
        while (true)                     // The game repeats until finished by player 1
        {
            // Variable declarations allowed here
            ReadSecretWord(ref abc);            // Player 1: Enter the secret word to be guessed by player 2
            HangTheMan();                // Screen output for a good start
            while (true)                 // Player 2: Make your guesses
            {
                ReadOneChar(ref abc);           // Handle input of one char. 
                EvaluateTheSituation();  // Game Logic goes here
                HangTheMan();            // Screen output goes here
            }
            if (QuitOrRestart() == "restart")
            {
                continue;
            }

            else if (QuitOrRestart() == "quit")
            {
                break;
            }
             // Ask if want to quit or start new game
        }
    }

    static string ReadSecretWord(ref string abc, ref string secretWord)
    {
        Console.WriteLine("Type the word to be guessed!");
        bool pass = false;
        secretWord = Console.ReadLine();
        while (pass == false)
        {
            secretWord = Console.ReadLine();
            int matchCounter = 0;
            foreach (char currentCharInput in secretWord)
            {   
                if (abc.Contains(currentCharInput) == false )
                {
                    pass = false;
                }
                else
                {
                    matchCounter++;
                    if (matchCounter == secretWord.Length && secretWord != "")
                    {
                        pass = true; 
                    }
                }
            } 
        }
        return secretWord;
    }

    static string ReadOneChar(ref string abc) // Modification of method declaration recommended: Add return value and parameters
                              // If there are rules and constraints on allowed secrets (e.g. no digits), make sure the input is allowed
    {
        string currentOneChar = Console.ReadKey().ToString();
        bool pass = false;
        while (pass == false) 
        { 
            if (abc.Contains(currentOneChar))
            {
                break;
            }

            else
            {
                    continue;
            }

        }
        return currentOneChar;
    }

    static void EvaluateTheSituation() // Modification of method declaration recommended: Add return value and parameters
                               // In here, evaluate the char entered: Is it part of the secret word?
                                       // Calculate and return the game status (Hit or missed? Where? List and number of missed chars?...)
    {
        // Variable declarations allowed here
        // NO Console.Write() etc. in here!
    }

    static string QuitOrRestart() // Modification of method declaration recommended: Add return value and parameters
        // If there are rules and constraints on allowed secrets (e.g. no digits), check them in here
    {
        Console.WriteLine("quit / restart (Q / N)?");
        string nxtCommand = Console.ReadLine().ToString();
        bool pass = false;
        while (true) 
        { 
            if ("QRqr".Contains(nxtCommand))
                {
                    pass = true;
                }

            else
                {
                    continue;
                }

        }

        if (nxtCommand == "r" || nxtCommand == "R")
        {
            return "restart";
        }

        else if (nxtCommand == "q" || nxtCommand == "Q")
        {
            return "replay";
        }

    }

    static string[] HangTheMan()
    {
        int maxErrors = (int)(secretWord.Length * 0.6);
        string[] frames = new string[maxErrors + 1];
        for (int i = 0; i <= maxErrors; i++)
        {
            string frameFilePath = $"frame{i}.txt";
            frames[i] = System.IO.File.ReadAllText(frameFilePath);
        }
        return frames;
    }
}

