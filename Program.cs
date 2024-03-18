using System;
using System.Linq;

class Mastermind
{
    static void Main(string[] args)
    {
        string secretNumber = GenerateSecretNumber();

        Console.WriteLine("Welcome to Mastermind!");
        Console.WriteLine("Guess the 4-digit number. Each digit is unique and between 1 and 6.");
        Console.WriteLine("You have 10 attempts.");

        bool isGuessedCorrectly = false;
        int attempts = 0;
        while (attempts < 10)
        {
            Console.WriteLine($"\nAttempt {attempts + 1} of 10");
            Console.Write("Enter your guess: ");
            string? guess = Console.ReadLine();

            if (guess == null || !IsValidGuess(guess))
            {
                Console.WriteLine(
                    "Invalid input. Your guess must be 4 digits long, with each unique digit between 1 and 6."
                );
                continue;
            }

            attempts++;

            string feedback = GetFeedback(secretNumber, guess);
            if (feedback == "++++")
            {
                Console.WriteLine("Congratulations! You've guessed the number correctly!");
                isGuessedCorrectly = true;
                break;
            }
            else
            {
                Console.WriteLine($"Feedback: {feedback}");
            }
        }

        if (!isGuessedCorrectly)
        {
            Console.WriteLine($"You've run out of attempts. The secret number was: {secretNumber}");
        }
    }

    static string GenerateSecretNumber()
    {
        Random random = new Random();
        return string.Concat(Enumerable.Range(1, 6).OrderBy(x => random.Next()).Take(4));
    }

    static bool IsValidGuess(string guess)
    {
        return guess.Length == 4
            && guess.All(c => c >= '1' && c <= '6')
            && guess.Distinct().Count() == 4;
    }

    static string GetFeedback(string secret, string guess)
    {
        int correctPositions = 0;
        int[] digitCounts = new int[6];

        // Count correct positions and occurrences of each digit in the secret number
        for (int i = 0; i < 4; i++)
        {
            if (guess[i] == secret[i])
            {
                correctPositions++;
            }
            else
            {
                digitCounts[secret[i] - '1']++;
            }
        }

        int correctButWrongPosition = 0;
        // Count correct but wrongly positioned digits based on previous counts
        for (int i = 0; i < 4; i++)
        {
            if (guess[i] != secret[i] && digitCounts[guess[i] - '1'] > 0)
            {
                correctButWrongPosition++;
                digitCounts[guess[i] - '1']--;
            }
        }

        return new string('+', correctPositions) + new string('-', correctButWrongPosition);
    }
}
