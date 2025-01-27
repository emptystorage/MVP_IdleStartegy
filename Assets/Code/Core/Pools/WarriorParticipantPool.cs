using EmptyDI.Pool;
using Code.BattleParticipants;

namespace Code.Core.Pools
{
    public sealed class WarriorParticipantPool : DIPool<string, WarriorParticipant>
    {
        public WarriorParticipant Spawn(WarriorParticipant prefab)
        {
            if (!IsContainsOf(prefab.name))
            {
                Bind(prefab.name, prefab);
            }

            var unit = Spawn(prefab.name);
            unit.name = prefab.name;
            unit.Setup();

            return unit;
        }

        protected override void OnSpawn(WarriorParticipant @object)
        {
            @object.Rigidbody.velocity = default;
            @object.Rigidbody.angularVelocity = default;
            @object.gameObject.SetActive(true);
        }

        protected override void OnDespawn(WarriorParticipant @object)
        {
            @object.gameObject.SetActive(false);
        }
    }
}
