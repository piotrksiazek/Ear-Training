using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDeactivateEnemy : MonoBehaviour
{
    private SetTypeOfEnemy setTypeOfEnemy;
    private int enemyIndex;
    public bool IsFirstInLine = false;


    private void Start()
    {
        setTypeOfEnemy = GetComponent<SetTypeOfEnemy>();
        enemyIndex = setTypeOfEnemy.EnemyIndex;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player" || collision.transform.tag == "BottomCollider")
        {
            if(IsFirstInLine)
            {
                Destroy(gameObject);
            }
            
        }
    }

    private void OnDestroy()
    {
        CommonData.Instance.ReferenceEnemiesDict.Remove(enemyIndex);
        CommonData.Instance.DictString.RemoveAt(CommonData.Instance.DictString.Count - 1); //Delete
        print($"my index is {enemyIndex}");

    }

}
