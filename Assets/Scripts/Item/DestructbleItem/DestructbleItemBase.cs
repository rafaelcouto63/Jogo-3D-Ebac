using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;


public class DestructbleItemBase : MonoBehaviour
{
    public HealthBase healthBase;
    public float sheakDuration = .1f;
    public int sheakForce = 5;

    private void OnValidate() 
    {
        if(healthBase == null) healthBase = GetComponent<HealthBase>();
    }

    private void Awake() 
    {
        OnValidate();
        healthBase.OnDamage += OnDamage;
    }

    private void OnDamage(HealthBase h)
    {
       transform.DOShakeScale(sheakDuration, Vector3.up, sheakForce);
    }
}
