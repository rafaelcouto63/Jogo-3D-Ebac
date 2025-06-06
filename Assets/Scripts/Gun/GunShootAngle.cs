using UnityEngine;

public class GunShootAngle : GunShootLimit
{
   public int amountPerShoot = 4;
   public float angle = 15f;

   public override void Shoot()
   {
      int mult = 0;

      for (int i = 0; i < amountPerShoot; i++)
      {
        if(i % 2 == 0) 
        {
          mult++;
        }
        var projectile = Instantiate(prefabProjectile, positionShoot); 

        projectile.transform.localPosition = Vector3.zero;
        projectile.transform.localEulerAngles = Vector3.zero + Vector3.up * (i%2 == 0 ? angle : -angle)* mult;

        projectile.speed = speed;
        projectile.transform.parent = null;

        ShakeCamera.Instance.ShakeCam();
      }
   }
}
