using UnityEngine;

public struct PlayerMoveEvent
{
    public Vector3 Direction { get; private set; }

    public PlayerMoveEvent(Vector3 direction) : this()
    {
        Direction = direction;
    }
}