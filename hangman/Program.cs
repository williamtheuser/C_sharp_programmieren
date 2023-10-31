using System;
using System.Collections.Generic;

namespace HangMan
{
    class Program
    {
        static string secretWord;
        static string guessedWord;
        static int incorrectGuesses;
        static HashSet<char> usedLetters;
        static string[] hangmanFrames;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                secretWord = "";
                guessedWord = "";
                incorrectGuesses = 0;
                usedLetters = new HashSet<char>();
                hangmanFrames = LoadHangmanFrames();

                Console.WriteLine("Welcome to Hangman!");
                Console.WriteLine("Player 1: Enter the secret word (use only uppercase letters):");
                secretWord = ReadSecretWord();

                Console.Clear();
                ShowHangman();

                while (incorrectGuesses < secretWord.Length * 0.6)
                {
                    Console.WriteLine("Secret Word: " + GetGuessedWordDisplay());
                    Console.WriteLine($"Lives left: {secretWord.Length * 0.6 - incorrectGuesses}");
                    Console.WriteLine("Used letters: " + string.Join(", ", usedLetters));

                    char guess = ReadOneChar();
                    if (usedLetters.Contains(guess))
                    {
                        Console.WriteLine("You already guessed that letter. Go grab some coffee!");
                        continue;
                    }

                    usedLetters.Add(guess);

                    EvaluateTheSituation(guess);
                    Console.Clear();
                    ShowHangman();

                    if (guessedWord.Equals(secretWord))
                    {
                        Console.WriteLine("You won! The word is: " + secretWord);
                        break;
                    }
                }

                if (incorrectGuesses >= secretWord.Length * 0.6)
                {
                    Console.WriteLine("Game Over! The word was: " + secretWord);
                }

                QuitOrRestart();
            }
        }

        static string ReadSecretWord()
        {
            string input;
            while (true)
            {
                input = Console.ReadLine().ToUpper();
                if (input.All(char.IsLetter))
                    return input;
                else
                    Console.WriteLine("Invalid input. Use only uppercase letters.");
            }
        }

        static char ReadOneChar()
        {
            char input;
            while (true)
            {
                Console.WriteLine("Player 2: Enter a letter:");
                input = Console.ReadKey().KeyChar;
                input = char.ToUpper(input);
                if (char.IsLetter(input))
                    return input;
                else
                    Console.WriteLine("Invalid input. Please enter a letter.");
            }
        }

        static void EvaluateTheSituation(char guess)
        {
            if (secretWord.Contains(guess))
            {
                Console.WriteLine($"Good guess! {guess} is in the word.");
                for (int i = 0; i < secretWord.Length; i++)
                {
                    if (secretWord[i] == guess)
                    {
                        guessedWord = guessedWord.Substring(0, i) + guess + guessedWord.Substring(i + 1);
                    }
                }
            }
            else
            {
                Console.WriteLine($"Oops! {guess} is not in the word.");
                incorrectGuesses++;
            }
        }

        static void QuitOrRestart()
        {
            Console.WriteLine("Do you want to play again? (Y/N)");
            var key = Console.ReadKey().Key;
            if (key == ConsoleKey.N)
            {
                Environment.Exit(0);
            }
        }

        static string GetGuessedWordDisplay()
        {
            if (string.IsNullOrEmpty(guessedWord))
            {
                guessedWord = new string('_', secretWord.Length);
            }
            return guessedWord;
        }

        static void ShowHangman()
        {
            int frameIndex = Math.Min(incorrectGuesses, hangmanFrames.Length - 1);
            // Display the frame content.
            Console.WriteLine(hangmanFrames[frameIndex]);
        }

        static string[] LoadHangmanFrames()
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
}
