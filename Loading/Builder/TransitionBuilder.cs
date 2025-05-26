using Model;

namespace Loading.Builder;

public class TransitionBuilder : IBuilder<Transition>
{
    private string _id;
    private State _source;
    private State _destination;
    private Trigger _trigger;
    private String _guard;
    
    public Transition Build()
    {
        return new Transition(_id, _source, _destination, _trigger);
    }
}