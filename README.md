# SS_Net_Exercises

## Introduction
This repository is for testing developers' knowledge on C# .NET and MVC.

This application uses the CQRS pattern (commands, validators, queries on a pipeline) and a generic repository pattern:
  - Project Structure
    - __Api__: 
      Is the main project that runs as a web application, it has the configurations, registration of dependencies and controllers implementation.
    - __Application__:
      It covers the CQRS pattern and is where the business logic resides.
    - __Common__: 
      It has the interfaces, base clases and groundwork for the configurations and arquitecture. Normally this is left untouched.
    - __Domain__: 
      Contains the entities definition and other models (or enums) that are used across the different layers.
    - __Persistance__: 
      Holds the entities configurations/mappings and the db context, migrations and seeder.

Tasks:
1. Add migrations:
   - The migration folder must be generated inside the `Persistance` project.
   - The migrations should run atomatically AppDbContextMigrator already setup on the program.cs
   - Confirm that the `/sales/perform-sale` works
2. Add Security
   - Add a login endpoint that checks a user and password and returns an JWT token
   - Secure the `/sales/perform-sale` endpoint by inpecting the JWT token to be present and valid at the Authorization header.
   - As a plus, validate that the user has a specific role.
3. Implement the `GetMonthSalesQueryHandler`
   - Take into account the query parameters `Year` and `Month` (1 is January)
   - Build a Query that grabs all records in the month
   - Use LINQ
5. Implement the `GetPagedSalesQueryHandler`
   - Take into account the query parameters for pagination
   - Build a Query that grabs all records but filter them by the pagination criteria
   - Use LINQ
4. Implement the `GetYearSalesReportQueryHandler`
   - Take into account the `Year` query parameter
   - Build a Query that gets a summary of each month of the specified year
   - Return a list of `SalesForMonthModel` dto as the result
     - A total of 12 entries
     - If there is no data for a specific month, show an entry with zeros.
5. Implement ICoderByteExcercisesService.GetLongestWord
   - Get longest word for text ignoring punctuation characters and whitespace
6. Implement ICoderByteExcercisesService.GetFactorial
   - Get factorial, for example for 4 => (4 * 3 * 2 * 1) = 24
7. Implement ICoderByteExcercisesService.ReverseString
   - Reverse a string without using the built-in function string.Reverse
8. Implement ICoderByteExcercisesService.EncodeLetterChanges
   - Letter changes: Replace every letter in the string with the letter following it in the alphabet (ie. c becomes d, z becomes a)
   - Then capitalize every vowel in this new string
   - Example: "fun times!" => "gvO Ujnft!"
9.  Implement ICoderByteExcercisesService.FormatTimeFromMinutes
    - format to hh:mm, example: 64 => 01:04 
10. Implement ICoderByteExcercisesService.GetWordWithMostRepeatedLetters
    - return the first word with the greatest number of repeated letters.
11. Implement ICoderByteExcercisesService.GetTicTacToeWinner
    - Board is a string of 9 character
    - Each set od 3 chars are one row
    - Determine the winner (X or O)
    - Return - if no winner
    - The - char is for empty cells
12. Add unit tests for the CoderByteExcercisesService