namespace MVCCodeChallenges.Migrations
{
	using Models;
	using System.Collections.Generic;
	using System.Data.Entity.Migrations;
	using System.Linq;

	internal sealed class Configuration : DbMigrationsConfiguration<CodeChallengesDB>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = true;
			AutomaticMigrationDataLossAllowed = false;
		}

		protected override void Seed(CodeChallengesDB context)
		{
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data. E.g.
			//
			//    context.People.AddOrUpdate(
			//      p => p.FullName,
			//      new Person { FullName = "Andrew Peters" },
			//      new Person { FullName = "Brice Lambson" },
			//      new Person { FullName = "Rowan Miller" }
			//    );
			//

			// STEP 1 of 3: add the code challenges
			var challenges = new List<Challenge>
			{
				new Challenge
				{
					// ClassPath must be fully namespaced and include dll reference e.g. assembly_path.ClassName,dllName)
					ClassPath = "CodeChallengesBL.ConcreteClasses.CodeChallenge01_NumStringAdder,CodeChallengesBL",
					Sequence = 10,
					Year = "2014",
					Name = "Code Challenge #1 - Number String Adder",
					UriTitle = "num-string-adder",
					Description = "The number string adder takes all of the numbers out of an alphanumerical string and return the numbers found summed together, e.g. dywi23jssi88sjdhj1 would return 22.",
					ImageFilenameNoExtension = "pencil"
				},
				new Challenge
				{
					ClassPath = "CodeChallengesBL.ConcreteClasses.CodeChallenge02_RomanNumerals,CodeChallengesBL",
					Sequence = 20,
					Year = "2014",
					Name = "Code Challenge #2 - Roman Numerals",
					UriTitle = "roman-numerals",
					Description = "Takes any Roman Numeral string and returns the decimal value.",
					ImageFilenameNoExtension = "clock"
				},
				new Challenge
				{
					ClassPath = "CodeChallengesBL.ConcreteClasses.CodeChallenge03_FizzBuzz,CodeChallengesBL",
					Sequence = 30,
					Year = "2014",
					Name = "Code Challenge #3 - Fizz Buzz",
					UriTitle = "fizzbuzz",
					Description = "If the number is divisible by 3 print out \"fizz\".  If the number is divisible by 5 print out \"buzz\".  If the number is a prime number, print out \"prime\"",
					ImageFilenameNoExtension = "beer"
				},
				new Challenge
				{
					ClassPath = "CodeChallengesBL.ConcreteClasses.CodeChallenge04_SOLIDShapes,CodeChallengesBL",
					Sequence = 40,
					Year = "2014",
					Name = "Code Challenge #4 - SOLID Shapes",
					UriTitle = "solid-shapes",
					Description = "Prints out the area of various shapes.  This challenge is more to illustrate the back-end code adhering to SOLID design principles",
					ImageFilenameNoExtension = "tent"
				},
				new Challenge
				{
					ClassPath = "CodeChallengesBL.ConcreteClasses.CodeChallenge05_ParenBalancing,CodeChallengesBL",
					Sequence = 50,
					Year = "2014",
					Name = "Code Challenge #5 - Paren Balancing",
					UriTitle = "paren-balancing",
					Description = "Determines if a string containing parentheses is balanced or not.",
					ImageFilenameNoExtension = "gps"
				},
				new Challenge
				{
					ClassPath = "CodeChallengesBL.ConcreteClasses.CodeChallenge06_CaesarCipher,CodeChallengesBL",
					Sequence = 60,
					Year = "2014",
					Name = "Code Challenge #6 - Caesar Cipher",
					UriTitle = "caesar-cipher",
					Description = "Implementation of a basic encrypt and decrypt for a string using a Caesar Cipher. (More info at: http://en.wikipedia.org/wiki/Caesar_cipher)",
					ImageFilenameNoExtension = "safe"
				},
				new Challenge
				{
					ClassPath = "CodeChallengesBL.ConcreteClasses.CodeChallenge07_CarWashThread,CodeChallengesBL",
					Sequence = 70,
					Year = "2014",
					Name = "Code Challenge #7 - Car Wash Thread",
					UriTitle = "carwash-thread",
					Description = "Illustration of threaded programming.  Creates a car wash with a single washing bay.  The threads will be cars.  If the car wash bay is full, the car/thread needs to wait for it to become open.  If the car wash bay is empty, the car can get washed.  It takes 2 seconds to wash the car once it's in the washing bay.",
					ImageFilenameNoExtension = "vespa"
				},
				new Challenge
				{
					ClassPath = "CodeChallengesBL.ConcreteClasses.CodeChallenge08_LoremIpsumGenerator,CodeChallengesBL",
					Sequence = 80,
					Year = "2014",
					Name = "Code Challenge #8 - Lorem Ipsum Generator",
					UriTitle = "lorem-ipsum",
					Description = "Generates variants of Lorem Ipsum text with a specified number of words.",
					ImageFilenameNoExtension = "cake"
				},
				new Challenge
				{
					ClassPath = "CodeChallengesBL.ConcreteClasses.CodeChallenge09_PalindromeCheck,CodeChallengesBL",
					Sequence = 90,
					Year = "2014",
					Name = "Code Challenge #9 - Palindrome Checker",
					UriTitle = "palindromes",
					Description = "Checks whether a sequence of characters are the same from left to right or right to left (disregarding punctation and case).  For valid integers, the binary format of the number is checked.",
					ImageFilenameNoExtension = "headphonehq"
				},
				new Challenge
				{
					ClassPath = "CodeChallengesBL.ConcreteClasses.CodeChallenge10_SudokuValidator,CodeChallengesBL",
					Sequence = 100,
					Year = "2014",
					Name = "Code Challenge #10 - Sudoku Validator",
					UriTitle = "sudoku",
					Description = "Validates a grid so that each column, each row, and each of the sub-grids (also known as blocks) contain all of the digits from 1 to the max number allowed on the grid. (More info at: http://en.wikipedia.org/wiki/Sudoku)",
					ImageFilenameNoExtension = "gamepad"
				},
				new Challenge
				{
					ClassPath = "CodeChallengesBL.ConcreteClasses.CodeChallenge11_Coupon,CodeChallengesBL",
					Sequence = 110,
					Year = "2014",
					Name = "Code Challenge #11 - Coupon Design",
					UriTitle = "coupon",
					Description = "Illustrates back-end design of a coupon code that one could use to give a discount on an eCommerce site. Check is performed for a valid coupon.",
					ImageFilenameNoExtension = "wallet"
				},
				new Challenge
				{
					ClassPath = "CodeChallengesBL.ConcreteClasses.CodeChallenge12_LinkedList,CodeChallengesBL",
					Sequence = 120,
					Year = "2014",
					Name = "Code Challenge #12 - LinkedList",
					UriTitle = "linked-list",
					Description = "Demonstrates back-end implementation of a linked list without using any pre-defined data structures.",
					ImageFilenameNoExtension = "submarine"
				},
				new Challenge
				{
					ClassPath = "CodeChallengesBL.ConcreteClasses.CodeChallenge13_Recursion,CodeChallengesBL",
					Sequence = 130,
					Year = "2014",
					Name = "Code Challenge #13 - Factorial",
					UriTitle = "factorial",
					Description = "Returns the factorial of a number using recursion on the back-end.  The factorial is equal to the product of n and every integer preceding it. For example: 5! = 1 x 2 x 3 x 4 x 5 = 120",
					ImageFilenameNoExtension = "meteor"
				},
				new Challenge
				{
					ClassPath = "CodeChallengesBL.ConcreteClasses.CodeChallenge14_ChangeMachine,CodeChallengesBL",
					Sequence = 140,
					Year = "2014",
					Name = "Code Challenge #14 - Change Machine",
					UriTitle = "change-machine",
					Description = "Implementation of a change machine that, given a U.S. currency value, determines the FEWEST number of bills and coins to return for change, listing out the exact change. Assumes $1, $5, $10, $20, $50, $100 bills and penny, nickel, dime, quarter coins for the denominations",
					ImageFilenameNoExtension = "coins"
				},
				new Challenge
				{
					ClassPath = "CodeChallengesBL.ConcreteClasses._2015_Q1.CodeChallenge01_AlphanumericSorter,CodeChallengesBL",
					Sequence = 210,
					Year = "2015-Q1",
					Name = "Code Challenge #1 - Alphanmueric Sorter",
					UriTitle = "alphanumeric-sorter",
					Description = "Orders alphanumeric string array first by letter, then by number, e.g. a2 would come before a12",
					ImageFilenameNoExtension = "gps"
				},
				new Challenge
				{
					ClassPath = "CodeChallengesBL.ConcreteClasses._2015_Q1.CodeChallenge02_ChangeMachine,CodeChallengesBL",
					Sequence = 220,
					Year = "2015-Q1",
					Name = "Code Challenge #2 - Change Machine",
					UriTitle = "change-machine-2015",
					Description = "Implementation of a change machine that, given a U.S. currency value, determines the FEWEST number of bills and coins to return for change, listing out the exact change. Assumes $1, $5, $10, $20, $50, $100 bills and penny, nickel, dime, quarter coins for the denominations",
					ImageFilenameNoExtension = "coins"
				},
				new Challenge
				{
					ClassPath = "CodeChallengesBL.ConcreteClasses._2015_Q1.CodeChallenge03_AlphanumericStringAdder,CodeChallengesBL",
					Sequence = 230,
					Year = "2015-Q1",
					Name = "Code Challenge #3 - Alphanumeric String Adder",
					UriTitle = "alphanumeric-string-adder",
					Description = "Searches for all the numbers in a string, adds them together, then returns that final number divided by the total amount of letters in the string.",
					ImageFilenameNoExtension = "pencil"
				},
				new Challenge
				{
					ClassPath = "CodeChallengesBL.ConcreteClasses._2015_Q1.CodeChallenge04_MathExpressions,CodeChallengesBL",
					Sequence = 240,
					Year = "2015-Q1",
					Name = "Code Challenge #4 - Mathmatical Expressions",
					UriTitle = "math-expressions",
					Description = "Evaluate a basic mathematical expression with integers. For example, if the string was 2+(3-1)*3, the output should be 8. If the string was (2-0)(6/2), the output should be 6",
					ImageFilenameNoExtension = "vespa"
				}
			};
			
			challenges.ForEach(cs => context.Challenges.AddOrUpdate(c => c.UriTitle, cs));
			context.SaveChanges();

			// STEP 2 of 3: add the UI inputs required for each code challenge
			var challengeInputs = new List<ChallengeInput>
			{
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "num-string-adder").ChallengeId,
					InputElement = "input", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "num-string-adder").UriTitle + "10", // append sequence to ensure uniqueness for form post
					InputTypeAttr = "text", 
					Sequence = 10, 
					InstructionText = "Enter string from which to extract/add numbers: "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "roman-numerals").ChallengeId,
					InputElement = "input", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "roman-numerals").UriTitle + "10",
					InputTypeAttr = "text", 
					Sequence = 10, 
					InstructionText = "Enter a Roman Numeral to get its numerical value: "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "fizzbuzz").ChallengeId,
					InputElement = "input", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "fizzbuzz").UriTitle + "10",
					InputTypeAttr = "text", 
					Sequence = 10, 
					InstructionText = "Enter the max number for the fizzbuzz loop (e.g. to print out numbers 1-100, enter 100): "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "solid-shapes").ChallengeId,
					InputElement = "select", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "solid-shapes").UriTitle + "5",
					InputTypeAttr = "dropdown", 
					Sequence = 5, 
					InstructionText = "Choose how many shapes you want to calculate the area for: "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "solid-shapes").ChallengeId,
					InputElement = "select", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "solid-shapes").UriTitle + "10",
					InputTypeAttr = "dropdown", 
					Sequence = 10, 
					InstructionText = "Choose the first shape to calculate the area for: "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "solid-shapes").ChallengeId,
					InputElement = "select", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "solid-shapes").UriTitle + "30",
					InputTypeAttr = "dropdown", 
					Sequence = 30, 
					InstructionText = "Choose the second shape to calculate the area for: "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "solid-shapes").ChallengeId,
					InputElement = "select", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "solid-shapes").UriTitle + "50",
					InputTypeAttr = "dropdown", 
					Sequence = 50, 
					InstructionText = "Choose the third shape to calculate the area for: "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "solid-shapes").ChallengeId,
					InputElement = "input", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "solid-shapes").UriTitle + "20",
					InputTypeAttr = "text", 
					Sequence = 20, 
					InstructionText = "Enter shape #1's desired width (for circles/squares, this is the diameter/length of any side, respectively).  \n For rectangles, enter the width x height (e.g. 140x150), no spaces: "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "solid-shapes").ChallengeId,
					InputElement = "input", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "solid-shapes").UriTitle + "40",
					InputTypeAttr = "text", 
					Sequence = 40, 
					InstructionText = "Enter shape #2's desired width (for circles/squares, this is the diameter/length of any side, respectively).  \n For rectangles, enter the width x height (e.g. 140x150), no spaces: "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "solid-shapes").ChallengeId,
					InputElement = "input", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "solid-shapes").UriTitle + "60",
					InputTypeAttr = "text", 
					Sequence = 60, 
					InstructionText = "Enter shape #3's desired width (for circles/squares, this is the diameter/length of any side, respectively).  \n For rectangles, enter the width x height (e.g. 140x150), no spaces: "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "paren-balancing").ChallengeId,
					InputElement = "input", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "paren-balancing").UriTitle + "10",
					InputTypeAttr = "text", 
					Sequence = 10, 
					InstructionText = "Enter string to check for balanced parentheses: "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "caesar-cipher").ChallengeId,
					InputElement = "input", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "caesar-cipher").UriTitle + "10",
					InputTypeAttr = "text", 
					Sequence = 10, 
					InstructionText = "Enter text to encrypt using Caesar Cipher: "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "caesar-cipher").ChallengeId,
					InputElement = "input", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "caesar-cipher").UriTitle + "20",
					InputTypeAttr = "text", 
					Sequence = 20, 
					InstructionText = "Enter the shift position (e.g. for abc -> bcd, enter 1): "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "carwash-thread").ChallengeId,
					InputElement = "input", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "carwash-thread").UriTitle + "10",
					InputTypeAttr = "text", 
					Sequence = 10, 
					InstructionText = "Enter comma-separated car names (any name will do) to add to the car wash bay: "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "lorem-ipsum").ChallengeId,
					InputElement = "input", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "lorem-ipsum").UriTitle + "10",
					InputTypeAttr = "text", 
					Sequence = 10, 
					InstructionText = "Enter the number of words you would like to generate: "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "lorem-ipsum").ChallengeId,
					InputElement = "select", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "lorem-ipsum").UriTitle + "20",
					InputTypeAttr = "dropdown", 
					Sequence = 20, 
					InstructionText = "Select the content type of Lorem Ipsum text to generate: "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "palindromes").ChallengeId,
					InputElement = "input", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "palindromes").UriTitle + "10",
					InputTypeAttr = "text", 
					Sequence = 10, 
					InstructionText = "Enter text to check if it is a palindrome (a string containing only numbers will check its binary format): "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "sudoku").ChallengeId,
					InputElement = "select", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "sudoku").UriTitle + "10",
					InputTypeAttr = "dropdown", 
					Sequence = 10, 
					InstructionText = "Choose a sudoku grid size: "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "sudoku").ChallengeId,
					InputElement = "input", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "sudoku").UriTitle + "20",
					InputTypeAttr = "text", 
					Sequence = 20, 
					InstructionText = "Enter numbers (optionally separated by space or comma) for row 1: "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "sudoku").ChallengeId,
					InputElement = "input", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "sudoku").UriTitle + "30",
					InputTypeAttr = "text", 
					Sequence = 30, 
					InstructionText = "Enter numbers (optionally separated by space or comma) for row 2: "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "sudoku").ChallengeId,
					InputElement = "input", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "sudoku").UriTitle + "40",
					InputTypeAttr = "text", 
					Sequence = 40, 
					InstructionText = "Enter numbers (optionally separated by space or comma) for row 3: "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "sudoku").ChallengeId,
					InputElement = "input", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "sudoku").UriTitle + "50",
					InputTypeAttr = "text", 
					Sequence = 50, 
					InstructionText = "Enter numbers (optionally separated by space or comma) for row 4: "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "sudoku").ChallengeId,
					InputElement = "input", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "sudoku").UriTitle + "60",
					InputTypeAttr = "text", 
					Sequence = 60, 
					InstructionText = "Enter numbers (optionally separated by space or comma) for row 5: "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "sudoku").ChallengeId,
					InputElement = "input", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "sudoku").UriTitle + "70",
					InputTypeAttr = "text", 
					Sequence = 70, 
					InstructionText = "Enter numbers (optionally separated by space or comma) for row 6: "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "sudoku").ChallengeId,
					InputElement = "input", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "sudoku").UriTitle + "80",
					InputTypeAttr = "text", 
					Sequence = 80, 
					InstructionText = "Enter numbers (optionally separated by space or comma) for row 7: "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "sudoku").ChallengeId,
					InputElement = "input", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "sudoku").UriTitle + "90",
					InputTypeAttr = "text", 
					Sequence = 90, 
					InstructionText = "Enter numbers (optionally separated by space or comma) for row 8: "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "sudoku").ChallengeId,
					InputElement = "input", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "sudoku").UriTitle + "100",
					InputTypeAttr = "text", 
					Sequence = 100, 
					InstructionText = "Enter numbers (optionally separated by space or comma) for row 9: "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "coupon").ChallengeId,
					InputElement = "input", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "coupon").UriTitle + "10",
					InputTypeAttr = "text", 
					Sequence = 10, 
					InstructionText = "Enter coupon code (limit 10 alphanumeric characters, no spaces): "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "coupon").ChallengeId,
					InputElement = "input", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "coupon").UriTitle + "20",
					InputTypeAttr = "text", 
					Sequence = 20, 
					InstructionText = "Enter discount percent (must be a valid percentage, e.g. 25 or 0.25): "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "coupon").ChallengeId,
					InputElement = "input", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "coupon").UriTitle + "30",
					InputTypeAttr = "text", 
					Sequence = 30, 
					InstructionText = "Enter expiration date (must be a valid date in the future, M/dd/yyyy format, e.g. 8/12/2020): "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "linked-list").ChallengeId,
					InputElement = "input", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "linked-list").UriTitle + "10",
					InputTypeAttr = "text", 
					Sequence = 10, 
					InstructionText = "Enter space-separated values to add to the linked list: "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "linked-list").ChallengeId,
					InputElement = "input", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "linked-list").UriTitle + "20",
					InputTypeAttr = "text", 
					Sequence = 20, 
					InstructionText = "Type index to get value at: "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "linked-list").ChallengeId,
					InputElement = "input", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "linked-list").UriTitle + "30",
					InputTypeAttr = "text", 
					Sequence = 30, 
					InstructionText = "Type index to set value at: "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "linked-list").ChallengeId,
					InputElement = "input", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "linked-list").UriTitle + "40",
					InputTypeAttr = "text", 
					Sequence = 40, 
					InstructionText = "Type new value to set at this index: "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "linked-list").ChallengeId,
					InputElement = "input", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "linked-list").UriTitle + "50",
					InputTypeAttr = "text", 
					Sequence = 50, 
					InstructionText = "Type index to remove value at: "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "factorial").ChallengeId,
					InputElement = "input", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "factorial").UriTitle + "10",
					InputTypeAttr = "text", 
					Sequence = 10, 
					InstructionText = "Enter number for factorial calculation: "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "change-machine").ChallengeId,
					InputElement = "input", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "change-machine").UriTitle + "10",
					InputTypeAttr = "text", 
					Sequence = 10, 
					InstructionText = "Enter the exact change to compute (no $ signs), e.g. 5.26: "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "alphanumeric-sorter").ChallengeId,
					InputElement = "input", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "alphanumeric-sorter").UriTitle + "10",
					InputTypeAttr = "text", 
					Sequence = 10, 
					InstructionText = "Enter the alphanumeric strings you want to sort, separated by spaces or commas: "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "change-machine-2015").ChallengeId,
					InputElement = "input", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "change-machine-2015").UriTitle + "10",
					InputTypeAttr = "text", 
					Sequence = 20, 
					InstructionText = "Enter the exact change to compute (no $ signs), e.g. 5.26: "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "alphanumeric-string-adder").ChallengeId,
					InputElement = "input", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "alphanumeric-string-adder").UriTitle + "10",
					InputTypeAttr = "text", 
					Sequence = 10, 
					InstructionText = "Enter string from which to calculate result: "
				},
				new ChallengeInput 
				{
					ChallengeId = challenges.Single(c => c.UriTitle == "math-expressions").ChallengeId,
					InputElement = "input", 
					InputNameAttr = challenges.Single(c => c.UriTitle == "math-expressions").UriTitle + "10",
					InputTypeAttr = "text", 
					Sequence = 10, 
					InstructionText = "Enter a mathmatical expression using only +, -, /, *, (, ), and digits 0-9: "
				}
			};

			challengeInputs.ForEach(ci => context.ChallengeInputs.AddOrUpdate(i => i.InputNameAttr, ci));
			context.SaveChanges();

			// STEP 3 of 3: add pre-populated input data (i.e. dropdown values)
			var dropdownVals = new List<InputLookupValue>
			{
				new InputLookupValue
				{
					GroupId = challengeInputs.Single(ci => ci.InputNameAttr == "solid-shapes5").ChallengeInputId,
					InputName = challengeInputs.Single(ci => ci.InputNameAttr == "solid-shapes5").InputNameAttr,
					Value = "1",
					Display = "1",
					Sequence = 10
				},
				new InputLookupValue
				{
					GroupId = challengeInputs.Single(ci => ci.InputNameAttr == "solid-shapes5").ChallengeInputId,
					InputName = challengeInputs.Single(ci => ci.InputNameAttr == "solid-shapes5").InputNameAttr,
					Value = "2",
					Display = "2",
					Sequence = 20
				},
				new InputLookupValue
				{
					GroupId = challengeInputs.Single(ci => ci.InputNameAttr == "solid-shapes5").ChallengeInputId,
					InputName = challengeInputs.Single(ci => ci.InputNameAttr == "solid-shapes5").InputNameAttr,
					Value = "3",
					Display = "3",
					Sequence = 30
				},
				new InputLookupValue
				{
					GroupId = challengeInputs.Single(ci => ci.InputNameAttr == "solid-shapes10").ChallengeInputId,
					InputName = challengeInputs.Single(ci => ci.InputNameAttr == "solid-shapes10").InputNameAttr,
					Value = "Rectangle",
					Display = "Rectangle",
					Sequence = 10
				},
				new InputLookupValue
				{
					GroupId = challengeInputs.Single(ci => ci.InputNameAttr == "solid-shapes10").ChallengeInputId,
					InputName = challengeInputs.Single(ci => ci.InputNameAttr == "solid-shapes10").InputNameAttr,
					Value = "Circle",
					Display = "Circle",
					Sequence = 20
				},
				new InputLookupValue
				{
					GroupId = challengeInputs.Single(ci => ci.InputNameAttr == "solid-shapes10").ChallengeInputId,
					InputName = challengeInputs.Single(ci => ci.InputNameAttr == "solid-shapes10").InputNameAttr,
					Value = "Square",
					Display = "Square",
					Sequence = 30
				},
				new InputLookupValue
				{
					GroupId = challengeInputs.Single(ci => ci.InputNameAttr == "solid-shapes30").ChallengeInputId,
					InputName = challengeInputs.Single(ci => ci.InputNameAttr == "solid-shapes30").InputNameAttr,
					Value = "Rectangle",
					Display = "Rectangle",
					Sequence = 40
				},
				new InputLookupValue
				{
					GroupId = challengeInputs.Single(ci => ci.InputNameAttr == "solid-shapes30").ChallengeInputId,
					InputName = challengeInputs.Single(ci => ci.InputNameAttr == "solid-shapes30").InputNameAttr,
					Value = "Circle",
					Display = "Circle",
					Sequence = 50
				},
				new InputLookupValue
				{
					GroupId = challengeInputs.Single(ci => ci.InputNameAttr == "solid-shapes30").ChallengeInputId,
					InputName = challengeInputs.Single(ci => ci.InputNameAttr == "solid-shapes30").InputNameAttr,
					Value = "Square",
					Display = "Square",
					Sequence = 60
				},
				new InputLookupValue
				{
					GroupId = challengeInputs.Single(ci => ci.InputNameAttr == "solid-shapes50").ChallengeInputId,
					InputName = challengeInputs.Single(ci => ci.InputNameAttr == "solid-shapes50").InputNameAttr,
					Value = "Rectangle",
					Display = "Rectangle",
					Sequence = 70
				},
				new InputLookupValue
				{
					GroupId = challengeInputs.Single(ci => ci.InputNameAttr == "solid-shapes50").ChallengeInputId,
					InputName = challengeInputs.Single(ci => ci.InputNameAttr == "solid-shapes50").InputNameAttr,
					Value = "Circle",
					Display = "Circle",
					Sequence = 80
				},
				new InputLookupValue
				{
					GroupId = challengeInputs.Single(ci => ci.InputNameAttr == "solid-shapes50").ChallengeInputId,
					InputName = challengeInputs.Single(ci => ci.InputNameAttr == "solid-shapes50").InputNameAttr,
					Value = "Square",
					Display = "Square",
					Sequence = 90
				},
				new InputLookupValue
				{
					GroupId = challengeInputs.Single(ci => ci.InputNameAttr == "lorem-ipsum20").ChallengeInputId,
					InputName = challengeInputs.Single(ci => ci.InputNameAttr == "lorem-ipsum20").InputNameAttr,
					Value = "1",
					Display = "Lorem Ipsum",
					Sequence = 10
				},
				new InputLookupValue
				{
					GroupId = challengeInputs.Single(ci => ci.InputNameAttr == "lorem-ipsum20").ChallengeInputId,
					InputName = challengeInputs.Single(ci => ci.InputNameAttr == "lorem-ipsum20").InputNameAttr,
					Value = "2",
					Display = "Bacon Ipsum",
					Sequence = 20
				},
				new InputLookupValue
				{
					GroupId = challengeInputs.Single(ci => ci.InputNameAttr == "lorem-ipsum20").ChallengeInputId,
					InputName = challengeInputs.Single(ci => ci.InputNameAttr == "lorem-ipsum20").InputNameAttr,
					Value = "3",
					Display = "Riker Ipsum",
					Sequence = 30
				},
				new InputLookupValue
				{
					GroupId = challengeInputs.Single(ci => ci.InputNameAttr == "sudoku10").ChallengeInputId,
					InputName = challengeInputs.Single(ci => ci.InputNameAttr == "sudoku10").InputNameAttr,
					Value = "9",
					Display = "9x9",
					Sequence = 10
				},
				new InputLookupValue
				{
					GroupId = challengeInputs.Single(ci => ci.InputNameAttr == "sudoku10").ChallengeInputId,
					InputName = challengeInputs.Single(ci => ci.InputNameAttr == "sudoku10").InputNameAttr,
					Value = "4",
					Display = "4x4",
					Sequence = 20
				},
				new InputLookupValue
				{
					GroupId = challengeInputs.Single(ci => ci.InputNameAttr == "sudoku10").ChallengeInputId,
					InputName = challengeInputs.Single(ci => ci.InputNameAttr == "sudoku10").InputNameAttr,
					Value = "6",
					Display = "6x6",
					Sequence = 30
				}
			};

			dropdownVals.ForEach(dd => context.InputLookupValues.AddOrUpdate(ilv => new {ilv.Display, ilv.Sequence}, dd));
			context.SaveChanges();
		}
	}
}
