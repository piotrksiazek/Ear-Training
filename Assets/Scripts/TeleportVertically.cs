using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportVertically : MonoBehaviour
{
    public GameObject Player;
    public GameObject PlayerMovePoint;
    private Camera cam;
    private float cameraHeight;

    private void Start()
    {
        cam = Camera.main;
        cameraHeight = 2f * cam.orthographicSize;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Player.transform.position += new Vector3(0f, cameraHeight + Mathf.Abs(CommonData.Instance.PlayerBaseYPosition));
            PlayerMovePoint.transform.position = new Vector3(CommonData.Instance.PlayerPositionX, CommonData.Instance.PlayerBaseYPosition);

        }
    }
}
