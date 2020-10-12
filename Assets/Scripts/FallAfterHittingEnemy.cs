using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallAfterHittingEnemy : MonoBehaviour
{
    public GameObject PlayerMovePoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CommonData.Instance.PlayerBaseYPosition != transform.position.y)
            fallDown();
    }

    private void fallDown()
    {
        PlayerMovePoint.transform.position = new Vector3(CommonData.Instance.PlayerPositionX, CommonData.Instance.PlayerBaseYPosition);
    }
}
