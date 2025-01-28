using EmptyDI.Pool;
using UnityEngine;

namespace Code.Core.Pools
{
    public abstract class MonoObjectPool<T> : DIPool<string, T>
        where T : MonoBehaviour
    {
        public T Spawn(T prefab)
        {
            if (!IsContainsOf(prefab.name))
            {
                Bind(prefab.name, prefab);
            }

            var @object = Spawn(prefab.name);
            @object.name = prefab.name;

            return @object;
        }

        public void Despawn(in T @object)
        {
            base.Despawn(@object.name, @object);
        }

        protected override void OnSpawn(T @object)
        {
            @object.gameObject.SetActive(true);
        }

        protected override void OnDespawn(T @object)
        {
            @object.gameObject.SetActive(false);
        }
    }
}
