namespace DPAT_JOJU;

public class ConsoleInputReader : IInputReader
{
    public string ReadInput()
    {
        return Console.ReadLine() ?? "";
    }
}