namespace DPAT_JOJU.Commands;

public class FileReadCommand(string file) : ICommand<string>
{
    public string Execute()
    {
        string baseDir = AppContext.BaseDirectory;
        string filePath = Path.Combine(baseDir, "Resources", file + ".fsm");
        return File.ReadAllText(filePath);
    }
}