using Model;

namespace Loading.Builder;

public class StateBuilder : IBuilder<State>
{
    private string _id;
    private string _name;
    private State _parent;
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

    public State Parent
    {
        get => _parent;
        set => _parent = value;
    }

    public string Type
    {
        get => _type;
        set => _type = value;
    }

    public State Build()
    {
        
        State state = _type switch
        {
            "COMPOUND" => new CompoundState(_id, _name),
            "INITIAL" => new InitialState(_id, _name),
            "FINAL" => new FinalState(_id, _name),
            _ => new SimpleState(_id, _name)
        };

        if (_parent != null)
        {
            state.ParentState = _parent;
        }

        return state;
    }
}