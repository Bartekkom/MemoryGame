using System;

namespace MyApp 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileReader read = new FileReader(@"C:\Users\Bartek\source\repos\MemoryGame\Words.txt");
            List<string> words = read.getWords();
            GameEngine game = new GameEngine(words);
        }
    }
}