using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonData : MonoBehaviour
{
    public static CommonData Instance { get; private set; }
    public float MinPos;
    public float MaxPos;
    public GameObject Player;
    public float PlayerPositionX;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        PlayerPositionX = Player.transform.position.x;
    }
}
