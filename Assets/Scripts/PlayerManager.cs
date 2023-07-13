using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerManager : NetworkBehaviour
{
	private NetworkVariable<int> networkVariable = new NetworkVariable<int>(1, 
		NetworkVariableReadPermission.Everyone, 
		NetworkVariableWritePermission.Owner);

	public string playerName;
	public Color playerColor;

	public Transform player;
	public Transform playerObj;
	public Health health;
	public int coinCount;

	private void Start()
	{
		if (health != null)	health.Death += MeDestroy;

	}



	public void MeDestroy()
	{
		Destroy(player.gameObject);
	}
}
