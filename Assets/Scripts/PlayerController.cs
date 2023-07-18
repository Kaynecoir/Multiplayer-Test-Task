using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
public class PlayerController : MonoBehaviour
{
    public PlayerManager playerManager;
    Transform player;
    Canvas canvas;
    void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        player = playerManager.player;
        canvas = playerManager.canvas;
    }

    void Update()
    {
        if (!playerManager.IsOwner) return;

        // Move
        Vector3 dirMove = SetVectorMove_Key();

        dirMove *= playerManager.playerSpeed * Time.deltaTime;
        dirMove += player.transform.position;


        // Rotation
        Vector3 dirView = SetVectorView_Mouse();

        float angle_rad = Mathf.Atan2(dirView.y, dirView.x);
        float angle_del = angle_rad / Mathf.PI * 180;

        playerManager.SetPosition(dirMove.x, dirMove.y, angle_del);

    }
    public Vector3 SetVectorMove_Key()
	{
        Vector3 dirMove = new Vector3();

        if (Input.GetKey(KeyCode.W)) dirMove += Vector3.up;
        else if (Input.GetKey(KeyCode.S)) dirMove += Vector3.down;
        if (Input.GetKey(KeyCode.D)) dirMove += Vector3.right;
        else if (Input.GetKey(KeyCode.A)) dirMove += Vector3.left;
        
        return dirMove.normalized;
    }

    public Vector3 SetVectorView_Mouse()
	{
        Vector3 dirView = (Input.mousePosition - (Vector3)canvas.renderingDisplaySize / 2) / 108 - player.position;

        return dirView;
    }
}
