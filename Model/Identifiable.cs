namespace Model;

public abstract class Identifiable
{
    public string Id { get; set; }

    public Identifiable(string id)
    {
        Id = id;
    }
}