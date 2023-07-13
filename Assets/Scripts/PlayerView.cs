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
        playerManager.playerObj.GetComponent<SpriteRenderer>().color = playerManager.playerColor;
    }

    void Update()
    {
        if (!playerManager.IsOwner) return;
        if (healthBar != null) healthBar.fillAmount = playerManager.health.AmountHealth;
        if (coinText != null) coinText.text = playerManager.coinCount.ToString();
    }
}
