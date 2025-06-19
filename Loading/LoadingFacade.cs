using Loading.Reader;
using Model;

namespace Loading;

public class LoadingFacade(IFileReader reader = null)
{
    private readonly IFileReader _reader = reader ?? new FsmFileReader();

    public Diagram CreateDiagram(string name, string file)
    {
        FactoryDispatcher factoryDispatcher = new FactoryDispatcher();
        List<string> content = _reader.ReadFile(file);
        return factoryDispatcher.CreateDiagram(name, content);
    }
}