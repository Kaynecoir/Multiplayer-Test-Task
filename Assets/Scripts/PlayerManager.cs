using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	public Transform player;
	public Transform playerObj;
	public Health health;
	public int coinCount;

	private void Start()
	{
		health.Death += MeDestroy;

	}



	public void MeDestroy()
	{
		Destroy(player.gameObject);
	}
}
