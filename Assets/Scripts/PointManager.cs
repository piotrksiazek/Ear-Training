using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public GameObject EnemyPrefab;
    private List<string> intervalListString;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
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

            //if      (isALiar && CommonData.Instance.isAttackingFromBelow)
            //    CommonData.Instance.Points--;

            //else if (!isALiar && CommonData.Instance.isAttackingFromBelow)
            //    CommonData.Instance.Points++;

            //else if (isALiar && CommonData.Instance.isAttackingFromAbove)
            //    CommonData.Instance.Points++;

            //else if (!isALiar && CommonData.Instance.isAttackingFromAbove)
            //    CommonData.Instance.Points--;



            if (isALiar && CommonData.Instance.isAttackingFromBelow || !isALiar && CommonData.Instance.isAttackingFromAbove)
            {
                CommonData.Instance.Points--;
                animator.SetTrigger("LostPoint");
            }
            else if (!isALiar && CommonData.Instance.isAttackingFromBelow || isALiar && CommonData.Instance.isAttackingFromAbove)
            {
                CommonData.Instance.Points++;
                animator.SetTrigger("GainedPoint");
            }

        }
    }
        
}
