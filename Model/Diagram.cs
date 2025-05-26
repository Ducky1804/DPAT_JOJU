namespace Model;

public class Diagram
{
    public List<State> States { get; set; } = new();

    public State GetState(string identifier)
    {
        foreach (var state in States)
        {
            if (state.Id == identifier) return state;
        }
        
        return null;
    }
}