using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;


public class DestructbleItemBase : MonoBehaviour
{
    public HealthBase healthBase;
    public float sheakDuration = .1f;
    public int sheakForce = 5;

    public int dropCoinsAmount = 10;
    public GameObject coinPrefab;
    public Transform dropPosition; 

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
       DropGroupOfCoins();
    }
    
    [NaughtyAttributes.Button] 
    private void DropCoins()
    {
       var i = Instantiate(coinPrefab);
       i.transform.position = dropPosition.position;
       i.transform.DOScale(0, 1f).SetEase(Ease.OutBack).From();
    }

    private void DropGroupOfCoins()
    {
      StartCoroutine(DropGroupOfCoinsCoroutine());   
    }

    IEnumerator DropGroupOfCoinsCoroutine()
    {
        for(int i = 0; i < dropCoinsAmount; i++) 
        {
            DropCoins();
            yield return new WaitForSeconds(.1f);
        }
    }
}
