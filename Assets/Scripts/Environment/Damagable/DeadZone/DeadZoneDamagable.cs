using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneDamagable : MonoBehaviour, IBallCollisionDamagable
{
    [field: SerializeField] public float Damage { get; set; } = 1;
}