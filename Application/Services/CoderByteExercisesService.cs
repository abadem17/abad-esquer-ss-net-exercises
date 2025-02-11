using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Application.Services
{
    public class CoderByteExcercisesService : ICoderByteExcercisesService
    {
        public string GetLongestWord(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            var words = Regex.Replace(text, @"[^\w\s]", "").Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return words.OrderByDescending(w => w.Length).FirstOrDefault() ?? string.Empty;
        }

        public int GetFactorial(int number)
        {
            if (number < 0) throw new ArgumentException("Number must be non-negative.");
            return number == 0 ? 1 : number * GetFactorial(number - 1);
        }

        public string ReverseString(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            char[] reversed = new char[text.Length];
            for (int i = 0; i < text.Length; i++)
                reversed[i] = text[text.Length - 1 - i];

            return new string(reversed);
        }

        public string EncodeLetterChanges(string text)
        {
            char[] result = text.Select(c =>
            {
                if (char.IsLetter(c))
                {
                    char nextChar = c == 'z' ? 'a' : c == 'Z' ? 'A' : (char)(c + 1);
                    return "aeiou".Contains(nextChar) ? char.ToUpper(nextChar) : nextChar;
                }
                return c;
            }).ToArray();

            return new string(result);
        }

        public string FormatTimeFromMinutes(int minutes)
        {
            int hours = minutes / 60;
            int mins = minutes % 60;
            return $"{hours:D2}:{mins:D2}";
        }

        public string GetWordWithMostRepeatedLetters(string text)
        {
            var words = Regex.Replace(text, @"[^\w\s]", "").Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return words.OrderByDescending(word => word.GroupBy(c => c).Max(g => g.Count())).FirstOrDefault() ?? string.Empty;
        }

        public char GetTicTacToeWinner(string board)
        {
            if (board.Length != 9) throw new ArgumentException("Board must be exactly 9 characters long.");

            int[][] winningPatterns = new int[][]
            {
                new[] {0, 1, 2}, new[] {3, 4, 5}, new[] {6, 7, 8}, // Rows
                new[] {0, 3, 6}, new[] {1, 4, 7}, new[] {2, 5, 8}, // Columns
                new[] {0, 4, 8}, new[] {2, 4, 6} // Diagonals
            };

            foreach (var pattern in winningPatterns)
            {
                if (board[pattern[0]] == board[pattern[1]] && board[pattern[1]] == board[pattern[2]] && board[pattern[0]] != '-')
                    return board[pattern[0]];
            }

            return '-';
        
        }
    }
}
