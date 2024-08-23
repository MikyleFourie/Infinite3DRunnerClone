using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuCoins : MonoBehaviour
{
    public TextMeshProUGUI totalCoinCount;

    void Start()
    {
        // Load and display the total accumulated coin count from PlayerPrefs
        int totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        totalCoinCount.text = totalCoins.ToString();
    }
}
