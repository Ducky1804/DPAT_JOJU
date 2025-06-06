using Loading;
using Loading.Reader;
using Model;

namespace DPAT_JOJU.Commands;

public class LoadCommand(string name, string content) : ICommand<Diagram>
{
    public Diagram Execute()
    {
        // AbstractFactory factory = new AbstractFactory(new FsmFileReader());
        // return factory.CreateDiagram(name, content);

        LoadingFacade facade = new LoadingFacade();
        return facade.CreateDiagram(name, content);
    }
}