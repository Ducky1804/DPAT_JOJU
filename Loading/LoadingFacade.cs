using Loading.Reader;
using Model;

namespace Loading;

public class LoadingFacade
{
    private IFileReader _reader = new FsmFileReader();
    
    public Diagram CreateDiagram(string name, string file)
    {
        FactoryDispatcher factoryDispatcher = new FactoryDispatcher(_reader);
        List<string> content = _reader.ReadFile(file);
        return factoryDispatcher.CreateDiagram(name, content);
    }
}