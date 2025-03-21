using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;
    public SOint coins;
    public TextMeshProUGUI coinText;

    private void Awake() 
    {
        if(instance == null) 
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins.value = 0;
        //UpdateCoinText();
    }

    public void AddCoin(int amount)
    {
        coins.value += amount;
        //UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        coinText.text = "X " + coins.value.ToString(); 
    }
}
