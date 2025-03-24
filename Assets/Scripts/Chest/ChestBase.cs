using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class ChestBase : MonoBehaviour
{
    public Animator animator;
    public string triggerOpen = "Open"; 
    
    [Header("Notification")]
    public GameObject notification;
    public float tweenDuration = .2f;
    public Ease tweenEase = Ease.OutBack;
    private float startScale;

    void Start()
    {
        startScale = notification.transform.localScale.x;
        HideNotification();
    }

    [NaughtyAttributes.Button] 
    private void OpenChest()
    {
       animator.SetTrigger(triggerOpen);
    }

    public void OnTriggerEnter(Collider other)
    {
        Player3D p = other.transform.GetComponent<Player3D>();
        if(p != null)
        {
           ShowNotification();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        Player3D p = other.transform.GetComponent<Player3D>();
        if(p != null)
        {
           HideNotification();
        }
    }

    private void ShowNotification()
    {
        notification.SetActive(true);
        notification.transform.localScale = Vector3.zero;
        notification.transform.DOScale(startScale, tweenDuration);
    }

    private void HideNotification()
    {
        notification.SetActive(false);
    }
}
