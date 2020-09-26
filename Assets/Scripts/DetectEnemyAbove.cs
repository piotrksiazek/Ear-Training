using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemyAbove : MonoBehaviour
{    public Transform EnemyPosition()
    {
        // Cast a ray straight up.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up);

        // If it hits an enemy above
        if (hit.collider != null)
        {
            print("przeciwnik na górze");
            return hit.transform;
        }
        else
        {
            print("nie ma przeciwnika");
            return null;
        }
    }

}
