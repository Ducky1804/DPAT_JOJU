namespace DPAT_JOJU.Commands;

public interface ICommand<T>
{
    T Execute();
}