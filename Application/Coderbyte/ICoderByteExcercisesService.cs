namespace Application.Coderbyte
{
	public interface ICoderByteExcercisesService
	{
		// Get longest word for text ignoring punctuation characters and whitespace
		string GetLongestWord(string fullText);

		// Get factorial, for example for 4 => (4 * 3 * 2 * 1) = 24
		long GetFactorial(long num);

		// reverse a string without using the built-in function string.Reverse
		// Example: "I Love Code" => "edoC evoL I"
		string ReverseString(string text);

		// letter changes: Replace every letter in the string with the letter following it in the alphabet (ie. c becomes d, z becomes a)
		// Then capitalize every vowel in this new string
		// Example: "fun times!" => "gvO Ujnft!"
		string EncodeLetterChanges(string text);

		// format to hh:mm, example: 64 => 01:04 
		string FormatTimeFromMinutes(int minutes);

		// return the first word with the greatest number of repeated letters.
		// For example: "Today, is the greatest day ever!" should return "greatest"
		// because it has 2 e's (and 2 t's) and it comes before ever which also has 2 e's.
		// return empty string if no word found.
		string GetWordWithMostRepeatedLetters(string text);


		// Board is a string of 9 character,
		// First row is index	0,1,2
		// Seconmd row is index 3,4,5
		// Third row is index	6,7,8
		// The allowed characters are X, O and - (represent an empty spot)
		// Return winner (X or O) or "-" if no winner
		string GetTicTacToeWinner(string board);
	}
}
