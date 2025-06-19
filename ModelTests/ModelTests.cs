using Loading.Builder;
using Model;
using Model.Enums;
using Model.State;
using Model.Utils;
using Action = Model.Action;

namespace ModelTests;

public class Tests
{
    [Test]
    public void Diagrem_GetMaybeState()
    {
        DiagramBuilder builder = new DiagramBuilder("Test");
        builder.AddState(new SimpleState("ID", "NAME"));
        Diagram diagram = builder.Build();

        Maybe<State> maybeState = diagram.GetState("ID");
        
        Assert.True(maybeState.HasValue);
        Assert.That(maybeState.ValueOrDefault().Name,  Is.EqualTo("NAME"));
    }
}