﻿using Model;

namespace Loading.Builder;

public class TriggerBuilder : IBuilder<Trigger>
{
    private string _id;
    private string _description;

    public TriggerBuilder SetId(string id)
    {
        _id = id;
        return this;
    }

    public TriggerBuilder SetDescription(string description)
    {
        _description = description;
        return this;
    }
    
    public Trigger Build()
    {
        return new Trigger(_id, _description);
    }
}