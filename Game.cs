using System;

namespace Hangman
{
    internal class Game
    {
        public static bool PlayGame = true;
        public static int lives = 7;
        static public string? word, PlayAgain;
        static public string? letter; // Keep as string to handle full words as well
        static public string guessedWord = ""; // Initialize to an empty string.

        public static void SetupGame()
        {
            Console.Clear();
            Console.WriteLine("Pick a word:");
            word = Console.ReadLine()?.ToLower();
            Console.Clear();

            StartGame();
        }

        public static void StartGame()
        {
            while (PlayGame)
            {
                letter = GuessLetter(); // Get the letter guessed by the player.

                AddLetterToGuessedLetters(letter);
                IsLetterInWord();
                IsLifeLeft();
                IsWordGuessed();
            }
        }

        private static string GuessLetter()
        {
            Console.WriteLine("Guess a letter or the whole word. The word is {0} characters long.", word?.Length);
            return Console.ReadLine()?.ToLower(); // Return the guessed letter or word.
        }

        // Adds guessed letter to a string of guessed letters
        public static void AddLetterToGuessedLetters(string guessedLetter)
        {
            guessedWord += guessedLetter; // Append the guessed letter
            Console.WriteLine("Guessed letters: " + guessedWord);
        }

        // Checks if the guessed letter is in the word
        public static void IsLetterInWord()
        {
            if (word.Contains(letter) && letter.Length == 1)
            {
                Console.WriteLine("You guessed a correct letter: " + letter);
            }
            else if (letter.Length > 1 && letter == word)
            {
                Console.WriteLine("You guessed the correct word: " + letter);
                AskToPlayAgain();
            }
            else
            {
                WrongLettersGuessed();
            }
        }

        static void IsWordGuessed()
        {
            if (guessedWord.Length == word.Length && guessedWord == word)
            {
                Console.WriteLine("Congratulations! You've guessed the word: " + word);
                AskToPlayAgain();
            }
        }

        static void IsLifeLeft()
        {
            if (lives <= 0)
            {
                Console.WriteLine("You've lost all lives! The word was: " + word);
                AskToPlayAgain();
            }
        }

        // Checks if the player loses a life
        public static void LostALife()
        {
            lives--;
            Console.WriteLine("You lost a life. You have {0} lives left.", lives);
        }

        // Displays the wrong guessed letters
        public static void WrongLettersGuessed()
        {
            Console.WriteLine("Wrong letter guessed: " + letter);
            LostALife();
        }

        // Asks the player if they want to play again
        public static void AskToPlayAgain()
        {
            Console.WriteLine("Do you want to play again? (yes/no)");
            PlayAgain = Console.ReadLine()?.ToLower();
            if (PlayAgain == "yes")
            {
                SetupGame();
            }
            else
            {
                ExitGame();
            }
        }

        // Exits the game
        public static void ExitGame()
        {
            Console.WriteLine("Thanks for playing! Press any key to exit.");
            Console.ReadKey();
        }
    }
}
