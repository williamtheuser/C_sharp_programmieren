namespace HangMan; // here use name of your project

class Program
{
    // No variable declarations in this area!!
    static void Main(string[] args)
    {
        string allowedInput = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        while (true)                     // The game repeats until finished by player 1
        {
            // Variable declarations allowed here
            ReadSecretWord();          // Player 1: Enter the secret word to be guessed by player 2
            HangTheMan(0); // Screen output for a good start
            while (true)                 // Player 2: Make your guesses
            {
                ReadOneChar();           // Handle input of one char. 
                EvaluateTheSituation();  // Game Logic goes here
                HangTheMan();            // Screen output goes here
            }
            QuitOrRestart(); // Ask if want to quit or start new game
        }
    }

    string void ReadSecretWord() // Modification of method declaration recommended: Add return value and parameters
                                 // If there are rules and constraints on allowed secrets (e.g. no digits), check them in here
    {
        Console.WriteLine("Enter the word to be guessed: ");
        string secretWord = Console.ReadLine()

    }

    static string ReadOneChar() // Modification of method declaration recommended: Add return value and parameters
                              // If there are rules and constraints on allowed secrets (e.g. no digits), make sure the input is allowed
    {
        Console.WriteLine("enter you guess: ");
        
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

    static void HangTheMan(int x) // Modification of method declaration recommended: Add return value and parameters
                             // In here, clear the screen and redraw everything reflecting the actual game status
    {
        try
            {
            // Specify the path to the file you want to read
            string filePath = string.Format("C:\\Users\\willi\\Downloads\\hangmanframes\\frame{0}.txt", x);

            // Read the file content into a string
            string fileContent = File.ReadAllText(filePath);

            // Now, 'fileContent' contains the content of the file as a string
            Console.WriteLine("File Content:");
            Console.WriteLine(fileContent);

            }

        catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
    }
}

