using UnityEngine;

namespace Adventurer.Player {
    public class AdventurerState : Adventurer, IPlayer
    {
        public AdventurerData playerData;

        public Vector2 ReturnMovePosition()
        {
            return MoveVector;
        }
    }
}
