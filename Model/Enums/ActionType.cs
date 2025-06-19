namespace Model.Enums;

public enum ActionType
{
    EntryAction,
    ExitAction,
    DoAction,
    TransitionAction
}

public static class ActionTypeExtensions
{
    public static ActionType FromString(string action)
    {
        return action switch
        {
            "ENTRY_ACTION" => ActionType.EntryAction,
            "EXIT_ACTION" => ActionType.ExitAction,
            "DO_ACTION" => ActionType.DoAction,
            _ => ActionType.TransitionAction
        };
    }
}
