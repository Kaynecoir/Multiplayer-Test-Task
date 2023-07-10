using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
	public GameObject fireObj;
	public Transform posGenerate;
	public Joystick joysticToView;

	public float fireSpeed;
	float curFireSpeed = 0;
	public float bulletSpeed;

	private void Update()
	{
		if (joysticToView.Direction != Vector2.zero)
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
