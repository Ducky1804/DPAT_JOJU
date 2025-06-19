using System.Text.RegularExpressions;
using Model;
using View.Printer;
using Action = Model.Action;

namespace View;

public class TextualRenderVisitor : RenderVisitor
{
    protected override string Render(SimpleState state)
    {
        return "Idk";
    }

    protected override string Render(InitialState state)
    {
        return "Init: " + state.Name;
    }

    protected override string Render(FinalState state)
    {
        return "Final: " + state.Name;
    }

    protected override string Render(CompoundState state)
    {
        List<string> content = new List<string>()
        {
            "Compound " + state.Name + ": "
        };

        foreach (var stateChild in state.Children)
        {
            if(stateChild is SimpleState simpleState)
                content.Add(Render(simpleState));
            
            if(stateChild is CompoundState compoundState)
                content.Add(Render(compoundState));
        }
        
        content.Add("\n\r");
        string joinedContent = string.Join("\n\r", content);
        return Regex.Replace(joinedContent, @"\s+", "");
    }

    protected override string Render(Trigger trigger)
    {
        return "Trigger: " + trigger.Id + ", " + trigger.Description;
    }

    protected override string Render(Action action)
    {
        return "Action: " + action.Type;
    }

    protected override string Render(Transition transition)
    {
        return "Idk";
    }
}