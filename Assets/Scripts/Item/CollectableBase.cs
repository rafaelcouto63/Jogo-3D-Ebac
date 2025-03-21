using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBase : MonoBehaviour
{
    public string compareTag = "Player";
    public ParticleSystem particleSystem;
    public GameObject graphicItem;
    public float timeToHide;

    [Header("Sounds")]
    public AudioSource audioSource;

    private void Awake()
    {
        if(particleSystem != null) 
        {
            particleSystem.transform.SetParent(null);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag(compareTag)) 
        {
            Collect();
        }
    }
    protected virtual void Collect()
    {
        if(graphicItem != null) 
        {
            graphicItem.SetActive(false);
        }
       Invoke("HideObject", timeToHide);
       OnCollect();
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }
    
    protected virtual void OnCollect()
    {
       if(particleSystem != null) 
       {
          particleSystem.Play();
       }

       if(audioSource != null) 
       {
           audioSource.Play();
       }
    }

   
}
