namespace Model.Utils;

public class Maybe<T>
{
    private readonly T _value;
    public bool HasValue { get; }
    
    private Maybe()
    {
        HasValue = false;
        _value = default!;
    }

    private Maybe(T value)
    {
        HasValue = true;
        _value = value;
    }

    public static Maybe<T> None() => new Maybe<T>();

    public static Maybe<T> Of(T value) => new Maybe<T>(value);
    
    public T ValueOrDefault() => HasValue ? _value : default!;
}