using System;
using Code.BattleParticipants;
using Code.Core.Pools;

namespace Code.Core.Command
{
    public sealed class DestroyWarriorCommand : ICommand
    {
        private readonly WarriorParticipantPool Pool;

        public DestroyWarriorCommand(WarriorParticipantPool pool)
        {
            Pool = pool;
        }

        public void Execute(in WarriorParticipant warrior)
        {
            //TODO create coin and VFX
            Pool.Despawn(warrior);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
