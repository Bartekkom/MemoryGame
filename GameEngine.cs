using System;

public class GameEngine : GameSetup
{
	private static int secondsCount = 0;
	private List<int> guessedWords = new List<int>();
	private System.Timers.Timer t;
	private FileWriter reader;
	public GameEngine(List<string> words) : base(words)
	{
		reader = new FileWriter(@"C:\Users\Bartek\source\repos\MemoryGame\Highscores.txt");
		t = new System.Timers.Timer();
		setTimer();
		gameLoop();
	}

	private void setTimer()
    {
		t.Interval = 1000; //1s
        t.Elapsed += T_Elapsed;
		t.AutoReset = true;
		t.Enabled = true;

	}

    private void T_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
    {
       secondsCount++;
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

	private bool isValid(string entry)
    {
		if (entry == null || entry.Length != 2)
		{
			Console.WriteLine("\n \n Enter proper value! I.E A1,B2,A3 etc.");
			return false;
		}

		if (entry[1] - 49 >= pairs || entry[1] - 49 < 0)
		{
			Console.WriteLine("\n \n Entry out of range! Try Again");
			return false;
		}

		if (guessedWords.Contains(userEntry(entry)))
		{
			Console.WriteLine("\n \n Word is already guessed! Choose another coordinate!");
			return false;
		}

		else if (entry[0] == 'A')
		{
			return true;
		}
		else if (entry[0] == 'B')
		{
			return true;
		}
		else
		{
			Console.WriteLine("\n \n Enter proper value! I.E A1,B2,A3 etc.");
			return false;
		}
    }


	private int userEntry(string entry)
	{
		int index = 0;

		if (entry[0] == 'A')
		{
			//substracting 49 to get from ASCII to int
			index = entry[1] - 49;
		}
		else if (entry[0] == 'B')
		{
			//adding pairs to get to second row
			index = entry[1] - 49 + pairs;
		}
		return index;
	}

	private void gameLoop()
	{
		t.Start();
		int points = 0;
		int triesLeft = tries;
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
			Console.WriteLine("\n \n Enter Coordinates: ");
            string entry = Console.ReadLine();
			while (!isValid(entry))
            {
				Console.WriteLine("\n \n Enter Coordinates: ");
				entry = Console.ReadLine();
			}

			index1 = userEntry(entry);
			xArray[index1] = memoryArray[index1] + " ";
			display(xArray, nArray);

			Console.WriteLine("\n \n Enter Coordinates: ");
			entry = Console.ReadLine();
			while (!isValid(entry) || index1 == userEntry(entry))
			{
				if(index1 == userEntry(entry))
                {
					Console.WriteLine("Select different coordinate!");
				}
				Console.WriteLine("\n \n Enter Coordinates: ");
				entry = Console.ReadLine();
			}

			index2 = userEntry(entry);
			xArray[index2] = memoryArray[index2] + " ";
			display(xArray, nArray);

			triesLeft--;
			Console.WriteLine("\n \n *______________________*");

			if (!xArray[index1].Equals(xArray[index2]))
			{
				xArray[index1] = "X ";
				xArray[index2] = "X ";
				Console.WriteLine("\n \n Keep Guessing! Tries left: " + triesLeft + "\n");
			}
			else
			{
				guessedWords.Add(index1);
				guessedWords.Add(index2);

				Console.WriteLine("\n \n Good Job! Tries left: " + triesLeft + "\n");
				points++;
			}
		}
		guessedWords.Clear();
		gameOver(points, triesLeft);
	}

	private void gameOver(int points, int triesLeft){
		t.Stop();
		int triesTaken = tries - triesLeft;
		string name;
		if(points == pairs)
        {
			Console.WriteLine("Congratulations! You Won! It took you " + secondsCount + "s and you used " + triesTaken + "tries.");
			Console.WriteLine("Enter you name to save the score: ");

			name = Console.ReadLine();
			while(name.Length < 1)
            {
				Console.WriteLine("Name should contain at leat 1 character! Try again.");
				name = Console.ReadLine();
			}

			while (name.Length > 10)
			{
				Console.WriteLine("Name is too long! It must be at most 10 characters long.");
				name = Console.ReadLine();
			}

			reader.write("Name: " + name + " | Time:" + secondsCount + "s | Tries: " + triesTaken + " | Difficulty: " + difficulty);

			Console.WriteLine("\nHighscore saved succesfully.");
			Console.WriteLine("\nPress any key if you want to restart the game.");
			Console.ReadKey();
			restart();

		}
        else
        {
			//Console.WriteLine("You are out of chances! Press any key if you want to restart the game.");
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