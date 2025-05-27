namespace View;

public class NoFileError : MenuRenderer
{
    public NoFileError(string input) : base($"The file {input} has not been found!")
    {
    }
}