using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
public class PlayerController : MonoBehaviour
{
	// Player Field
	private PlayerManager playerManager;
	private Transform player;
	private Transform playerObj;

	// Controller Field
	[SerializeField] private Joystick joysticToMove;
	[SerializeField] private Joystick joysticToView;

	public float playerMovingSpeed;

	private void Start()
	{
		playerManager = GetComponent<PlayerManager>();
		player = playerManager.player;
	}

	private void Update()
	{
		Vector3 dir = joysticToMove.Direction;

		player.position += dir * playerMovingSpeed;

		if(joysticToView.Direction != Vector2.zero)
		{
			float angle_rad = Mathf.Atan2(joysticToView.Vertical, joysticToView.Horizontal);
			float angle_del = angle_rad / Mathf.PI * 180;
			player.rotation = Quaternion.Euler(0, 0, angle_del);
		}
	}
}
