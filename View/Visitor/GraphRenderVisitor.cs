// using Model;
// using View.Diagram;
// using View.Diagram.Action;
// using View.Factory;
// using View.Printer;
//
// namespace View;
//
// public class GraphRenderVisitor : RenderVisitor
// {
//     private readonly RenderFactory _renderFactory = RenderFactory.Instance;
//
//     public string Visit(SimpleState state)
//     {
//         IRenderer<SimpleState> renderer = _renderFactory.CreateStateRenderer<SimpleState>(state.GetType());
//         String renderedComponent = renderer.Render(state);
//         new ConsolePrinter().Print(renderedComponent);
//     }
//
//     public string Visit(InitialState state)
//     {
//         IRenderer<InitialState> renderer = _renderFactory.CreateStateRenderer<InitialState>(state.GetType());
//         String renderedComponent = renderer.Render(state);
//         new ConsolePrinter().Print(renderedComponent);
//     }
//
//     public string Visit(FinalState state)
//     {
//         IRenderer<FinalState> renderer = _renderFactory.CreateStateRenderer<FinalState>(state.GetType());
//         string renderedComponent = renderer.Render(state);
//         new ConsolePrinter().Print(renderedComponent);
//     }
//
//     public string Visit(CompoundState state)
//     {
//         IRenderer<CompoundState> renderer = _renderFactory.CreateStateRenderer<CompoundState>(state.GetType());
//         string renderedComponent = renderer.Render(state);
//         new ConsolePrinter().Print(renderedComponent);
//     }
//
//     public string Visit(Trigger trigger)
//     {
//     }
//
//     public string Visit(Model.Action action)
//     {
//         string content = new ActionRenderer().Render(action);
//         new ConsolePrinter().Print(content);
//     }
//
//     public string Visit(Transition transition)
//     {
//         string content = new TransitionRenderer().Render(transition);
//         new ConsolePrinter().Print(content);
//     }
// }

using Model;
using View;
using View.Diagram;
using View.Factory;
using Action = Model.Action;

public class GraphRenderVisitor : RenderVisitor
{
    private readonly RenderFactory _renderFactory = RenderFactory.Instance;

    protected override string Render(SimpleState state)
    {
        return _renderFactory.CreateStateRenderer<SimpleState>(state.GetType()).Render(state);
    }

    protected override string Render(InitialState state)
    {
        return _renderFactory.CreateStateRenderer<InitialState>(state.GetType()).Render(state);
    }

    protected override string Render(FinalState state)
    {
        return _renderFactory.CreateStateRenderer<FinalState>(state.GetType()).Render(state);
    }

    protected override string Render(CompoundState state)
    {
        return _renderFactory.CreateStateRenderer<CompoundState>(state.GetType()).Render(state);
    }

    protected override string Render(Trigger trigger)
    {
        return trigger.ToString();
    }

    protected override string Render(Action action)
    {
        throw new NotImplementedException();
    }

    protected override string Render(Transition transition)
    {
        return new TransitionRenderer().Render(transition);
    }
}
