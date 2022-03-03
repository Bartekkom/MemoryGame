using System;

public class GameEngine : GameSetup
{
	private List<int> guessedWords = new List<int>();
	public GameEngine(List<string> words) : base(words)
	{
		gameLoop();
	}
	public void display(string[] pairsArray, string[] numberArray)
	{
		Console.Write("\n    ");
		displayArray(numberArray, 0, numberArray.Length);

		Console.WriteLine();
		Console.Write("  A ");
		displayArray(pairsArray, 0, pairs);

		Console.WriteLine();
		Console.Write("  B ");
		displayArray(pairsArray, pairs, pairs * 2);

	}

	//Adapting for example A1 to certain index in array
	public int userEntry()
	{
		Console.WriteLine("\n \n Enter Coordinates: ");
		string entry = Console.ReadLine();
		int index = 0;



		if (entry == null || entry.Length != 2)
		{

			Console.WriteLine("\n \n Enter proper value! I.E A1,B2,A3 etc.");
			userEntry();
		}

		if (entry[1] - 50 > pairs)
		{
			Console.WriteLine("\n \n Entry out of range! Try Again");
			userEntry();
		}
		else if (entry[0] == 'A')
		{
			//in ASCII code '1' has value of 50, so to get 0 index we subtract 50
			index = entry[1] - 49;
		}
		else if (entry[0] == 'B')
		{
			//adding pairs to get to second row
			index = entry[1] - 49 + pairs;
		}
		else
		{
			Console.WriteLine("\n \n Enter proper value! I.E A1,B2,A3 etc.");
			userEntry();
		}

		if (guessedWords.Contains(index))
		{
			Console.WriteLine("\n \n Word is already guessed! Choose another coordinate!");
			userEntry();
		}


		return index;
	}

	private void gameLoop()
	{
		int points = 0;
		int index1, index2;
		string[] xArray = new string[pairs * 2];
		for (int i = 0; i < pairs * 2; i++)
		{
			xArray[i] = "X ";
		}

		string[] nArray = new string[pairs];

		for (int i = 0; i < pairs; i++)
		{
			nArray[i] = i + 1 + " ";
		}

		Console.WriteLine("\n \n *______________________* \n \n" +
			"Level: " + difficulty +
			"\nGuess Chances: " + tries +
			"\nGood luck!!!");



		display(xArray, nArray);

		while (points < pairs && tries > 0)
		{
			index1 = userEntry();
			xArray[index1] = memoryArray[index1] + " ";
			display(xArray, nArray);

			index2 = userEntry();
			while (index1 == index2)
			{
				Console.WriteLine("Select different coordinate!");
				index2 = userEntry();
			}
			xArray[index2] = memoryArray[index2] + " ";
			display(xArray, nArray);

			tries--;

			Console.WriteLine("\n \n *______________________*");

			if (!xArray[index1].Equals(xArray[index2]))
			{
				xArray[index1] = "X ";
				xArray[index2] = "X ";
				Console.WriteLine("\n \n Keep Guessing! Tries left: " + tries + "\n");
			}
			else
			{
				guessedWords.Add(index1);
				guessedWords.Add(index2);

				Console.WriteLine("\n \n Good Job! Tries left: " + tries + "\n");
				points++;

			}

			//display(xArray, nArray);
		}
		gameOver(points);
	}

	private void gameOver(int points){
		if(points == pairs)
        {
			Console.WriteLine("Congratulations! You Won! Press enter if you want to restart the game.");
			Console.ReadKey();
			restart();

		}
        else
        {
			Console.WriteLine("You are out of chances! Press enter if you want to restart the game.");
			Console.ReadKey();
			restart();
		}
	}

	private void restart()
    {
		setup();
		gameLoop();
    }


	private void displayArray(string[] array, int start, int end)
    {
		for (int i = start; i < end; i++)
		{
			Console.Write(array[i]);
		}
	}
}