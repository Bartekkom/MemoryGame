using System;

public class GameSetup
{
	private List<String> words;
	protected string difficulty = "easy";
	protected string[] memoryArray;
	protected static int pairs = 0;
	protected static int tries = 0;
	private Random random;

	public GameSetup(List<String> words)
	{
		this.words = words;
		random = new Random();
		setup();
	}

	public string[] setup()
	{
		chooseLevel();
		difficultySetup();
		memoryArray = shuffle(randomWords());
		return memoryArray;
	}

	private void chooseLevel()
	{
		Console.WriteLine("*Choose difficulty level*\n" +
							"Type 'easy' for Easy\n" +
							"Type 'hard' for Hard\n" +
							"Then press enter key\n");

		difficulty = Console.ReadLine();
        if (!difficulty.Equals("easy") && !difficulty.Equals("hard"))
		{
			Console.WriteLine("\n The only legal entry is 'easy' or 'hard'! Type the desired difficulty and press enter.\n");
			chooseLevel();
		}

	}

	private void difficultySetup()
    {
		if(this.difficulty.Equals("easy"))
        {
			pairs = 4;
			tries = 10;
        }
        else
        {
			pairs = 8;
			tries = 15;
        }
	}

	private string[] randomWords()
    {
		//Creating HashSet to get different values
		HashSet<string> randomWords = new HashSet<string>();
		while (randomWords.Count < pairs)
		{
			randomWords.Add(words[random.Next(words.Count)]);
		}
		string[] result = new string[pairs*2];
		
		randomWords.CopyTo(result, 0);
		randomWords.CopyTo(result, pairs);

		//Here we have a string array of 4 duplicate words in certain order
		return result;
	}

	//Method used to shuffle our array of duplicate words. Final step of the game setup
	private string[] shuffle(string[] givenArray)
    {
		return givenArray.OrderBy(x => random.Next()).ToArray();
		
	}
}
