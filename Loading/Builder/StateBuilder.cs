using Model;
using Model.State;

namespace Loading.Builder;

public class StateBuilder : IBuilder<State>
{
    private string _id;
    private string _name;
    private string _type;

    public string Id
    {
        get => _id;
        set => _id = value;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public string Type
    {
        get => _type;
        set => _type = value;
    }

    public string Parent { get; set; }

    public State Build()
    {
        
        State state = _type switch
        {
            "COMPOUND" => new CompoundState(_id, _name),
            "INITIAL" => new InitialState(_id, _name),
            "FINAL" => new FinalState(_id, _name),
            _ => new SimpleState(_id, _name)
        };

        state.Parent = Parent;
        return state;
    }
}