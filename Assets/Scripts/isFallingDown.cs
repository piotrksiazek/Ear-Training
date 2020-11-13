using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class isFallingDown : MonoBehaviour
{
    Text isFallingDownText;
    // Start is called before the first frame update
    void Start()
    {
        isFallingDownText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CommonData.Instance.isAttackingFromBelow)
        {
            isFallingDownText.text = "FROM BELOW";
        }
        else if (CommonData.Instance.isAttackingFromAbove)
        {
            isFallingDownText.text = "FROM ABOVE";
        }
        else
        {
            isFallingDownText.text = "NOT ATTACKING";
        }

        //isFallingDownText.text = CommonData.Instance.ReferenceEnemiesDict.Count.ToString();
    }
}
