using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
public class PlayerController : MonoBehaviour
{
	// Player Field
	public PlayerManager playerManager;
	private Transform player;
	public Transform playerObj { get; private set; }

	// Controller Field
	public Joystick joysticToMove;
	public Joystick joysticToView;

	public float playerMovingSpeed;

	private void Start()
	{
		playerManager = GetComponent<PlayerManager>();
		player = playerManager.player;
	}

	private void FixedUpdate()
	{
		if (!playerManager.IsOwner) return;

		Vector3 dir = Vector3.zero;
		if(joysticToMove != null) dir = joysticToMove.Direction;

		player.position += dir * playerMovingSpeed;

		if(joysticToView != null && joysticToView.Direction != Vector2.zero)
		{
			float angle_rad = Mathf.Atan2(joysticToView.Vertical, joysticToView.Horizontal);
			float angle_del = angle_rad / Mathf.PI * 180;
			player.rotation = Quaternion.Euler(0, 0, angle_del);
		}
	}
}
