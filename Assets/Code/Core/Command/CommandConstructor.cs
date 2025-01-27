using EmptyDI;

namespace Code.Core.Command
{
    public ref struct CommandConstructor<T>
        where T : class, ICommand
    {
        public T CreateCommand() => EmptyDIConnector.Get<T>();
    }
}
