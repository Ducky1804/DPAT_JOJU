﻿using Model.Enums;

namespace Loading.Builder;

using Model;

public class ActionBuilder : IBuilder<Action>
{
    private string _id;
    private ActionType _type;
    private string _description;

    public ActionBuilder SetId(string id)
    {
        _id = id;
        return this;
    }
    
    public ActionBuilder SetType(string type)
    {
        _type = ActionTypeExtensions.FromString(type);
        return this;
    }

    public ActionBuilder SetDescription(string description)
    {
        _description = description;
        return this;
    }

    public Action Build()
    {
        return new Action(_id, _description, _type);
    }
}