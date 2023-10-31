namespace hangman_3; // here use name of your project

class Program
{
    // No variable declarations in this area!!
    static void Main(string[] args)
    {
        string abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        while (true)                     // The game repeats until finished by player 1
        {

            ReadSecretWord();
            // Player 1: Enter the secret word to be guessed by player 2
            HangTheMan();                // Screen output for a good start
            while (true)                 // Player 2: Make your guesses
            {
                ReadOneChar(abc);           // Handle input of one char. 
                EvaluateTheSituation();  // Game Logic goes here
                HangTheMan();            // Screen output goes here
            }
            QuitOrRestart(); // Ask if want to quit or start new game
        }
    }

    static string ReadSecretWord(string abc) // Modification of method declaration recommended: Add return value and parameters                          // If there are rules and constraints on allowed secrets (e.g. no digits), check them in here
    {
        while (true)
        {
            string userwordinput = Console.ReadLine();
            foreach (char c in userwordinput)
            {
                if (abc.Contains(c) ==false)
                {
                    
                }

                else
            }

        }
    }

    static string ReadOneChar(string abc)
    {
        while (true)
        {

            Console.WriteLine("Enter your guess! ");
            char inputChar = Console.ReadKey().KeyChar;

            if (abc.Contains(inputChar))
            {
                return inputChar.ToString();
            }

        }
        // Variable declarations allowed here
        // Console.Write() etc. allowed here!
    }

    static void EvaluateTheSituation() // Modification of method declaration recommended: Add return value and parameters
                                       // In here, evaluate the char entered: Is it part of the secret word?
                                       // Calculate and return the game status (Hit or missed? Where? List and number of missed chars?...)
    {
        // Variable declarations allowed here
        // NO Console.Write() etc. in here!
    }

    static void QuitOrRestart() // Modification of method declaration recommended: Add return value and parameters
                                // If there are rules and constraints on allowed secrets (e.g. no digits), check them in here
    {
        // Variable declarations allowed here
        // Console.Write() etc. allowed here!
    }

    static void HangTheMan() // Modification of method declaration recommended: Add return value and parameters
                             // In here, clear the screen and redraw everything reflecting the actual game status
    {
        // Variable declarations allowed here
        // all Console.Write() etc. go here
    }
}

