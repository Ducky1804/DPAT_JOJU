using Model;

namespace Loading.Factory;

public interface IFactory { }
public interface IFactory<T> : IFactory
{
    T Create(string input);
}