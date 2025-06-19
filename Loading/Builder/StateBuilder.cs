using Model;
using Model.State;

namespace Loading.Builder;

public class StateBuilder : IBuilder<State>
{
    private string _id;
    private string _name;
    private string _parent;
    private string _type;

    public StateBuilder SetId(string id)
    {
        _id = id;
        return this;
    }
    
    public StateBuilder SetName(string name)
    {
        _name = name;
        return this;
    }
    
    public StateBuilder SetType(string type)
    {
        _type = type;
        return this;
    }

    public StateBuilder SetParent(string parent)
    {
        _parent = parent;
        return this;
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

        state.Parent = _parent;
        return state;
    }
}