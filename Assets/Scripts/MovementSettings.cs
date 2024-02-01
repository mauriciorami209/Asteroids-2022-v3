using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(order = 1, fileName = "movement settings", menuName = "Asteroids/Movement Settings")]
public class MovementSettings : ScriptableObject
{
    public Vector3 direction;
    public float speed;
    public float maxSpeed;
    public bool isAccelerated;
    public float damping;
}
