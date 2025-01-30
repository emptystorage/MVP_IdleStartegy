using UnityEngine;
using EmptyDI.Pool;
using Code.GUI;

namespace Code.Core.Pools
{
    public sealed class UnitBattleInfoElementPool : DIPool<UnitBattleInfoUIElement>
    {
        public UnitBattleInfoUIElement Spawn(Transform root)
        {
            var element = base.Spawn();
            element.transform.SetParent(root);

            return element;
        }

        protected override void OnSpawn(UnitBattleInfoUIElement @object)
        {
            @object.gameObject.SetActive(true);
        }

        protected override void OnDespawn(UnitBattleInfoUIElement @object)
        {
            @object.gameObject.SetActive(false);
        }
    }
}
