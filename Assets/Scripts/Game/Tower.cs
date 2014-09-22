using UnityEngine;
using System;

public class Tower : MonoBehaviour
{
    private Transform _towerTransform;

    void Awake()
    {
        _towerTransform = transform;
    }
}
