using EmptyDI.Pool;
using Code.BattleParticipants;

namespace Code.Core.Pools
{
    public sealed class BattleBasePool : DIPool<string, BattleBase>
    {
        public BattleBase Spawn(BattleBase prefab)
        {
            if (!IsContainsOf(prefab.name))
            {
                Bind(prefab.name, prefab);
            }

            var battleBase = Spawn(prefab.name);
            battleBase.name = prefab.name;

            return battleBase;
        }

        protected override void OnSpawn(BattleBase @object)
        {
            @object.gameObject.SetActive(true);
        }

        protected override void OnDespawn(BattleBase @object)
        {
            @object.gameObject.SetActive(false);
        }
    }

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
