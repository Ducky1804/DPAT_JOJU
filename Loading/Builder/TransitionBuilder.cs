using Model;

namespace Loading.Builder;

public class TransitionBuilder : IBuilder<Transition>
{
    private string _id;
    private string _triggerName;
    private string _source;
    private string _destination;
    private Trigger _trigger;
    private string _guard;
    
    public TransitionBuilder SetId(string id)
    {
        _id = id;
        return this;
    }

    public TransitionBuilder SetSource(string source)
    {
        _source = source;
        return this;
    }

    public TransitionBuilder SetDestination(string destination)
    {
        _destination = destination;
        return this;
    }

    public TransitionBuilder SetTrigger(Trigger trigger)
    {
        _trigger = trigger;
        return this;
    }

    public TransitionBuilder SetTriggerName(string name)
    {
        _triggerName = name;
        return this;
    }

    public TransitionBuilder SetGuard(string guard)
    {
        _guard = guard;
        return this;
    }
    
    public Transition Build()
    {
        return new Transition(_id, _triggerName, _source, _destination, _trigger, _guard);
    }
}