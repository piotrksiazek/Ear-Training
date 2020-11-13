using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDeactivateEnemy : MonoBehaviour
{
    private SetTypeOfEnemy setTypeOfEnemy;
    private int enemyIndex;
    public bool IsFirstInLine = false;
    private SpriteRenderer spriteRenderer;
    public Sprite ActivatedEnemySprite;
    public Sprite DeactivatedEnemySprite;

    private void Update()
    {
        ChangeSprite();
    }
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        print($"my index is {enemyIndex}"); //Delete

    }

    private void ChangeSprite()
    {
        if (IsFirstInLine) 
            spriteRenderer.sprite = ActivatedEnemySprite;
        else 
            spriteRenderer.sprite = DeactivatedEnemySprite;
    }

}
