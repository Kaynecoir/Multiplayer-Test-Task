using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerManager : NetworkBehaviour
{
	[Header("PlayerObject")]
	public Transform player;
	public Transform playerObj;
	public Canvas canvas;
	public Health health;

	[Header("PlayerAtribute")]
	public float playerSpeed;
	public string playerName;

	public delegate void VoidFunc();
	public event VoidFunc Frame;
	public struct PositionStruct : INetworkSerializable
	{
		public float x;
		public float y;
		public float degZ;

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
			serializer.SerializeValue(ref x);
			serializer.SerializeValue(ref y);
			serializer.SerializeValue(ref degZ);
		}
	}

	public NetworkVariable<PositionStruct> networkVariable = new NetworkVariable<PositionStruct>(
		new PositionStruct { x = 0, y = 0, degZ = 0, },
		NetworkVariableReadPermission.Everyone,
		NetworkVariableWritePermission.Owner);

	private void Start()
	{
		Frame += SyncPosition;
		health.Death += DestroyMeServerRpc;
	}
	private void Update()
	{
		Frame?.Invoke();
	}
	public void SyncPosition()
	{
		player.position = new Vector3(networkVariable.Value.x, networkVariable.Value.y);
		player.rotation = Quaternion.Euler(0, 0, networkVariable.Value.degZ);
	}

	public void SetPosition(float new_x, float new_y, float new_degZ)
	{
		networkVariable.Value = new PositionStruct { x = new_x, y = new_y, degZ = new_degZ, };
	}
	
	[ServerRpc]
	public void DestroyMeServerRpc()
	{
		GetComponent<NetworkObject>().Despawn(true);
	}
}
