using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class HealthBase : MonoBehaviour, IDamageable
{
    public float startLife = 10f;
    public bool destroyOnKill = false;
    public float timeToDestroy = 3f;
    [SerializeField]private float _currentLife;

    public Action<HealthBase> OnDamage;
    public Action<HealthBase> OnKill;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        ResetLife();
    }

    protected void ResetLife()
    {
        _currentLife = startLife;
    }

    protected virtual void Kill()
    {
        if(destroyOnKill == true) 
        {
         Destroy(gameObject, timeToDestroy);    
        }

        OnKill?.Invoke(this);
    }
    
    #region DEBUG
    [NaughtyAttributes.Button] 
    public void Damage () 
    {
        Damage(5);
    }
    #endregion

    public void Damage(float f)
    {
        _currentLife -= f;

        if(_currentLife <= 0) 
        {
            Kill();
        }

        OnDamage?.Invoke(this);
    }

    public void Damage(float damage, Vector3 dir)
    {
        Damage(damage);
    }
}
