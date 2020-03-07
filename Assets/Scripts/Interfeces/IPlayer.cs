using UnityEngine;

public interface IPlayer
{
    Vector2 ReturnMovePosition();

    Vector2 ReturnRotationPosition();

    void SetMovePosition(Vector2 position);

    void SetRotationPosition(Vector2 position);
}
