using System;
using System.IO;

public class FileReader
{
	private string filepath;
	private List<string> words;

	public FileReader(string filename)
	{
		this.filepath = filename;
		this.words = File.ReadAllLines(filepath).ToList();
		
	}

	public List<String> getWords()
    {
		return words;
    } 

}
