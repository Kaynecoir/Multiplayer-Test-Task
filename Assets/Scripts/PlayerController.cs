using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private Transform player;
	[SerializeField] private Transform orientation;
	[SerializeField] private Transform playerObj;
	[SerializeField] private Joystick joysticToMove;
	[SerializeField] private Joystick joysticToView;

	public float playerMovingSpeed;
	//public float playerRotarionSpeed;

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
