using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CooseColor : MonoBehaviour, IPointerClickHandler
{
	public SpriteRenderer playerSpriteRender;
	public PlayerManager playerManager;
	public Image MyImage;

	public void OnPointerClick(PointerEventData eventData)
	{
		playerSpriteRender.color = MyImage.color;
		playerManager.playerColor = MyImage.color;
	}
}
