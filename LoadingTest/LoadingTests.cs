using Loading;
using Loading.Builder;
using Loading.Factory;
using Loading.Reader;
using Model;
using Model.Enums;
using Moq;
using Action = Model.Action;

namespace LoadingTest;

public class Tests
{
    [Test]
    public void StateFactory_CreatesInitialState()
    {
        var factory = new StateFactory();
        
        var state = factory.Create("STATE init _ \"Initial\" : INITIAL;");
        
        Assert.IsInstanceOf<InitialState>(state);
        Assert.That(state.Id, Is.EqualTo("init"));
        Assert.That(state.Name, Is.EqualTo("Initial"));
    }
    
    [Test]
    public void Build_WithStateTransitionTriggerAndAction_BuildsCorrectDiagram()
    {
        // Arrange
        var builder = new DiagramBuilder("TestDiagram");

        var init = new InitialState("initial", "Initial state");
        var state = new SimpleState("S1", "First state!");
        var trigger = new Trigger("T1", "Trigger");
        var transition = new Transition("Transition1", "T1", "initial", "S1", null, "");

        var entryAction = new Action("A1", "Enter", ActionType.EntryAction);
        var transitionAction = new Action("Transition1", "Transition", ActionType.TransitionAction);


        builder.AddState(init);
        builder.AddState(state);
        builder.AddTrigger(trigger);
        builder.AddTransition(transition);
        builder.AddAction(entryAction);
        builder.AddAction(transitionAction);

        // Act
        var diagram = builder.Build();

        // Assert
        var maybeInitState = diagram.GetState("initial");
        Assert.True(maybeInitState.HasValue);
        
        var builtTransition = diagram.GetTransition("Transition1").ValueOrDefault();

        var initState = maybeInitState.ValueOrDefault();
        Assert.That(diagram.Name, Is.EqualTo("TestDiagram"));
        Assert.That(initState.Transitions, Has.Count.EqualTo(1));
        Assert.That(initState.Transitions[0], Is.EqualTo(transition));
        Assert.That(builtTransition.Trigger, Is.EqualTo(trigger));
    }

    [Test]
    public void LoadingFacade_CreateDiagram()
    {
        Mock<IFileReader> mockFileReader = new Mock<IFileReader>();
        mockFileReader.Setup(reader => reader.ReadFile("file.fsm")).Returns(file.Split("\n").ToList());
        
        var loadingFacade = new LoadingFacade(mockFileReader.Object);
        Diagram diagram = loadingFacade.CreateDiagram("Test diagram", "file.fsm");
        
        Assert.IsNotNull(diagram);
        Assert.That(diagram.States.Count, Is.EqualTo(3));
        Assert.That(diagram.States[0].Id, Is.EqualTo("initial"));
        Assert.That(diagram.States[2].Id, Is.EqualTo("final"));
    }

    private string file =
        "# User account\n# This file contains an example FSM for a user account featuring nested compound states\n\n#\n# Description of all the states\n#\n\nSTATE initial _ \"\" : INITIAL;\nSTATE created _ \"Created\" : COMPOUND;\nSTATE inactive created \"Inactive\" : COMPOUND;\nSTATE active created \"Active\" : COMPOUND;\nSTATE unverified inactive \"Unverified\" : SIMPLE;\nSTATE blocked inactive \"Blocked\" : SIMPLE;\nSTATE deleted inactive \"Deleted\" : SIMPLE;\nSTATE verified active \"Verified\" : SIMPLE;\nSTATE logged_in active \"Logged in\" : SIMPLE;\nSTATE final _ \"Archived\" : FINAL;\n\n#\n# Description of all the triggers\n#\n\nTRIGGER create \"create\";\nTRIGGER timer_elapsed \"timer elapsed\";\nTRIGGER email_verification \"email verification\";\nTRIGGER blocked_by_admin \"blocked by admin\";\nTRIGGER unblocked_by_admin \"unblocked by admin\";\nTRIGGER deleted_by_admin \"deleted by admin\";\nTRIGGER forget_me \"forget me\";\nTRIGGER login \"login\";\nTRIGGER logout \"logout\";\nTRIGGER archive \"archive\";\n\n#\n# Description of all the actions\n#\n\nACTION unverified \"send confirmation mail\" : ENTRY_ACTION;\nACTION unverified \"start timer\" : ENTRY_ACTION;\nACTION unverified \"stop timer\" : EXIT_ACTION;\nACTION blocked \"notify user\" : ENTRY_ACTION;\nACTION active \"logout\" : EXIT_ACTION;\nACTION verified \"notify user\" : ENTRY_ACTION;\nACTION deleted \"anonymize\" : ENTRY_ACTION;\nACTION logged_in \"reset attempts\" : ENTRY_ACTION;\nACTION logged_in \"log activity\" : DO_ACTION;\n\nACTION t2 \"attempts = 0\" : TRANSITION_ACTION;\nACTION t3 \"attempts++\" : TRANSITION_ACTION;\n\n#\n# Description of all the transitions\n#\n\nTRANSITION t1 initial -> unverified create \"\";\nTRANSITION t2 unverified -> verified email_verification \"\";\nTRANSITION t3 verified -> verified login \"invalid credentials\";\nTRANSITION t4 verified -> logged_in login \"valid credentials\";\nTRANSITION t5 logged_in -> verified logout \"\";\nTRANSITION t6 logged_in -> deleted forget_me \"valid credentials\";\nTRANSITION t7 verified -> blocked \"attempts >= 3\";\nTRANSITION t8 active -> blocked blocked_by_admin \"\";\nTRANSITION t9 blocked -> verified unblocked_by_admin \"\";\nTRANSITION t10 blocked -> deleted deleted_by_admin \"\";\nTRANSITION t11 deleted -> final archive \"\";\nTRANSITION t12 unverified -> deleted timer_elapsed \"\";\n\n";
}