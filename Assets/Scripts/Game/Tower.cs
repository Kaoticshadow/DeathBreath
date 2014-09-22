using UnityEngine;
using System;
using System.Collections;

public class Tower : MonoBehaviour
{
    private Transform _towerTransform;

    public Vector2 TowerPosition
    {
        get { return _towerTransform.localPosition; }
        set { _towerTransform.localPosition = value; }
    }

    void Awake()
    {
        _towerTransform = transform;
        _towerTransform.localScale = new Vector2(3.0f, 3.0f);
    }

    void Update()
    {
        if (TowerPosition.y > -0.9)
        {
            TowerPosition = new Vector2(TowerPosition.x - 0.12f, TowerPosition.y);
        }

        else if (TowerPosition.y > -2.0f && TowerPosition.y <= -0.9f)
        {
            TowerPosition = new Vector2(TowerPosition.x - 0.13f, TowerPosition.y);
        }

        else if (TowerPosition.y > -3.4f && TowerPosition.y <= -2.0f)
        {
            TowerPosition = new Vector2(TowerPosition.x - 0.14f, TowerPosition.y);
        }
        else if (TowerPosition.y > -5.4f && TowerPosition.y <= -3.4f)
        {
            TowerPosition = new Vector2(TowerPosition.x - 0.15f, TowerPosition.y);
        }
        else
        {
            TowerPosition = new Vector2(TowerPosition.x - 0.16f, TowerPosition.y);
        }
    }
        
}
