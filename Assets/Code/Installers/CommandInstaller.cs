using EmptyDI;
using Code.Core.Command;

namespace Code.Installers
{
    public sealed class CommandInstaller : MonoInstaller
    {
        public override void Install()
        {
            this.Bind<StartBattleCommand>().AsSingle();
            this.Bind<CreateWarriorCommand>().AsSingle();
            this.Bind<CreateProjectileCommand>().AsSingle();
            this.Bind<DestroyWarriorCommand>().AsSingle();
        }
    }
}
