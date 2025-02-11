using Application.Services;
using Xunit;

public class CoderByteExcercisesServiceTests
{
    private readonly CoderByteExcercisesService _service = new CoderByteExcercisesService();

    [Fact]
    public void GetLongestWord_ShouldReturnLongestWord()
    {
        Assert.Equal("longest", _service.GetLongestWord("Find the longest word!"));
    }

    [Fact]
    public void GetFactorial_ShouldReturnFactorial()
    {
        Assert.Equal(24, _service.GetFactorial(4));
        Assert.Equal(1, _service.GetFactorial(0));
    }

    [Fact]
    public void ReverseString_ShouldReturnReversed()
    {
        Assert.Equal("olleH", _service.ReverseString("Hello"));
    }

    [Fact]
    public void EncodeLetterChanges_ShouldShiftLettersAndCapitalizeVowels()
    {
        Assert.Equal("gvO Ujnft!", _service.EncodeLetterChanges("fun times!"));
    }

    [Fact]
    public void FormatTimeFromMinutes_ShouldFormatCorrectly()
    {
        Assert.Equal("01:04", _service.FormatTimeFromMinutes(64));
    }

    [Fact]
    public void GetWordWithMostRepeatedLetters_ShouldReturnCorrectWord()
    {
        Assert.Equal("banana", _service.GetWordWithMostRepeatedLetters("apple balloon banana"));
    }

    [Fact]
    public void GetTicTacToeWinner_ShouldIdentifyWinner()
    {
        Assert.Equal('X', _service.GetTicTacToeWinner("XXXOO----"));
        Assert.Equal('-', _service.GetTicTacToeWinner("XOXOXOOXO")); 
        Assert.Equal('O', _service.GetTicTacToeWinner("O---O---O")); 

    }
}
