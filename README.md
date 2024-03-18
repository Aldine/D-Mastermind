# Mastermind Game in C#

## Overview

This C# console application is a simple version of the classic game Mastermind. The game challenges players to guess a secret four-digit number, with each digit ranging from 1 to 6, and provides feedback on the accuracy of their guesses.

## How the Game Works

- At the start of the game, a random four-digit number is generated as the "secret number." Each digit within this number is unique and falls between 1 and 6.
- Players have a total of 10 attempts to guess the secret number correctly.
- For each guess, the game provides feedback in the form of plus (+) and minus (-) signs:
  - A plus sign (+) indicates a digit that is both correct and in the correct position.
  - A minus sign (-) indicates a digit that is correct but in the wrong position.
  - No feedback is provided for incorrect digits.
- The game continues until the player correctly guesses the secret number or exhausts all 10 attempts.

## Implementation Details

### Main Components

The application consists of the following key components and functions:

- `Main` Method: The entry point of the application, responsible for orchestrating the game flow.
- `GenerateSecretNumber` Function: Randomly generates the secret four-digit number.
- `IsValidGuess` Function: Validates the player's guess to ensure it is a four-digit number with each digit between 1 and 6 and that all digits are unique.
- `GetFeedback` Function: Compares the player's guess against the secret number and generates feedback based on the accuracy of the guess.

### Game Flow

1. The game starts by generating a secret number and welcoming the player.
2. The player is prompted to enter a guess and receives immediate feedback.
3. This process repeats for up to 10 attempts or until the correct number is guessed.
4. The game ends if the player guesses correctly or runs out of attempts, at which point the correct answer is revealed.