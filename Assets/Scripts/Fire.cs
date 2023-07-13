using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Fire : MonoBehaviour
{
	public GameObject fireObj;
	public Transform posGenerate;
	[SerializeField] private Joystick joysticToView;
	[SerializeField] private PlayerController playerController;

	public float fireSpeed;
	float curFireSpeed = 0;
	public float bulletSpeed;

	private void Start()
	{
		playerController = GetComponent<PlayerController>();
		joysticToView = playerController.joysticToView;
	}

	private void FixedUpdate()
	{
		if (!playerController.playerManager.IsOwner) return;

		if (joysticToView != null && joysticToView.Direction != Vector2.zero)
		{
			curFireSpeed -= Time.deltaTime;
			if (curFireSpeed <= 0)
			{
				Bullet bullet = Instantiate(fireObj, posGenerate.position, Quaternion.identity).GetComponent<Bullet>();

				bullet.speed = joysticToView.Direction.normalized * bulletSpeed;

				curFireSpeed = fireSpeed;
			}
		}
		else curFireSpeed = 0;
	}
}
