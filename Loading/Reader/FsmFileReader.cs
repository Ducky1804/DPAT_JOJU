namespace Loading.Reader;

public class FsmFileReader : IFileReader
{
    public List<string> ReadFile(string fileContent)
    {
        return fileContent
            .Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries)
            .Where(line => !line.StartsWith("#"))
            .ToList();
    }
}