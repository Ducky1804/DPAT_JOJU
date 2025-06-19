using Model;
using Model.State;
using Validator.Exceptions;
using Validator.Validation;

namespace ValidatorTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void OutgoingFinalStateHandler_ThrowsException()
    {
        var init = new InitialState("init", "InitialState");
        var final = new FinalState("final", "FinalState");
        var transition = new Transition("trans", null, "final", "init", null, "");

        final.Transitions.Add(transition);

        var diagram = new Diagram();
        diagram.States.Add(init);
        diagram.States.Add(final);

        var handler = new OutgoingFinalStateHandler();

        Assert.Throws<ValidationException>(() => handler.Handle(diagram));
    }

    [Test]
    public void UnreachableStateHandler_ThrowsException_WhenUnreachableStateExists()
    {
        var initial = new InitialState("init", "InitialState");
        var reachable = new SimpleState("middle", "MiddleState");
        var unreachable = new SimpleState("orphan", "UnreachableState");

        initial.Transitions.Add(new Transition("t1", null, "middle", "init", null, ""));

        var diagram = new Diagram();
        diagram.States.Add(initial);
        diagram.States.Add(reachable);
        diagram.States.Add(unreachable);

        var handler = new UnreachableStateHandler();

        Assert.Throws<ValidationException>(() => handler.Handle(diagram));
    }

    [Test]
    public void NonDeterministicTransitionHandler_ThrowsException_WhenDuplicateTriggersExist()
    {
        var state = new SimpleState("s1", "State1");

        Trigger clickTrigger = new Trigger("click", "Click");

        state.Transitions.Add(new Transition("t1", "click", "s2", "s1", clickTrigger, ""));
        state.Transitions.Add(new Transition("t2", "click", "s3", "s1", clickTrigger, "")); // zelfde trigger + guard

        var diagram = new Diagram();
        diagram.States.Add(state);
        diagram.States.Add(new SimpleState("s2", "State2"));
        diagram.States.Add(new SimpleState("s3", "State3"));

        var handler = new NonDeterministicTransitionHandler();

        Assert.Throws<ValidationException>(() => handler.Handle(diagram));
    }
}
