using DPAT_JOJU.Commands;
using Model;

namespace DPAT_JOJU;

class Application
{

    public static void Main(string[] args)
    {
        string baseDir = AppContext.BaseDirectory;
        string? fileName = "";

        if (string.IsNullOrWhiteSpace(fileName))
            fileName = "invalid_deterministic1";
            
        string filePath = Path.Combine(baseDir, "Resources", fileName + ".fsm");

        Console.WriteLine("Reading: " + filePath);
        string fileContent = File.ReadAllText(filePath);
        
        ICommand<Diagram> loadCommand = new LoadCommand(fileContent);
        Diagram diagram = loadCommand.Execute();
        
        ICommand<Boolean> validateCommand = new ValidateCommand(diagram);
        Boolean valid = validateCommand.Execute();

        if (!valid)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Validation is not valid!");
            return;
        }
        
        ICommand<Boolean> viewCommand = new ViewCommand(diagram);
        Boolean view =  viewCommand.Execute();
    }
}