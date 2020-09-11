using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = default;
    private int startPostion;

    private void Start()
    {
        startPostion = (int)Random.Range(0f, (CommonData.Instance.MaxPos+0.5f))*2;
        transform.position += new Vector3(startPostion, 0f);
    }
    void Update()
    {
        print(startPostion);
        transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
    }
}
