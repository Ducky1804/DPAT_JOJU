using View.Factory;

namespace DPAT_JOJU;

using Commands;
using Model;
using View;
using View.Printer;

public class FiniteStateMachineBooter : IApplicationBooter
{
    private const string DefaultFile = "example_user_account";

    private RenderMethodFactory _renderMethodFactory = new();
    private string _renderMethod = "";
    
    public void Boot()
    {
        _renderMethod = _renderMethodFactory.GetRenderMethods()[0];
        
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
        
        ListenForCommands(diagram);
    }

    private Diagram LoadDiagram(string file, string fileContent)
    {
        ICommand<Diagram> loadCommand = new LoadCommand(file, fileContent);
        return loadCommand.Execute();
    }

    private void Render(Diagram diagram)
    {
        IVisitor visitor = new RenderMethodFactory().Create(_renderMethod);
        ICommand<Boolean> viewCommand = new ViewCommand(diagram, visitor);
        viewCommand.Execute();
    }

    private void ListenForCommands(Diagram diagram)
    {
        char input = Console.ReadKey().KeyChar;
        Console.Clear();

        if (input == 'm')
        {
            _renderMethod = SwitchRenderMethod();
            Render(diagram);
        }

        if (input == 'q')
        {
            new BoxedContentPrinter(ConsoleColor.Green).Print("Bye bye!");
            return;
        }

        ListenForCommands(diagram);
    }
    
    private string SwitchRenderMethod()
    {
        List<string> methods = _renderMethodFactory.GetRenderMethods();
        string currentMethod = _renderMethod;

        int currentIndex = methods.IndexOf(currentMethod);

        int nextIndex = (currentIndex == -1 || currentIndex == methods.Count - 1) ? 0 : currentIndex + 1;

        return methods[nextIndex];
    }

}