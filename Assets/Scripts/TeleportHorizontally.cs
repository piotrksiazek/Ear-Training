using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportHorizontally : MonoBehaviour
{
    public GameObject PlayerMovePoint;
    public GameObject Player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (transform.tag == "LeftCollider")
            {
                CommonData.Instance.isTeleportingSideways = false;
                Player.transform.position = new Vector3(CommonData.Instance.MaxPos + 2f, CommonData.Instance.PlayerBaseYPosition);
                PlayerMovePoint.transform.position = new Vector3(CommonData.Instance.MaxPos, CommonData.Instance.PlayerBaseYPosition);
                
            }

            if (transform.tag == "RightCollider")
            {
                print("RIGHT COLLIDER");
                CommonData.Instance.isTeleportingSideways = false;
                Player.transform.position = new Vector3(CommonData.Instance.MinPos - 2f, CommonData.Instance.PlayerBaseYPosition);
                PlayerMovePoint.transform.position = new Vector3(CommonData.Instance.MinPos, CommonData.Instance.PlayerBaseYPosition);
            }

        }

    }
}
