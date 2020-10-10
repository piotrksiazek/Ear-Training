using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectFirstInLineEnemy : MonoBehaviour
{
    RaycastHit2D hit;
    SpriteRenderer spriteRenderer;
    int layerMask;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        layerMask = 1 << 9;
        layerMask = ~layerMask;
    }

    void Update()
    {
        ActivateIfFirstInLine();
    }

    public void ActivateIfFirstInLine()
    {
        hit = Physics2D.Raycast(transform.position, Vector2.up, Mathf.Infinity, layerMask);
        
        if (hit)
        {   
            if(hit.transform.tag != "Player")
            {              
                hit.transform.GetComponent<SpriteRenderer>().color = Color.red; // Replace with activate / deactivate method
                hit.transform.GetComponent<ActivateDeactivateEnemy>().IsFirstInLine = true;
            }

            else
            {
                hit.transform.GetComponent<SpriteRenderer>().color = Color.white;
                hit.transform.GetComponent<ActivateDeactivateEnemy>().IsFirstInLine = false;
            }
        }
        
        
    }

    public void TestRay()
    {
        
    }
}
