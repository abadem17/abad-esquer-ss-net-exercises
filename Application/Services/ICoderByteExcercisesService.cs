using System;

namespace Application.Services
{
    public interface ICoderByteExcercisesService
    {
        string GetLongestWord(string text);
        int GetFactorial(int number);
        string ReverseString(string text);
        string EncodeLetterChanges(string text);
        string FormatTimeFromMinutes(int minutes);
        string GetWordWithMostRepeatedLetters(string text);
        char GetTicTacToeWinner(string board);
    }
}

