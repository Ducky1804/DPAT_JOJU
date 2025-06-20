using Loading;
using Loading.Reader;
using Model;

namespace DPAT_JOJU.Commands;

public class LoadCommand(string name, string content) : ICommand<Diagram>
{
    public Diagram Execute()
    {
        LoadingFacade facade = new LoadingFacade();
        return facade.CreateDiagram(name, content);
    }
}