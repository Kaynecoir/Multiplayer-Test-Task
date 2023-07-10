using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerManager))]
public class PlayerView : MonoBehaviour
{
    private PlayerManager playerManager;
    public Image healthBar;
    public Text coinText;

    void Start()
    {
        playerManager = GetComponent<PlayerManager>();
    }

    void Update()
    {
        healthBar.fillAmount = playerManager.health.AmountHealth;
        coinText.text = playerManager.coinCount.ToString();
    }
}
