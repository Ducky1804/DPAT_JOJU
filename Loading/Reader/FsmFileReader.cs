namespace Loading.Reader;

public class FsmFileReader : IFileReader
{
    public List<string> ReadFile(string fileContent)
    {
        return fileContent
            .Split("\r\n", StringSplitOptions.RemoveEmptyEntries)
            .Where(line => !line.StartsWith("#"))
            .ToList();
    }
}