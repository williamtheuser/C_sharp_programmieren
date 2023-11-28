using System;

namespace HangMan
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string secretWord = ReadSecretWord();
                int allowedErrors = CalculateAllowedErrors(secretWord.Length);
                int incorrectGuesses = 0;

                HangTheMan(incorrectGuesses, allowedErrors);

                while (true)
                {
                    char guessedChar = ReadOneChar();
                    bool isCorrectGuess = EvaluateTheSituation(secretWord, guessedChar);

                    if (!isCorrectGuess)
                    {
                        incorrectGuesses++;
                        if (incorrectGuesses >= allowedErrors)
                            break;
                    }

                    HangTheMan(incorrectGuesses, allowedErrors);

                    if (secretWord.All(c => guessedChar == c))
                    {
                        Console.WriteLine("Congratulations! You guessed the word: " + secretWord);
                        break;
                    }
                }

                QuitOrRestart();
            }
        }

        static string ReadSecretWord()
        {
            string secretWord;

            do
            {
                Console.Write("Player 1, enter the secret word (at least 3 letters, only uppercase ASCII): ");
                secretWord = Console.ReadLine().ToUpper();
            } 
            
            while (string.IsNullOrWhiteSpace(secretWord) || secretWord.Length < 3 || !IsValidWord(secretWord));

            return secretWord;
        }

        static bool IsValidWord(string word)
        {
            foreach (char c in word)
            {
                if (c < 'A' || c > 'Z')
                    return false;
            }
            return true;
        }

        static int CalculateAllowedErrors(int wordLength)
        {
            return (int)(0.75 * wordLength);
        }

        static char ReadOneChar()
        {
            char guessedChar;

            do
            {
                Console.Write("Player 2, enter your guess: ");
                char.TryParse(Console.ReadLine()?.ToUpper(), out guessedChar);
            } while (!IsValidGuess(guessedChar));

            return guessedChar;
        }

        static bool IsValidGuess(char guessedChar)
        {
            return guessedChar >= 'A' && guessedChar <= 'Z';
        }

        static bool EvaluateTheSituation(string secretWord, char guessedChar)
        {
            bool isCorrectGuess = secretWord.Contains(guessedChar);
            
            if (!isCorrectGuess)
                Console.WriteLine($"Incorrect guess: {guessedChar}");

            return isCorrectGuess;
        }

        static void HangTheMan(int incorrectGuesses, int allowedErrors)
        {
            int frameStep = (int)(15.0 / allowedErrors);
            int currentFrame = Math.Min(incorrectGuesses * frameStep, 14);

            Console.Clear();
            Console.WriteLine(hangmanFrames[currentFrame]);
        }

        static void QuitOrRestart()
        {
            Console.Write("Do you want to play again? (Y/N): ");
            char restartChoice = Console.ReadKey().KeyChar;
            if (char.ToUpper(restartChoice) != 'Y')
            {
                Environment.Exit(0);
            }
        }

        static string[] hangmanFrames = 
        {
            
    // Frame 0
    @"_________
|/      |
|
|
|
|
|",
    // Frame 1
    @"_________
|/      |
|      (_)
|
|
|
|",
    // Frame 2
    @"_________
|/      |
|      (_)
|       |
|
|
|",
    // Frame 3
    @"_________
|/      |
|      (_)
|      /|
|
|
|",
    // Frame 4
    @"_________
|/      |
|      (_)
|      /|\
|
|
|",
    // Frame 5
    @"_________
|/      |
|      (_)
|      /|\
|      /
|
|",
    // Frame 6
    @"_________
|/      |
|      (_)
|      /|\
|      / \
|
|"
    // Frame 7
};

        };
    }
}
