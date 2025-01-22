using EmptyDI.Pool;
using Code.GUI;
using Code.GameData;
using UnityEngine;

namespace Code.Core.Pools
{
    public sealed class PlayerWarriorButtonPool : DIPool<PlayerWarriorButton>
    {
        public PlayerWarriorButton Spawn(UnitButtonsRootElement root, PlayerWarriorButtonData data)
        {
            var button = base.Spawn();
            button.transform.SetParent(root.transform);
            button.transform.position = root.CreatePivotPoint.position;
            button.Setup(data, root.RemovePivotPoint, root.SlideSpeed);

            return button;
        }

        protected override void OnSpawn(PlayerWarriorButton @object)
        {
            @object.gameObject.SetActive(true);
        }

        protected override void OnDespawn(PlayerWarriorButton @object)
        {
            @object.gameObject.SetActive(false);
        }
    }
}
