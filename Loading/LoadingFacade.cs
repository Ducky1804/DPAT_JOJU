using Loading.Reader;
using Model;

namespace Loading;

public class LoadingFacade
{
    private IFileReader _reader = new FsmFileReader();
    
    public Diagram CreateDiagram(string name, string content)
    {
        AbstractFactory factory = new AbstractFactory(_reader);
        return factory.CreateDiagram(name, content);
    }
}