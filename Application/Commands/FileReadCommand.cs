namespace DPAT_JOJU.Commands;

public class FileReadCommand(string file) : ICommand<String>
{
    public string Execute()
    {
        string baseDir = AppContext.BaseDirectory;

        if (string.IsNullOrWhiteSpace(file))
            file = "invalid_deterministic3";
            
        string filePath = Path.Combine(baseDir, "Resources", file + ".fsm");

        return File.ReadAllText(filePath);
    }
}