using UnityEngine;

namespace Adventurer.Player
{
    public class Adventurer : MonoBehaviour
    {
        private Vector2 _moveVector;
        private Vector2 _rotationVector;

        public Vector2 MoveVector
        {
            get
            {
                return _moveVector;
            }

            set
            {
                _moveVector = value;
            }
        }

        public Vector2 RotationVector
        {
            get
            {
                return _rotationVector;
            }

            set
            {
                _rotationVector = value;
            }
        }

        public bool MeleeState { get; set; }

        public bool Aiming { get; set; }
    }
}
