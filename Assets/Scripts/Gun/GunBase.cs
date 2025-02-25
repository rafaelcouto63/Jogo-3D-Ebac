using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase prefabProjectile;
    public Transform positionShoot;
    public float timeBetweenShoot = 0.3f;
    private Coroutine _currentCoroutine;
    public KeyCode keyCode = KeyCode.S;
    
    
     private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
    }
        

    protected virtual IEnumerator ShootCoroutine()
    {
       while(true) 
       {
        Shoot();
        yield return new WaitForSeconds(timeBetweenShoot);
       }
    
    }
    public void Shoot()
    {
        var projectile = Instantiate(prefabProjectile); 
        projectile.transform.position = positionShoot.position;
        projectile.transform.rotation = positionShoot.rotation;
    }

    public void StartShoot()
    {
       StopShoot();
       _currentCoroutine = StartCoroutine(ShootCoroutine());
    }

    public void StopShoot()
    {
         if(_currentCoroutine !!= null) 
            {
                StopCoroutine(_currentCoroutine);
            }
    }
}
