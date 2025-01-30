using Code.BattleParticipants;

namespace Code.Core.Pools
{
    public sealed class WarriorParticipantPool : MonoObjectPool<WarriorParticipant>
    {
        public WarriorParticipant Spawn(WarriorParticipant prefab)
        {
            var unit = base.Spawn(prefab);
            unit.Setup();

            return unit;
        }

        protected override void OnSpawn(WarriorParticipant @object)
        {
            @object.Rigidbody.velocity = default;
            @object.Rigidbody.angularVelocity = default;
            base.OnSpawn(@object);
        }
    }
}
