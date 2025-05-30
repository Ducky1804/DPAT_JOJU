using System.ComponentModel;
using System.Runtime.CompilerServices;
using DPAT_JOJU.Commands;
using Model;
using View;
using View.Printer;

namespace DPAT_JOJU;

class Application
{

    public static void Main(string[] args)
    {
        Init();
    }

    private static void Init()
    {
        IPrinter printer = new ConsolePrinter();
        IPrinter errorPrinter = new ErrorConsolePrinter();
        
        InitialRenderer menuRenderer = new InitialRenderer();
        printer.Print(menuRenderer.Render());
        
        IInputReader inputReader = new ConsoleInputReader();
        string file = inputReader.ReadInput();

        string fileContent = "";
        try
        {
            if (string.IsNullOrWhiteSpace(file))
            {
                file = "example_user_account";
            }

            ICommand<String> fileReaderCommand = new FileReadCommand(file);
            fileContent = fileReaderCommand.Execute();
        }
        catch (Exception e)
        {
            Console.Clear();
            errorPrinter.Print(new NoFileError(file).Render());
            Init();
            return;
        }
        
        ICommand<Diagram> loadCommand = new LoadCommand(file, fileContent);
        Diagram diagram = loadCommand.Execute();
        
        ICommand<Boolean> validateCommand = new ValidateCommand(diagram);
        Boolean valid = validateCommand.Execute();

        if (!valid)
        {
            // Console.Clear();
            errorPrinter.Print(new ValidationError().Render());
            return;
        }
        
        ICommand<Boolean> viewCommand = new ViewCommand(diagram);
        viewCommand.Execute();
    }
}