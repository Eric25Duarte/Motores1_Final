using UnityEngine;

public struct Coordinates
{
    private Vector3 position;

    public Coordinates(Vector3 initialPosition)
    {
        position = initialPosition;
    }

    public Vector3 Position
    {
        get => position;
        set => position = value;
    }
}
