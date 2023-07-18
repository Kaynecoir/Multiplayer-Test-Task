using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Fire : NetworkBehaviour
{
    public GameObject fireObj;
    public Transform posGenerate;
    public PlayerController playerController;

    public float fireSpeed;
    float curFireSpeed = 0;
    public float bulletSpeed;
    //[SerializeField] private Joystick joysticToView;
    [SerializeField] private Canvas canvas;
    void Start()
    {
        playerController = GetComponent<PlayerController>();
		canvas = playerController.playerManager.canvas;
    }

    void Update()
    {
		if (!playerController.playerManager.IsOwner) return;
		curFireSpeed -= Time.deltaTime;
		if (Input.GetKey(KeyCode.Space))
		{
			if (curFireSpeed <= 0)
			{
				Debug.Log("Fire");
				Vector3 dirView = playerController.SetVectorView_Mouse();

				float angle_rad = Mathf.Atan2(dirView.y, dirView.x);
				float angle_del = angle_rad / Mathf.PI * 180;
				FireBulletServerRpc(angle_del);

				curFireSpeed = fireSpeed;
			}
		}
		//if (joysticToView != null && joysticToView.Direction != Vector2.zero)
		//{
		//	curFireSpeed -= Time.deltaTime;
		//	if (curFireSpeed <= 0)
		//	{
		//		Bullet bullet = Instantiate(fireObj, posGenerate.position, Quaternion.identity).GetComponent<Bullet>();

		//		bullet.speed = joysticToView.Direction.normalized * bulletSpeed;

		//		curFireSpeed = fireSpeed;
		//	}
		//}
		//else curFireSpeed = 0;
	}		

	[ServerRpc]
	private void FireBulletServerRpc(float degZ)
	{
		GameObject go = Instantiate(fireObj, posGenerate.position, Quaternion.identity);
		Bullet bullet = go.GetComponent<Bullet>();

		go.GetComponent<NetworkObject>().Spawn();

		Vector3 dir = new Vector3(Mathf.Cos(degZ / 180 * Mathf.PI), Mathf.Sin(degZ / 180 * Mathf.PI));
		bullet.speed = dir.normalized * bulletSpeed;
	}
}
