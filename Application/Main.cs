using DPAT_JOJU.Commands;
using Model;
using View;
using View.Printer;

namespace DPAT_JOJU;

class Application
{

    public static void Main(string[] args)
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

            ICommand<String> fileReaderCommand = new FileReadCommand(file);
            fileContent = fileReaderCommand.Execute();
            Console.WriteLine(fileContent);
        }
        catch (Exception e)
        {
            Console.Clear();
            errorPrinter.Print(new NoFileError(file).Render());
        }
        
        ICommand<Diagram> loadCommand = new LoadCommand(fileContent);
        Diagram diagram = loadCommand.Execute();
        
        ICommand<Boolean> validateCommand = new ValidateCommand(diagram);
        Boolean valid = validateCommand.Execute();

        if (!valid)
        {
            Console.Clear();
            errorPrinter.Print(new ValidationError().Render());
            return;
        }
        
        ICommand<Boolean> viewCommand = new ViewCommand(diagram);
        Boolean view =  viewCommand.Execute();
    }
}