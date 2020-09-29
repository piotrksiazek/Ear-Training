using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = default;
    public Transform MovePoint;
    [SerializeField] private float unitsPerStep = default;
    [SerializeField] private float unitsToDissapearBottom = default; //Used when player leaves screen down
    [SerializeField] private float unitsToDissapearSides = default; //Used when player leaves screen sides
    public float MinPos;
    public float MaxPos;
    public DetectEnemyAbove DetectEnemyAbove;
    // Start is called before the first frame update
    void Start()
    {
        MovePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y == CommonData.Instance.PlayerBaseYPosition)
        {
            CommonData.Instance.isAttackingFromAbove = false;
            CommonData.Instance.isAttackingFromBelow = false;
        }

        if (transform.position.y == CommonData.Instance.PlayerBaseYPosition
            //&& Mathf.Abs(transform.position.x - MovePoint.position.x) >= 0.2 * Mathf.Abs(transform.position.x - MovePoint.position.x)
            && transform.position.y == MovePoint.position.y)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (MovePoint.transform.position.x < MaxPos)
                {
                    MovePoint.transform.position += new Vector3(unitsPerStep, 0f);
                }

                else if (MovePoint.transform.position.x == MaxPos)//Leaving screen to the right
                {
                    MovePoint.transform.position += new Vector3(unitsPerStep, 0f);
                    CommonData.Instance.isTeleportingSideways = true;
                }
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                if (MovePoint.transform.position.x > MinPos)
                {
                    MovePoint.transform.position -= new Vector3(unitsPerStep, 0f);
                }
                else if (MovePoint.transform.position.x == MinPos)//Leaving screen to the left
                {
                    MovePoint.transform.position -= new Vector3(unitsPerStep, 0f);
                    CommonData.Instance.isTeleportingSideways = true;
                }
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                CommonData.Instance.isAttackingFromAbove = true;
                MovePoint.transform.position -= new Vector3(0f, unitsToDissapearBottom);
            }

            else if (Input.GetKeyDown(KeyCode.W))
            {

                if (DetectEnemyAbove.EnemyPosition() != null)
                {
                    CommonData.Instance.isAttackingFromBelow = true;
                    MovePoint.transform.position = DetectEnemyAbove.EnemyPosition().position;

                }

            }
        }


        transform.position = Vector2.MoveTowards(transform.position, MovePoint.position, Time.deltaTime * moveSpeed) ;


    }

}
