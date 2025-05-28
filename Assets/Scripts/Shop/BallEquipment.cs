using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEquipment : MonoBehaviour
{
    [SerializeField] private Equipable _defaultEquipable;
    private Equipable _currentEquipable;

    private void Start()
    {
        _currentEquipable = _defaultEquipable;
    }

    public void Equip(Equipable equipable)
    {
        if (equipable == _currentEquipable)
        {
            return;
        }
        _currentEquipable?.GetUnEquiped();
        _currentEquipable = equipable;
        _currentEquipable.GetEquiped();
    }
}
