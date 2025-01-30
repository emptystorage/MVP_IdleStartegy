using EmptyDI;

namespace Code.Core.Command
{
    public ref struct CommandFactory<T>
        where T : class, ICommand
    {
        public T Create() => EmptyDIConnector.Get<T>();
    }
}
