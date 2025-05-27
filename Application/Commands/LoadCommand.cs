using Loading;
using Model;

namespace DPAT_JOJU.Commands;

public class LoadCommand(string name, string content) : ICommand<Diagram>
{
    public Diagram Execute()
    {
        AbstractFactory factory = new AbstractFactory();
        return factory.CreateDiagram(name, content);
    }
}