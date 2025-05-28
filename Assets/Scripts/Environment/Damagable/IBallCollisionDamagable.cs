using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBallCollisionDamagable
{
    [field: SerializeField] public float Damage { get; set; }
}