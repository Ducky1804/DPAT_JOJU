using Model;

namespace Loading.Builder;

public class DiagramBuilder : IBuilder<Diagram>
{
    public Diagram Build()
    {
        return new Diagram();
    }
}