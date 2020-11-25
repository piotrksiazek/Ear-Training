using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeakCollision : MonoBehaviour
{
    public GameObject EnemyPrefab;
    private List<string> intervalListString;
    private Animator animator;
    private void Start()
    {
        intervalListString = EnemyPrefab.GetComponent<SetTypeOfEnemy>().GetIntervalsString();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Enemy hits peak collider and player looses point
        if(intervalListString.Contains(collision.transform.tag))
        {
            CommonData.Instance.Points--;
            Destroy(collision.gameObject);
        }
    }
}
