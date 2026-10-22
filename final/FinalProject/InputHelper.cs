using System;
using System.Collections.Generic;

/// <summary>
/// Helper utility class for safe, crash-proof console input handling.
/// Eliminates FormatException, NullReferenceException, and IndexOutOfRangeException runtime errors.
/// </summary>
public static class InputHelper
{
    /// <summary>
    /// Repeatedly prompts the user until a valid integer within the optional [min, max] range is supplied.
    /// </summary>
    public static int ReadInt(string prompt, int? min = null, int? max = null)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (input == null)
            {
                throw new EndOfStreamException("End of input stream reached.");
            }

            if (int.TryParse(input, out int result))
            {
                if (min.HasValue && result < min.Value)
                {
                    Console.WriteLine($"Value must be at least {min.Value}. Please try again.");
                    continue;
                }
                if (max.HasValue && result > max.Value)
                {
                    Console.WriteLine($"Value must be at most {max.Value}. Please try again.");
                    continue;
                }
                return result;
            }

            Console.WriteLine("Invalid number. Please enter a valid whole number.");
        }
    }

    /// <summary>
    /// Prompts the user until a non-empty string is provided.
    /// </summary>
    public static string ReadNonEmptyString(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (input == null)
            {
                throw new EndOfStreamException("End of input stream reached.");
            }

            input = input.Trim();
            if (!string.IsNullOrEmpty(input))
            {
                return input;
            }
            Console.WriteLine("Input cannot be empty. Please enter a value.");
        }
    }

    /// <summary>
    /// Displays a 1-based numbered list of items and prompts the user to select one safely.
    /// Returns default(T) if list is empty.
    /// </summary>
    public static T SelectFromList<T>(string prompt, IReadOnlyList<T> items, Func<T, string> displayFunc)
    {
        if (items == null || items.Count == 0)
        {
            return default;
        }

        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {displayFunc(items[i])}");
        }

        int choice = ReadInt(prompt, 1, items.Count);
        return items[choice - 1];
    }

    /// <summary>
    /// Displays a prompt and waits for the user to press the Enter key.
    /// </summary>
    public static void PressEnter(string message = "Press Enter to continue...")
    {
        Console.WriteLine();
        Console.Write(message);
        Console.ReadLine();
    }
}
