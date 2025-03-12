using UnityEngine;


[CreateAssetMenu]
public class MovementStats : ScriptableObject
{
    public float speed = 1f;
    public float acceleration = 2f;
    public float friction = 1.5f;
    public float maxSpeed = 5f;
}
