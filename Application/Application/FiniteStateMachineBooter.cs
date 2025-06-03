namespace DPAT_JOJU;

using Commands;
using Model;
using View;
using View.Printer;

public class FiniteStateMachineBooter : IApplicationBooter
{
    private const string DefaultFile = "example_lamp";
    
    public void Boot()
    {
        IPrinter printer = new ConsolePrinter();
        IPrinter errorPrinter = new ErrorConsolePrinter();
        
        InitialRenderer menuRenderer = new InitialRenderer();
        printer.Print(menuRenderer.Render());
        
        IInputReader inputReader = new ConsoleInputReader();
        string file = inputReader.ReadInput();

        string fileContent;
        try
        {
            if (string.IsNullOrWhiteSpace(file))
                file = DefaultFile;

            ICommand<String> fileReaderCommand = new FileReadCommand(file);
            fileContent = fileReaderCommand.Execute();
        }
        catch (Exception e)
        {
            Console.Clear();
            errorPrinter.Print(new NoFileError(file).Render());
            Boot();
            return;
        }

        Diagram diagram = LoadDiagram(file, fileContent);
        
        ICommand<Boolean> validateCommand = new ValidateCommand(diagram);
        Boolean valid = true;
        try
        {
            valid = validateCommand.Execute();
        }
        catch (Exception e)
        {
            Console.Clear();
            errorPrinter.Print(e.Message);
            Boot();
            return;
        }

        if (!valid)
        {
            Console.Clear();
            errorPrinter.Print(new ValidationError().Render());
            return;
        }
        
        Render(diagram);
    }

    private Diagram LoadDiagram(string file, string fileContent)
    {
        ICommand<Diagram> loadCommand = new LoadCommand(file, fileContent);
        return loadCommand.Execute();
    }

    private void Render(Diagram diagram)
    {
        ICommand<Boolean> viewCommand = new ViewCommand(diagram);
        viewCommand.Execute();
    }
}