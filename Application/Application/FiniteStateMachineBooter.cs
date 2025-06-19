using DPAT_JOJU.Commands;
using Model;
using View;
using View.Factory;
using View.Printer;

namespace DPAT_JOJU;

public class FiniteStateMachineBooter : IApplicationBooter
{
    private readonly IPrinter _printer = new ConsolePrinter();
    private readonly IPrinter _errorPrinter = new ErrorConsolePrinter();
    private readonly IInputReader _inputReader = new ConsoleInputReader();
    private readonly RenderMethodFactory _renderMethodFactory = new();

    private string _renderMethod = "";

    public void Boot()
    {
        _renderMethod = _renderMethodFactory.GetRenderMethods().FirstOrDefault() ?? "";

        while (true)
        {
            string file = AskUserForFile();
            string? fileContent = TryReadFile(file);
            if (fileContent == null) continue;

            Diagram diagram = LoadDiagram(file, fileContent);
            if (!TryValidateDiagram(diagram)) continue;

            Render(diagram);
            ListenForCommands(diagram);
            break;
        }
    }

    private string AskUserForFile()
    {
        _printer.Print(new InitialRenderer().Render());
        string input = _inputReader.ReadInput();
        return string.IsNullOrWhiteSpace(input) ? "example_user_account" : input;
    }

    private string? TryReadFile(string file)
    {
        try
        {
            return new FileReadCommand(file).Execute();
        }
        catch
        {
            Console.Clear();
            _errorPrinter.Print(new NoFileError(file).Render());
            return null;
        }
    }

    private Diagram LoadDiagram(string file, string content)
        => new LoadCommand(file, content).Execute();

    private bool TryValidateDiagram(Diagram diagram)
    {
        try
        {
            return new ValidateCommand(diagram).Execute();
        }
        catch (Exception e)
        {
            Console.Clear();
            _errorPrinter.Print(e.Message);
            return false;
        }
    }

    private void Render(Diagram diagram)
    {
        var visitor = _renderMethodFactory.Create(_renderMethod);
        new ViewCommand(diagram, visitor).Execute();
    }

    private void ListenForCommands(Diagram diagram)
    {
        while (true)
        {
            var input = Console.ReadKey().KeyChar;
            Console.Clear();

            switch (input)
            {
                case 'm':
                    _renderMethod = SwitchRenderMethod();
                    Render(diagram);
                    break;
                case 'q':
                    new BoxedContentPrinter(ConsoleColor.Green).Print("Bye bye!");
                    return;
            }
        }
    }

    private string SwitchRenderMethod()
    {
        var methods = _renderMethodFactory.GetRenderMethods();
        int index = methods.IndexOf(_renderMethod);
        return methods[(index + 1) % methods.Count];
    }
}