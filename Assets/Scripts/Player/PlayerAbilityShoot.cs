using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : PlayerAbilityBase
{
    public GunBase gunBase;
   protected override void Init()
   {
     base.Init();
     
     inputs.Gameplay.Shoot.performed += cts => StartShoot();
     inputs.Gameplay.Shoot.performed += cts => CancelShoot();
   }

   private void StartShoot()
   {
    gunBase.StartShoot();
     Debug.Log("Start Shoot");
   }

   private void CancelShoot()
   {
    gunBase.StopShoot();
     Debug.Log("Cancel Shoot");
   }
}
