using UnityEngine;

namespace Code.BattleParticipants
{
    public interface IMovable
    {
        float Speed { get; }

        void Move(Vector3 direction);
    }
}
