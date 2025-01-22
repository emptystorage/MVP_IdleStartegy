using EmptyDI;
using Code.Core.Command;

namespace Code.Installers
{
    public sealed class CommandInstaller : MonoInstaller
    {
        public override void Install()
        {
            this.Bind<CreateWarriorCommand>().AsSingle();
        }
    }
}
