using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = default;
    public Transform MovePoint;
    [SerializeField] private float unitsPerStep = default;
    public float MinPos;
    public float MaxPos;
    // Start is called before the first frame update
    void Start()
    {
        MovePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if(MovePoint.transform.position.x < MaxPos)
            {
                MovePoint.transform.position += new Vector3(unitsPerStep, 0f);
            }  
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (MovePoint.transform.position.x > MinPos)
            {
                MovePoint.transform.position -= new Vector3(unitsPerStep, 0f);
            }  
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            MovePoint.transform.position -= new Vector3(0f, 1f);
        }

        transform.position = Vector2.MoveTowards(transform.position, MovePoint.position, Time.deltaTime * moveSpeed) ;


    }
}
