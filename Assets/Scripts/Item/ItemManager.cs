using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using Ebac.Singleton;

namespace Itens
{
 public enum ItemType
 {
    COIN,
    LIFE_PACK
 }
 public class ItemManager : Singleton<ItemManager>
 {
    public List<ItenSetup> itenSetups;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        foreach(var i in itenSetups) 
        {
           i.soInt.value = 0; 
        }
       
    }

    public void AddByType(ItemType itemType, int amount = 1)
    {
        if(amount < 0) return;

        itenSetups.Find(i => i.itemType == itemType).soInt.value += amount;
    }

    public void RemoveByType(ItemType itemType, int amount = 1)
    {
        if(amount > 0) return;
        
        var iten = itenSetups.Find(i => i.itemType == itemType);
        iten.soInt.value -= amount;

        if(iten.soInt.value < 0) 
        {
            iten.soInt.value = 0;
        }
    }
    
    [NaughtyAttributes.Button]
    private void AddCoin()
    {
        AddByType(ItemType.COIN);
    }

    [NaughtyAttributes.Button]
    private void AddLifePack()
    {
        AddByType(ItemType.LIFE_PACK);
    }
    
    [System.Serializable]
    public class ItenSetup
    {
        public ItemType itemType;
        public SOint soInt;
    }
 }
}
