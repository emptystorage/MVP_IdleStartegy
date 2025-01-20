using EmptyDI.Pool;
using Code.GUI;
using Code.GameData;

namespace Code.Core.Pools
{
    public sealed class UnitButtonPool : DIPool<UnitButton>
    {
        public UnitButton Spawn(UnitButtonsRootElement root, UnitData data)
        {
            var button = base.Spawn();
            button.transform.SetParent(root.transform);
            button.transform.position = root.CreatePivotPoint.position;
            button.Setup(data, root.RemovePivotPoint, root.SlideSpeed);

            return button;
        }

        protected override void OnSpawn(UnitButton @object)
        {
            @object.gameObject.SetActive(true);
        }

        protected override void OnDespawn(UnitButton @object)
        {
            @object.gameObject.SetActive(false);
        }
    }
}
