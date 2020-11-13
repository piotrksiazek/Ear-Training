using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public GameObject EnemyPrefab;
    private List<string> intervalListString;
    private void Start()
    {
        intervalListString = EnemyPrefab.GetComponent<SetTypeOfEnemy>().GetIntervalsString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (intervalListString.Contains(collision.transform.tag))
        {
            SetTypeOfEnemy typeOfEnemy = collision.transform.GetComponent<SetTypeOfEnemy>();
            bool isALiar = typeOfEnemy.isALiar;
            string enemyTag = collision.transform.tag;
            string guess = typeOfEnemy.intervalGuess;

            if      (isALiar && CommonData.Instance.isAttackingFromBelow)
                CommonData.Instance.Points--;

            else if (!isALiar && CommonData.Instance.isAttackingFromBelow)
                CommonData.Instance.Points++;

            else if (isALiar && CommonData.Instance.isAttackingFromAbove)
                CommonData.Instance.Points++;

            else if (!isALiar && CommonData.Instance.isAttackingFromAbove)
                CommonData.Instance.Points--;

        }
    }
        
}
