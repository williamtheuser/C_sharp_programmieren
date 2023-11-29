using System.Security.Cryptography.X509Certificates;

namespace HangMan; // here use name of your project

class Program
{
    // No variable declarations in this area!!
    static void Main(string[] args)
    {
        string abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";


        // Variable declarations allowed here
        while (true)                     // The game repeats until finished by player 1
        {
            // Variable declarations allowed here
            Console.WriteLine("Enter a word to be guessed!");
            string secretWord = ReadSecretWord(abc);  // Player 1: Enter the secret word to be guessed by player 2
            string blanks = "";
            HangTheMan(0); // Screen output for a good start
            int errors = 0;
            for (int i = 0; i < secretWord.Length; i++)
            {
                blanks = blanks + "_";
            }

            string missedChars = "";
            bool game = true;
            while (game)                 // Player 2: Make your guesses
                

            {
                Console.Clear();
                HangTheMan(errors);
                Console.WriteLine(blanks);
                
                Console.WriteLine("Enter your guess: ");
                char guessedChar = ReadOneChar(abc);           // Handle input of one char. 
                Console.WriteLine(" ");
                Console.WriteLine("Guessed Letters: " + missedChars);
                


                EvaluateTheSituation(secretWord, guessedChar, ref errors, ref blanks, ref missedChars, ref game);  // Game Logic goes here
                HangTheMan(errors);            // Screen output goes here
            }
            QuitOrRestart(); // Ask if want to quit or start new game
        }
    }

    static string ReadSecretWord(string abc) // Modification of method declaration recommended: Add return value and parameters
                                 // If there are rules and constraints on allowed secrets (e.g. no digits), check them in here
    {
        int counter = 0;
        bool pass = false;
        string secretword = "";
        
        while (pass == false)
        {
            secretword = Console.ReadLine();
            foreach (char currentChar in secretword)
            {
                if(abc.Contains(currentChar) == false)
                {
                    continue;
                }
                
                else
                {
                    counter++;
                }
            }
            if (counter == secretword.Length)
            {
                break;
            }
        }

        return secretword;
        
        
        // Variable declarations allowed here
        // Console.Write() etc. allowed here!
    }

    static char ReadOneChar(string abc)
    {
        char currentchar;

        while (true)
        {
            
            char currentCharGuess = Console.ReadKey().KeyChar;
            

            if (abc.Contains(char.ToUpper(currentCharGuess)))
            {
                return currentCharGuess;
            }

        }
    }


    static void EvaluateTheSituation(string wordToCheck, char userguess, ref int errors, ref string blanks, ref string missedChars, ref bool game) // Modification of method declaration recommended: Add return value and parameters
                                       // In here, evaluate the char entered: Is it part of the secret word?
                                       // Calculate and return the game status (Hit or missed? Where? List and number of missed chars?...)
    {
        char[] blanksList = new char[blanks.Length];
        

        for (int i = 0; i < blanks.Length; i++)
        {
            blanksList[i] = blanks[i];
        }

        
        
        
        //Console.WriteLine(string.Join(",", blanksList));
        if (wordToCheck.Contains(userguess))
        {
            int indexOfguessedChar = wordToCheck.IndexOf(userguess);
            string result = "";
            blanksList[indexOfguessedChar] = wordToCheck[indexOfguessedChar];
            for (int i = indexOfguessedChar + 1; i < wordToCheck.Length; i++)
            {
                if (wordToCheck[i] == userguess)
                {
                    blanksList[i] = wordToCheck[i];
                }
            }

            if (!blanksList.Contains('_'))
            {
                game = false;
                result = new string(blanksList);
                Console.WriteLine("You have guessed the word: " + result);
            }
            else
            {
                blanks = new string(blanksList); // Update blanks only if there are still underscores
            }


        }

        else
        {
            
            errors++;
            if (errors == 6)
            {
                game = false;
                Console.WriteLine("You have lost. The word was: " + wordToCheck);
            }

            else
            {
                missedChars = missedChars + userguess;
            }
        }
    }

    static void QuitOrRestart() // Modification of method declaration recommended: Add return value and parameters
                                // If there are rules and constraints on allowed secrets (e.g. no digits), check them in here
    {

        
        // Console.Write() etc. allowed here!
    }

    static void HangTheMan(int errors) // Modification of method declaration recommended: Add return value and parameters
                             // In here, clear the screen and redraw everything reflecting the actual game status
    {

        string[] frames = {
            @"
            ----+
            |	|
             	|
              	|
              	|
        ==========
        ",

         @"

            ----+
            |	|
            0	|
              	|
              	|
        ==========
        ",


        @"

            ----+
            |	|
            0	|
            |	|
            	|
        ==========
        ",


        @"

            ----+
            |	|
            0	|
           /|	|
            	|
        ==========
        ",


        @"

            ----+
            |	|
            0	|
           /|\	|
             	|
        ==========
        ",


        @"

            ----+
            |	|
            0	|
           /|\	|
           / 	|
        ==========
        ",


        @"

            ----+
            |	|
            0	|
           /|\	|
           / \	|
        ==========
        "
        };

        Console.WriteLine(frames[errors]);
    }
}