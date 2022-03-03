using System.IO;

public class FileWriter
{

    private string filepath;
    public FileWriter(string filepath)
    {
        this.filepath = filepath;
    }

    public void write(string write)
    {
        string result = write;
        File.WriteAllText(this.filepath, result);
    }
}