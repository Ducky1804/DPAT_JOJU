using Loading.Reader;
using Model;

namespace Loading;

public class LoadingFacade
{
    private IFileReader _reader = new FsmFileReader();
    
    public Diagram CreateDiagram(string name, string content)
    {
        List<string> lines = _reader.ReadFile(content);
        foreach (var line in lines)
        {
            Console.WriteLine(line);
        }

        return new Diagram();
    }
}