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
}
