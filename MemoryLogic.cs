using System;

public class MemoryLogic
{
	private List<String> words;
	private string? difficulty = null;
	public MemoryLogic(List<String> words, string difficulty)
	{
		this.words = words;
		chooseLevel();
	}

	public void message(string message)
    {
		Console.WriteLine(message);
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
			Console.WriteLine("The only legal entry is 'easy' or 'hard'! Type the desired difficulty and press enter.\n");
			chooseLevel();
		}
		//gameStart();
	}

	/*
	private Array[] wordsTimesTwo(string[] words)
    {
		Array[] array = new Array[words.Length*2];
		words.CopyTo(array, 0);
		words.CopyTo(array, words.Length);
        return	array;
    }
	*/
}
