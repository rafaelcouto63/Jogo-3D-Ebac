using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public float timeToDestroy = 1f;
    public int damageAmount = 1;
    public float speed = 50f;

    private void Awake()
    {
        Destroy(gameObject, timeToDestroy);
    }

    private void Update()
    {
       transform.Translate(Vector3.forward * speed * Time.deltaTime );
    }

    private void OnCollisionEnter(Collision other)
    {
        var damageable = other.transform.GetComponent<IDamageable>();

        if(damageable != null) 
        {
            damageable.Damage(damageAmount);
        }
        
        if(!other.gameObject.CompareTag("Projectile")) 
        {   
          Destroy(gameObject);
        }
    }
    
}
