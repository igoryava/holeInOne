using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDamagable : MonoBehaviour, IBallCollisionDamagable
{
    [field: SerializeField] public float Damage { get; set; }
}